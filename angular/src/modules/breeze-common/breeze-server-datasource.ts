import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { map, switchMap, tap } from 'rxjs/operators';
import {
  Observable,
  of as observableOf,
  merge,
  BehaviorSubject,
  combineLatest,
  from,
} from 'rxjs';
import { Entity, EntityManager, EntityQuery } from 'breeze-client';
import { executeObservableQuery } from '@module/breeze-common';

/**
 * Data source for the Orders view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class BreezeServerDataSource<NgEntity> extends DataSource<NgEntity> {
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
  breeez: BehaviorSubject<{
    em: EntityManager;
    collection: string;
  }> = new BehaviorSubject<any>({});

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
      this.breeez.pipe(tap(() => (this.requestCount = true))),
    ];

    return combineLatest(dataMutations).pipe(
      // map(() => {
      //   return this.getPagedData(this.getSortedData([...this.data]));
      // }),
      switchMap((g) => {
        if (this.breeez.value.em == null) {
          return observableOf([]);
        } else {
          const conf = this.breeez.value;
          return executeObservableQuery<NgEntity[]>(
            conf.em,
            conf.collection,
            null,
            (query: EntityQuery) => this.buidBreezeQuery(query)
          ).pipe(
            map((e) => {
              if (e.inlineCount !== null) {
                this.requestCount = false;
                this.count.next(e.inlineCount);
              }
              return e.results;
            })
          );
        }
      }),
      switchMap((k) => {
        this.data.next(k);
        return this.data;
        // this.count.next(k.length);
      })
    ) as any;
  }

  private buidBreezeQuery(query: EntityQuery) {
    const startIndex = this.page.value.pageIndex * this.page.value.pageSize;
    if (startIndex) {
      query = query.skip(startIndex);
    }
    query = query.take(this.page.value.pageSize);
    if (this.requestCount) {
      query = query.inlineCount(true);
    }
    if (this.sort.value.active) {
      query = query.orderBy(
        this.sort.value.active,
        this.sort.value.direction === 'asc'
      );
    }
    return query;
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}
  delete(item: Entity) {
    const bem = this.breeez.value.em;
    if (bem) {
      item.entityAspect.setDeleted();
      from(bem.saveChanges([item])).subscribe((k) => {
        this.deleteLocal(item);
      });
    } else {
      this.deleteLocal(item);
    }
  }
  private deleteLocal(item) {
    this.data.value.splice(this.data.value.indexOf(item), 1);
    this.count.next(this.count.value - 1);
    this.data.next(this.data.value);
  }

  private createLocal(item) {
    this.count.next(this.count.value + 1);
    this.data.next(this.data.value);
  }

  private updateLocal(item) {
    this.data.value.splice(this.data.value.indexOf(item), 1);
    this.data.next(this.data.value);
  }
}
