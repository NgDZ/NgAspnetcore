// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Order extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  id: number;
  customerId: string;
  employeeId: number;
  freight: any;
  orderDate: string;
  requiredDate: string;
  shipAddress: string;
  shipCity: string;
  shipCountry: string;
  shipName: string;
  shipPostalCode: string;
  shipRegion: string;
  shipVia: number;
  shippedDate: string;
}

