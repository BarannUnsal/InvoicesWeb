import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService) { super(spinner); }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BitsBall);
  }

}
