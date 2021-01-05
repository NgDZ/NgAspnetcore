import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Customer } from '@module/northwind';
import { BreezeServerDataSource, EntityManagerProvider, executeLookupsQuery } from '@abpdz/ng.breeze';
import { EntityManager } from 'breeze-client';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements AfterViewInit, OnInit {
  dataSource: BreezeServerDataSource<Customer>;
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
  constructor(private provider: EntityManagerProvider) {}
  ngOnInit() {
    this.dataSource = new BreezeServerDataSource();
    this.provider
      .registerManager({}, true, () => {}, '/api/northwind')
      .subscribe((k) => {
        this.em = k;
        this.dataSource.config.next({ em: k, collection: 'Customers' });
        executeLookupsQuery(this.em, {}).subscribe((k) => {});
      });
  }

  ngAfterViewInit() {}
  save() {
    this.em.saveChanges().then((k) => console.log('end'));
  }
}
