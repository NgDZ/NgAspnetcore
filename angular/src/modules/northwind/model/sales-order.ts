// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { Customer } from './customer';
import { OrderDetail } from './order-detail';
import { Shipper } from './shipper';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class SalesOrder extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  customerId: number;
  employeeId: number;
  freight: any;
  orderDate: any;
  requiredDate: any;
  shipAddress: string;
  shipCity: string;
  shipCountry: string;
  shipName: string;
  shipPostalCode: string;
  shipRegion: string;
  shippedDate: any;
  shipperId: number;
  customer: Customer;
  orderDetails: OrderDetail[];
  shipper: Shipper;
}

