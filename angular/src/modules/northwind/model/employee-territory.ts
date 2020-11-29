// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { Employee } from './employee';
import { Territory } from './territory';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class EmployeeTerritory extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  employeeId: number;
  territoryCode: string;
  employee: Employee;
  territoryCodeNavigation: Territory;
}

