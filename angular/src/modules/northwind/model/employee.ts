// tslint:disable:no-trailing-whitespace
// tslint:disable:member-ordering
import { BaseEntity } from './base-entity';
import { EmployeeTerritory } from './employee-territory';

/// <code-import> Place custom imports between <code-import> tags

/// </code-import>

export class Employee extends BaseEntity  {

  /// <code> Place custom code between <code> tags
  
  /// </code>

  // Generated code. Do not place code below this line.
  entityId: number;
  address: string;
  birthDate: any;
  city: string;
  country: string;
  email: string;
  extension: string;
  firstname: string;
  hireDate: any;
  lastname: string;
  mgrId: number;
  mobile: string;
  notes: any;
  phone: string;
  photo: any;
  photoPath: string;
  postalCode: string;
  region: string;
  title: string;
  titleOfCourtesy: string;
  employeeTerritories: EmployeeTerritory[];
}

