import { map, switchMap, tap } from 'rxjs/operators';
import { Observable, of as observableOf, combineLatest, from, of } from 'rxjs';
import { EntityManager, EntityQuery } from 'breeze-client';
import { executeObservableQuery } from '@module/breeze-common';
import { AsyncDataSource } from './async-datasource';

export class RestDataSource<NgEntity> extends AsyncDataSource<NgEntity> {
  constructor() {
    super();
  }
}
