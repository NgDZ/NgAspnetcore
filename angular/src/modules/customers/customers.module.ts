import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { CustomersComponent } from './customers/customers.component';
import { CustomersAbpComponent } from './customers-abp/customers-abp.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllMaterialModule } from '@module/all-material';
import { BreezeCommonModule } from '@abpdz/ng.breeze';
import { ThemeSharedModule } from '@abpdz/ng.theme.shared';
import { CoreModule } from '@abpdz/ng.core';

@NgModule({
  declarations: [CustomersComponent, CustomersAbpComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    BreezeCommonModule,
    ReactiveFormsModule,
    ThemeSharedModule,
    FormsModule,
    CoreModule.forLazy(),
    AllMaterialModule,
  ],
})
export class CustomersModule {}
