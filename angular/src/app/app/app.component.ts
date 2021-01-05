import { Directionality } from '@angular/cdk/bidi';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
} from '@angular/core';

@Component({
  selector: 'app-root',
  template: ' <router-outlet></router-outlet> ',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  title = 'ngaspnetcore';
  constructor(private dir: Directionality, private cd: ChangeDetectorRef) {
    this.dir.change.subscribe((k:any) => {
      this.cd.markForCheck();
    });
  }
}
