import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HousesComponent } from './houses.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HousesComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: HousesComponent }
    ])
  ]
})
export class HousesModule { }
