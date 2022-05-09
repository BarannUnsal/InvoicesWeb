import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { CreateInvoice } from 'src/app/contracts/createinvoice';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { InvoiceService } from 'src/app/services/common/models/invoice.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private alertify: AlertifyService, private invoiceService: InvoiceService) { super(spinner) }

  ngOnInit(): void {
  }

  @Output() createdInvoice: EventEmitter<CreateInvoice> = new EventEmitter();

  create(title: HTMLInputElement, invoiceNumber: HTMLInputElement, invoiceType: HTMLInputElement, expiration: HTMLInputElement, description: HTMLInputElement) {
    this.showSpinner(SpinnerType.BitsBall);
    const create_invoice: CreateInvoice = new CreateInvoice();
    create_invoice.description = description.value;
    create_invoice.expiration = expiration.value;
    create_invoice.title = title.value;
    create_invoice.invoiceType = invoiceType.value;
    create_invoice.invoiceNumber = parseInt(invoiceNumber.value);

    this.invoiceService.create(create_invoice, () => {
      this.hideSpinner(SpinnerType.BitsBall);
      this.alertify.message("Fatura başarıyla eklenmiştir!", {
        dismissOthers: true,
        messageType: MessageType.Success,
        position: Position.TopRight
      });
      this.createdInvoice.emit(create_invoice);
    }, errorMessage => {
      this.alertify.message(errorMessage, {
        dismissOthers: true,
        messageType: MessageType.Error,
        position: Position.TopRight
      })
    });
  }
}
