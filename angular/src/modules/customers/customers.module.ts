import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { BreezeCommonModule } from '@module/breeze-common';
import { CustomersComponent } from './customers/customers.component';
import { CustomersAbpComponent } from './customers-abp/customers-abp.component';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllMaterialModule } from '@module/all-material';

@NgModule({
  declarations: [CustomersComponent, CustomersAbpComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,

    TranslateModule.forChild(),
    BreezeCommonModule,

    ReactiveFormsModule,
    FormsModule,

    AllMaterialModule,
  ],
})
export class CustomersModule {}
