import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { ListInvoice } from 'src/app/contracts/ListInvoice';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { InvoiceService } from 'src/app/services/common/models/invoice.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit {
  constructor(spinner: NgxSpinnerService, private invoiceService: InvoiceService, private alertifyService: AlertifyService) { super(spinner) }

  displayedColumns: string[] = ['invoiceNumber', 'invoiceType', 'expiration', 'title', 'description', 'createdTime', 'updatedTime', 'edit', 'delete'];
  dataSource: MatTableDataSource<ListInvoice> = null;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  async getInvoices() {
    this.showSpinner(SpinnerType.BitsBall);
    const allInvoice: { totalCount: number; invoice: ListInvoice[] } = await this.invoiceService.read(this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5, () => this.hideSpinner(SpinnerType.BitsBall), errorMessage => this.alertifyService.message(errorMessage, {
      dismissOthers: true,
      messageType: MessageType.Error,
      position: Position.TopRight
    }))
    this.dataSource = new MatTableDataSource<ListInvoice>(allInvoice.invoice);
    this.paginator.length = allInvoice.totalCount;
  }
  
  async pageChanged() {
    await this.getInvoices();
  }

  async ngOnInit() {
    await this.getInvoices();
  }

} 
