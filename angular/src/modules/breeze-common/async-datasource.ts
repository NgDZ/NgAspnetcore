import { DataSource } from '@angular/cdk/collections';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { switchMap, tap, shareReplay, take } from 'rxjs/operators';
import {
  Observable,
  of as observableOf,
  BehaviorSubject,
  combineLatest,
  of,
} from 'rxjs';
export enum CrudOperation {
  Read = 1,
  Create = 2,
  Update = 4,
  Delete = 8,
  None = 0,
}
/**
 * Data source for the Orders view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class AsyncDataSource<NgEntity> extends DataSource<NgEntity> {
  protected _loading = 0;
  public get loading(): number {
    return this._loading;
  }
  // tslint:disable-next-line: adjacent-overload-signatures
  public set loading(v: number) {
    console.log('loading:' + v);
    if (v < 0) {
      v = 0;
    }
    if (this._loading !== v) {
      this.loading$.next(v);
    }
    if (v < 0) {
      v = 0;
    }
    this._loading = v;
  }
  public loading$: BehaviorSubject<number> = new BehaviorSubject<number>(0);

  data: BehaviorSubject<NgEntity[]> = new BehaviorSubject<NgEntity[]>([]);
  current: BehaviorSubject<NgEntity> = new BehaviorSubject<NgEntity>(null);
  page: BehaviorSubject<PageEvent> = new BehaviorSubject<PageEvent>({
    pageIndex: 0,

    pageSize: 10,
    length: 15,
  });
  operation: CrudOperation = null;
  sort: BehaviorSubject<Sort> = new BehaviorSubject<Sort>({
    active: null,
    direction: null,
  });
  group: BehaviorSubject<Sort> = new BehaviorSubject<any>({});

  count: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  requestCount = true;
  filter: BehaviorSubject<any> = new BehaviorSubject<any>({});
  config: BehaviorSubject<any> = new BehaviorSubject<any>({});
  protected connect$: Observable<any>;

  constructor() {
    super();
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<NgEntity[]> {
    // Combine everything that affects the rendered data into one update
    // stream for the data-table to consume.
    const dataMutations = [
      this.page,
      this.sort,
      this.group,
      this.filter.pipe(tap(() => (this.requestCount = true))),
      this.config.pipe(tap(() => (this.requestCount = true))),
    ];
    if (this.connect$ == null) {
      this.connect$ = combineLatest(dataMutations).pipe(
        switchMap(() => {
          this.loading++;
          return this.nextPage().pipe(take(1));
        }),
        switchMap((k) => {
          this.data.next(k as any);
          return this.data;
          // this.count.next(k.length);
        }),
        tap(
          () => this.loading--,
          () => this.loading--
        ),
        shareReplay()
      ) as any;
    }
    return this.connect$;
  }

  // implment this function to retive next page
  protected nextPage() {
    return of([] as NgEntity[]);
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}
  deleteServer(item: any): Observable<any> {
    return of(item);
  }
  confirmDelete(item) {
    return of(true);
  }
  delete$(item: any): Observable<any> {
    this.loading++;
    return this.deleteServer(item).pipe(
      tap(
        () => {
          this.loading--;
          this.deleteLocal(item);
        },
        () => {
          this.loading--;
          return null;
        }
      )
    );
  }
  delete(item) {
    this.delete$(item).subscribe(
      () => {},
      () => {}
    );
  }

  protected deleteLocal(item) {
    this.data.value.splice(this.data.value.indexOf(item), 1);
    this.count.next(this.count.value - 1);
    this.operation = null;
    this.data.next(this.data.value);
  }

  initServer(item: any): Observable<any> {
    return of(item);
  }

  createServer(item: any): Observable<any> {
    return of(item);
  }
  create$(item: any): Observable<any> {
    this.loading++;
    return this.createServer(item).pipe(
      tap(
        () => {
          this.loading--;
          this.createLocal(item);
        },
        () => {
          this.loading--;
          return null;
        }
      )
    );
  }
  create(item) {
    this.delete$(item).subscribe(
      () => {},
      () => {}
    );
  }

  protected createLocal(item) {
    this.count.next(this.count.value + 1);
    this.operation = null;
    this.data.next([...this.data.value, item]);
  }

  updateServer(item: any): Observable<any> {
    return of(item);
  }
  update$(orginalItem: any): Observable<any> {
    this.loading++;
    return this.updateServer(orginalItem).pipe(
      tap(
        (newItem) => {
          this.loading--;
          this.updateLocal(orginalItem, newItem);
        },
        () => {
          this.loading--;
          return null;
        }
      )
    );
  }
  update(item) {
    this.update$(item).subscribe(
      () => {},
      () => {}
    );
  }

  protected updateLocal(item, newItem) {
    this.operation = null;
    const index = this.data.value.indexOf(item);

    this.data.next([
      // part of the array before the specified index
      ...this.data.value.slice(0, index),
      // inserted item
      newItem,
      // part of the array after the specified index
      ...this.data.value.slice(index),
    ]);
  }
}
