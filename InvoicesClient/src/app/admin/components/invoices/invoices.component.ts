import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { CreateInvoice } from 'src/app/contracts/createinvoice';
import { HttpClientService } from 'src/app/services/common/httipclientserivce.service';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.scss']
})
export class InvoicesComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private httpClientService: HttpClientService) { super(spinner) }

  @ViewChild(ListComponent) listComponent: ListComponent;

  createdInvoice(createdInvoice: CreateInvoice) {
    this.listComponent.getInvoices();
  }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BitsBall);
    this.httpClientService.get<CreateInvoice[]>({
      controller: "invoices"
    }).subscribe(data => console.log(data));
  }


}
