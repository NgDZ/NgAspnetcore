import {
  ChangeDetectorRef,
  Directive,
  Inject,
  Injector,
  OnDestroy,
  Optional,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Subject, BehaviorSubject } from 'rxjs';
import { AsyncDataSource, CrudOperation } from './async-datasource';
import { LoggerService } from './logger.service';
@Directive({})
export class BaseAsyncComponent implements OnDestroy {
  protected cd: ChangeDetectorRef = this.injector.get(ChangeDetectorRef);
  title: string;
  protected logger: LoggerService = this.injector.get(LoggerService);

  destroyed$ = new Subject<any>();

  protected _loading = 0;
  public get loading(): number {
    return this._loading;
  }

  // tslint:disable-next-line: adjacent-overload-signatures
  public set loading(v: number) {
    if (v < 0) {
      v = 0;
    }
    if (this._loading !== v) {
      this.loading$.next(v);
    }
    if (v < 0) {
      v = 0;
    }
    this._loading = v;
  }
  public loading$: BehaviorSubject<number> = new BehaviorSubject<number>(0);

  constructor(protected injector: Injector) {}
  ngOnDestroy(): void {
    this.beforeDestroy();
    this.destroyed$.next(true);
    setTimeout(() => {
      this.destroyed$.complete();
    }, 200);
  }
  beforeDestroy() {}

  protected asyncError(e: any) {
    if (this.loading > 0) {
      this.loading--;
    }
    this.logger.asyncError(e);
  }
  log(k) {
    console.log(k);
  }
}

@Directive({})
export class BaseCrudComponent<datatype> extends BaseAsyncComponent {
  @ViewChild('editDialog', { static: true })
  template: TemplateRef<any>;
  displayedColumns = [];
  dataSource: AsyncDataSource<datatype> | null;
  editForm: FormGroup;
  dialogRef: MatDialogRef<any>;

  protected dialog: MatDialog = this.injector.get(MatDialog);
  // protected cd: ChangeDetectorRef = this.injector.get(ChangeDetectorRef);
  constructor(
    @Optional()
    injector: Injector
  ) {
    super(injector);
  }

  edit(item) {
    this.dataSource.initEdit$(item).subscribe((k) => {
      this.dataSource.operation = CrudOperation.Create;
      this.dialogEdit(k);
    });
  }
  dialogEdit(entity: Partial<datatype>) {
    this.dataSource.current.next(entity as any);
    if (this.editForm != null) {
      this.editForm.reset(entity);
    }
    this.dialogRef = this.dialog.open(this.template, {
      data: Object.assign({}, entity),
      panelClass: ['overflow-auto', 'p-0'],
      maxWidth: '90vw',
      disableClose: true,
    }); // , this.current
  }

  startEdit(entity: Partial<datatype>) {
    this.dataSource.initEdit$(entity).subscribe((k) => {
      this.dataSource.operation = CrudOperation.Create;
      this.dialogEdit(k);
    });
  }
  closeDialog() {
    if (this.dialogRef != null) {
      this.dialogRef.close();
    }
  }
  cancel() {
    this.dataSource.current = null;
    this.closeDialog();
  }

  canSave(): boolean {
    return this.editForm != null && this.editForm.valid;
  }
  save(item?) {
    if (this.dataSource.operation == null) {
      return true;
    }
    switch (this.dataSource.operation) {
      case CrudOperation.Create:
        this.dataSource.create(item);
        break;
      case CrudOperation.Update:
        this.dataSource.update(item);
        break;
      case CrudOperation.Delete:
        this.dataSource.delete(item);
        break;
    }
  }
}
