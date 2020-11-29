import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import {
  EntityManagerProvider,
  executeLookupsQuery,
} from '@module/breeze-common';
import { SalesOrder } from '@module/northwind';
import { EntityManager } from 'breeze-client';
import { BreezeServerDataSource } from '../../breeze-common/breeze-server-datasource';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements AfterViewInit, OnInit {
  dataSource: BreezeServerDataSource<SalesOrder>;
  row_: SalesOrder;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    'Actions',
    'entityId',
    'customer.contactName',
    'orderDate',
    'shipAddress',
  ];
  em: EntityManager;

  constructor(private provider: EntityManagerProvider) {}
  ngOnInit() {
    this.dataSource = new BreezeServerDataSource();
    this.provider
      .registerManager({}, true, () => {}, '/api/northwind')
      .subscribe((k) => {
        this.em = k;

        executeLookupsQuery(this.em, {}).subscribe((F) => {
          this.dataSource.breeez.next({ em: k, collection: 'SalesOrders' });
        });
      });
  }

  ngAfterViewInit() {}
}
