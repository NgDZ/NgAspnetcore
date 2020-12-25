import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Customer } from '@module/northwind';
import { BreezeServerDataSource } from '@module/breeze-common/breeze-server-datasource';
import { EntityManager } from 'breeze-client';
import {
  EntityManagerProvider,
  executeLookupsQuery,
} from '../../breeze-common/breeze-helpers';
import { HttpClient } from '@angular/common/http';
import { AbpIOHttpService, RestDataSource } from '@module/breeze-common';
import { AsyncDataSource } from '@module/breeze-common/async-datasource';

@Component({
  selector: 'app-customers-abp',
  templateUrl: './customers-abp.component.html',
  styleUrls: ['./customers-abp.component.scss'],
})
export class CustomersAbpComponent implements AfterViewInit, OnInit {
  dataSource: AsyncDataSource<Customer>;

  showInput = false;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    'Actions',
    'entityId',
    'contactTitle',
    'contactName',
    'companyName',
  ];
  em: EntityManager;
  constructor(private http: HttpClient) {}
  ngOnInit() {
    this.dataSource = new RestDataSource(
      new AbpIOHttpService(this.http, '/api/customers', 'entityId')
    );
    // this.provider
    //   .registerManager({}, true, () => {}, '/api/northwind')
    //   .subscribe((k) => {
    //     this.em = k;
    //     this.dataSource.config.next({ em: k, collection: 'Customers' });
    //     executeLookupsQuery(this.em, {}).subscribe((k) => {});
    //   });
  }

  ngAfterViewInit() {}
  save() {
    this.em.saveChanges().then((k) => console.log('end'));
  }
}
