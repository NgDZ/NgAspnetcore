// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { EmployeeTerritory } from './employee-territory';
import { Region } from './region';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Territory extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  regionId: number;
  territoryCode: string;
  territorydescription: string;
  employeeTerritories: EmployeeTerritory[];
  region: Region;
}

