import { MetadataStore } from 'breeze-client';

import { Category } from './category';
import { Customer } from './customer';
import { CustomerCustomerDemographic } from './customer-customer-demographic';
import { CustomerDemographic } from './customer-demographic';
import { Employee } from './employee';
import { EmployeeTerritory } from './employee-territory';
import { OrderDetail } from './order-detail';
import { Product } from './product';
import { Region } from './region';
import { SalesOrder } from './sales-order';
import { Shipper } from './shipper';
import { Supplier } from './supplier';
import { Territory } from './territory';

export class NorthwindRegistrationHelper {

    static register(metadataStore: MetadataStore) {
        metadataStore.registerEntityTypeCtor('Category', Category);
        metadataStore.registerEntityTypeCtor('Customer', Customer);
        metadataStore.registerEntityTypeCtor('CustomerCustomerDemographic', CustomerCustomerDemographic);
        metadataStore.registerEntityTypeCtor('CustomerDemographic', CustomerDemographic);
        metadataStore.registerEntityTypeCtor('Employee', Employee);
        metadataStore.registerEntityTypeCtor('EmployeeTerritory', EmployeeTerritory);
        metadataStore.registerEntityTypeCtor('OrderDetail', OrderDetail);
        metadataStore.registerEntityTypeCtor('Product', Product);
        metadataStore.registerEntityTypeCtor('Region', Region);
        metadataStore.registerEntityTypeCtor('SalesOrder', SalesOrder);
        metadataStore.registerEntityTypeCtor('Shipper', Shipper);
        metadataStore.registerEntityTypeCtor('Supplier', Supplier);
        metadataStore.registerEntityTypeCtor('Territory', Territory);
    }
}
