// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { Category } from './category';
import { OrderDetail } from './order-detail';
import { Supplier } from './supplier';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Product extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  categoryId: number;
  discontinued: string;
  productName: string;
  quantityPerUnit: string;
  reorderLevel: number;
  supplierId: number;
  unitPrice: any;
  unitsInStock: number;
  unitsOnOrder: number;
  category: Category;
  orderDetails: OrderDetail[];
  supplier: Supplier;
}

