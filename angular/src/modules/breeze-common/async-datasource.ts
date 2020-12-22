import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { map, finalize, switchMap, tap } from 'rxjs/operators';
import {
  Observable,
  of as observableOf,
  merge,
  BehaviorSubject,
  combineLatest,
  from,
  of,
} from 'rxjs';

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
    console.log('loading:'+v);
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
  sort: BehaviorSubject<Sort> = new BehaviorSubject<Sort>({
    active: null,
    direction: null,
  });

  count: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  requestCount = true;
  filter: BehaviorSubject<any> = new BehaviorSubject<any>({});
  config: BehaviorSubject<any> = new BehaviorSubject<any>({});

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
      this.filter.pipe(tap(() => (this.requestCount = true))),
      this.config.pipe(tap(() => (this.requestCount = true))),
    ];

    return combineLatest(dataMutations).pipe(
      // map(() => {
      //   return this.getPagedData(this.getSortedData([...this.data]));
      // }),
      tap((k) => this.loading++),
      switchMap((g) =>
        (this.config.value.em == null
          ? observableOf([])
          : this.GetNextPage()
        ).pipe(finalize(() => this.loading--))
      ),
      switchMap((k) => {
        this.data.next(k as any);
        return this.data;
        // this.count.next(k.length);
      })
    ) as any;
  }

  protected GetNextPage() {
    return of([] as NgEntity[]);
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}
  deleteAsync(item: any) {
    return of(item);
  }
  delete(item: any): Observable<any> {
    this.loading++;
    return this.deleteAsync(item).pipe(
      tap((k) => {
        this.deleteLocal(item);
      }),
      finalize(() => {
        this.loading--;
      })
    );
  }
  protected deleteLocal(item) {
    this.data.value.splice(this.data.value.indexOf(item), 1);
    this.count.next(this.count.value - 1);
    this.data.next(this.data.value);
  }

  protected createLocal(item) {
    this.count.next(this.count.value + 1);
    this.data.next(this.data.value);
  }

  protected updateLocal(item) {
    this.data.value.splice(this.data.value.indexOf(item), 1);
    this.data.next(this.data.value);
  }
}
