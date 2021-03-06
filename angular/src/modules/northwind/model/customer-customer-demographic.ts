// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { Customer } from './customer';
import { CustomerDemographic } from './customer-demographic';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class CustomerCustomerDemographic extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  customerId: number;
  customerTypeId: number;
  customer: Customer;
  customerType: CustomerDemographic;
}

