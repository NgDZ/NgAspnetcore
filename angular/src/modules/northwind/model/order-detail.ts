// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { Product } from './product';
import { SalesOrder } from './sales-order';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class OrderDetail extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  discount: any;
  orderId: number;
  productId: number;
  quantity: number;
  unitPrice: any;
  order: SalesOrder;
  product: Product;
}

