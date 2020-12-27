import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { Customer } from '@module/northwind';
import { EntityManager } from 'breeze-client';
import { HttpClient } from '@angular/common/http';
import {
  AbpIOHttpService,
  RestDataSource,
  BaseCrudComponent,
} from '@module/breeze-common';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-customers-abp',
  templateUrl: './customers-abp.component.html',
  styleUrls: ['./customers-abp.component.scss'],
})
export class CustomersAbpComponent
  extends BaseCrudComponent<Customer>
  implements AfterViewInit, OnInit {
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
  constructor(
    injector: Injector,
    private http: HttpClient,
    private fb: FormBuilder
  ) {
    super(injector);
  }
  ngOnInit() {
    this.dataSource = new RestDataSource(
      new AbpIOHttpService(this.http, '/api/customers', 'entityId')
    );
    this.editForm = this.fb.group({
      contactName: [],
    });
  }

  ngAfterViewInit() {}
  // save() {
  //   this.em.saveChanges().then((k) => console.log('end'));
  // }
}
