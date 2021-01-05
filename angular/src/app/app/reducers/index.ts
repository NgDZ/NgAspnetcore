import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from '../../environments/environment';

export interface AppState {}

export const appReducers: ActionReducerMap<AppState> = {};

export const appMetaReducers: MetaReducer<AppState>[] = !environment.production
  ? []
  : [];
