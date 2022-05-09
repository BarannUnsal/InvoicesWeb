import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService) { super(spinner) }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BitsBall);
  }

}
