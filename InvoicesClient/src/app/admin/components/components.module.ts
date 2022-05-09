import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardModule } from './dashboard/dashboard.module';
import { HousesModule } from './houses/houses.module';
import { InvoicesModule } from './invoices/invoices.module';
import { UsersModule } from './users/users.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DashboardModule,
    HousesModule,
    InvoicesModule,
    UsersModule,
    HttpClientModule
  ]
})
export class ComponentsModule { }
