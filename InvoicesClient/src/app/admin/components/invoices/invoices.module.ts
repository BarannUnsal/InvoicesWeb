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
import { DeleteDirective } from 'src/app/directives/delete.directive';
import { MatRadioModule } from '@angular/material/radio';
import { DialogModule } from 'src/app/dialogs/dialog.module';
import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';
@NgModule({
  declarations: [
    InvoicesComponent,
    CreateComponent,
    ListComponent,
    DeleteDirective,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: InvoicesComponent }
    ]),
    MatDatepickerModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatSidenavModule, MatTableModule, MatPaginatorModule, MatRadioModule,
    FileUploadModule,
    DialogModule,
  ]
})
export class InvoicesModule { }
