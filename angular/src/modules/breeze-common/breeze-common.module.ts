import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NamingConvention } from 'breeze-client';
import { AjaxHttpClientAdapter } from 'breeze-client/adapter-ajax-httpclient';
import { DataServiceWebApiAdapter } from 'breeze-client/adapter-data-service-webapi';
import { ModelLibraryBackingStoreAdapter } from 'breeze-client/adapter-model-library-backing-store';
import { UriBuilderJsonAdapter } from 'breeze-client/adapter-uri-builder-json';
import { MiniProfilerInterceptor } from 'src/app/shared/mini-profiler.service';
// import { DataServiceODataAdapter } from 'breeze-client/adapter-data-service-odata';
// import { UriBuilderODataAdapter } from 'breeze-client/adapter-uri-builder-odata';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useExisting: MiniProfilerInterceptor,
      multi: true,
    },
  ],
})
export class BreezeCommonModule {
  constructor(http: HttpClient) {
    // Configure Breeze adapters
    ModelLibraryBackingStoreAdapter.register();
    UriBuilderJsonAdapter.register();
    AjaxHttpClientAdapter.register(http);
    DataServiceWebApiAdapter.register();
    // DataServiceODataAdapter.register();
    // UriBuilderODataAdapter.register();
    NamingConvention.camelCase.setAsDefault();
    // breeze.config.initializeAdapterInstance(
    //   'dataService',
    //   'webApiOData4',
    //   true
    // );
  }
}
