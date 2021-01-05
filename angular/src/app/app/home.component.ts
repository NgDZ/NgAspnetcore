import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  template: ` <h1 *ngFor="let item of all">Home :{{ item }}</h1>`,
})
export class HomeComponent implements OnInit {
  all: any = [];
  constructor() {}

  ngOnInit(): void {
    for (let index = 0; index < 500; index++) {
      this.all.push(index);
    }
  }
}
