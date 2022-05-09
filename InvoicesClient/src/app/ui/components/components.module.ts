import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactModule } from './contact/contact.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { HomeModule } from './home/home.module';
import { PaymentModule } from './payment/payment.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ContactModule,
    DashboardModule,
    HomeModule,
    PaymentModule
  ]
})
export class ComponentsModule { }
