import { map, switchMap, tap } from 'rxjs/operators';
import { Observable, of as observableOf, combineLatest, from, of } from 'rxjs';
import { AsyncDataSource } from './async-datasource';
import { IHttpService } from './http-base';

export class RestDataSource<NgEntity> extends AsyncDataSource<NgEntity> {
  constructor(protected api: IHttpService<NgEntity>) {
    super();
  }

  deleteServer(item: any) {
    return this.api.delete(this.api.getId(item)).pipe(map((k) => item));
  }

  createServer(item: any) {
    return this.api.create(item).pipe(map((k) => item));
  }
  updateServer(item: any) {
    return this.api.update(item, this.api.getId(item)).pipe(map((k) => item));
  }
  protected nextPage() {
    let param: any = {
      skipCount: this.page.value.pageIndex * this.page.value.pageSize,
      maxResultCount: this.page.value.pageSize,
      requestCount: this.requestCount,
    };
    if (this.filter.value) {
      param = { ...this.filter.value, ...param };
    }
    console.log('start: param', param);
    return this.api.getAll(param).pipe(
      map((e) => {
        if (e.totalCount !== null) {
          this.requestCount = false;
          this.count.next(e.totalCount);
        }
        return e.items;
      })
    );
  }
}
