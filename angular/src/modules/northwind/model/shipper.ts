// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { SalesOrder } from './sales-order';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Shipper extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  companyName: string;
  phone: string;
  salesOrders: SalesOrder[];
}

