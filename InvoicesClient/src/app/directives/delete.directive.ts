import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlertifyService, MessageType, Position } from '../services/admin/alertify.service';
import { HttpClientService } from '../services/common/httipclientserivce.service';
import { SpinnerType } from '../base/base.component';
import {MatDialog} from '@angular/material/dialog';
import { DeleteDialogComponent, DeleteState } from '../dialogs/delete-dialog/delete-dialog.component';
import { HttpErrorResponse } from '@angular/common/http';

declare var $: any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private elementRef: ElementRef, private _render: Renderer2, private httpClientService: HttpClientService, private spinner: NgxSpinnerService, private dialog: MatDialog, private alertifyService: AlertifyService) { 
    const img = _render.createElement("img");
    img.setAttribute("src", "../../../../../assets/delete .png");
    img.SetAttribute("style", "cursor:pointer;");
    img.width = 25;
    img.height = 25;
    _render.appendChild(elementRef.nativeElement, img);
  }

  @Input() id: string;
  @Input() controller: string;
  @Output() callback: EventEmitter<any> = new EventEmitter();

  @HostListener("click")
  async onclick() {
    this.openDialog(async () => {
      this.spinner.show(SpinnerType.BitsBall);
      const td: HTMLTableCellElement = this.elementRef.nativeElement;
      this.httpClientService.delete({
        controller: this.controller
      }, this.id).subscribe(data => {
        $(td.parentElement).animate({
          opacity: 0,
          left: "+=50",
          height: "toogle"
        }, 700, () => {
          this.callback.emit();
          this.alertifyService.message("Fatura başarıyla silinmiştir.", {
            dismissOthers: true,
            messageType: MessageType.Success,
            position: Position.TopRight
          })
        });
      }, (errorResponse: HttpErrorResponse) => {
        this.spinner.hide(SpinnerType.BitsBall);
        this.alertifyService.message("Fatura silinirken beklenmeyen bir hatayla karşılaşılmıştır.", {
          dismissOthers: true,
          messageType: MessageType.Error,
          position: Position.TopRight
        });
      });
    });
  }
  openDialog(afterClosed: any): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: DeleteState.Yes,
    })

    dialogRef.afterClosed().subscribe(result => {
      if (result == DeleteState.Yes)
        afterClosed();
    });
}

}

