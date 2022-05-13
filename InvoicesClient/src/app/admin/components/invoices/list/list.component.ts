import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { ListInvoice } from 'src/app/contracts/listinvoice';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { InvoiceService } from 'src/app/services/common/models/invoice.service';

declare var $: any;

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit {
  constructor(private invoiceService: InvoiceService, spinner: NgxSpinnerService, private alertify: AlertifyService) { super(spinner) }

  displayedColumns: string[] = ['title', 'invoiceNumber', 'description', 'invoiceType', "isActive", "createdTime", "updatedTime", "edit", "delete"];
  dataSource: MatTableDataSource<ListInvoice> = null;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  async getInvoices() {
    this.showSpinner(SpinnerType.BitsBall);
    const allInvoices: { totalCount: number; invoice: ListInvoice[] } = await this.invoiceService.read(this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5, () => this.hideSpinner(SpinnerType.BitsBall), errorMessage => this.alertify.message(errorMessage, {
      dismissOthers: true,
      messageType: MessageType.Error,
      position: Position.TopRight,
    }))
    this.dataSource = new MatTableDataSource<ListInvoice>(allInvoices.invoice);
    this.paginator.length = allInvoices.totalCount;
  }

  async pageChanged() {
    await this.getInvoices();
  }

  async ngOnInit() {
    await this.getInvoices();
  }
}
