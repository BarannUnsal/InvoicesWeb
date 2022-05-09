import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: "admin", component: LayoutComponent, children: [
      { path: "", component: DashboardComponent },
      { path: "houses", loadChildren: () => import("./admin/components/houses/houses.module").then(module => module.HousesModule) },
      { path: "invoices", loadChildren: () => import("./admin/components/invoices/invoices.module").then(module => module.InvoicesModule) },
      { path: "users", loadChildren: () => import("./admin/components/users/users.module").then(module => module.UsersModule) }
    ]
  },
  { path: "", component: HomeComponent },
  { path: "contact", loadChildren: () => import("./ui/components/contact/contact.module").then(module => module.ContactModule) },
  { path: "payment", loadChildren: () => import("./ui/components/payment/payment.module").then(module => module.PaymentModule) },
  { path: "dashboard", loadChildren: () => import("./ui/components/dashboard/dashboard.module").then(module => module.DashboardModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
