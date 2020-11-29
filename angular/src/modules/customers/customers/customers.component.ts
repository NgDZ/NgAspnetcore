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

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements AfterViewInit, OnInit {
  dataSource: BreezeServerDataSource<Customer>;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['entityId', 'contactTitle', 'contactName', 'companyName'];
  em: EntityManager;
  constructor(private provider: EntityManagerProvider) {}
  ngOnInit() {
    this.dataSource = new BreezeServerDataSource();
    this.provider
      .registerManager({}, true, () => {}, '/api/northwind')
      .subscribe((k) => {
        this.em = k;
        this.dataSource.breeez.next({ em: k, collection: 'Customers' });
        executeLookupsQuery(this.em, {}).subscribe((k) => {});
      });
  }

  ngAfterViewInit() {}
}
