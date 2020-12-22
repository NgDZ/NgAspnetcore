import { map, switchMap, tap } from 'rxjs/operators';
import { Observable, of as observableOf, combineLatest, from, of } from 'rxjs';
import { EntityManager, EntityQuery } from 'breeze-client';
import { executeObservableQuery } from '@module/breeze-common';
import { AsyncDataSource } from './async-datasource';


export class RestDataSource<NgEntity> extends AsyncDataSource<NgEntity> {
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
      switchMap((g) => {
        if (this.config.value.em == null) {
          return observableOf([]);
        } else {
          const conf = this.config.value;
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

  buidBreezeQuery(query: EntityQuery) {
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

  deleteAsync(item: any) {
    const bem = this.config.value.em as EntityManager;
    if (bem) {
      item.entityAspect.setDeleted();
      return from(bem.saveChanges([item]));
    } else {
      of(item);
    }
  }

  protected GetNextPage() {
    const conf = this.config.value;
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
}
