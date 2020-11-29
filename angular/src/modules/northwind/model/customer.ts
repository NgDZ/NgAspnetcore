// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { CustomerCustomerDemographic } from './customer-customer-demographic';
import { SalesOrder } from './sales-order';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Customer extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  address: string;
  city: string;
  companyName: string;
  contactName: string;
  contactTitle: string;
  country: string;
  email: string;
  fax: string;
  mobile: string;
  phone: string;
  postalCode: string;
  region: string;
  customerCustomerDemographics: CustomerCustomerDemographic[];
  salesOrders: SalesOrder[];
}

