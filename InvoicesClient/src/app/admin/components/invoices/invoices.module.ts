import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoicesComponent } from './invoices.component';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { ListComponent } from './list/list.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    InvoicesComponent,
    CreateComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: InvoicesComponent }
    ]),
    MatDatepickerModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatSidenavModule, MatTableModule, MatPaginatorModule
  ]
})
export class InvoicesModule { }
