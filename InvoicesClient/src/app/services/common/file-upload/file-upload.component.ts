import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { FileUploadDialogComponent, FileUploadDialogState } from 'src/app/dialogs/file-upload-dialog/file-upload-dialog.component';
import { AlertifyService, MessageType, Position } from '../../admin/alertify.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../ui/customtoastr.service';
import { DialogService } from '../dialog.service';
import { HttpClientService } from '../httipclientserivce.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {

  public files: NgxFileDropEntry[];

  constructor(private httpClientService: HttpClientService, private alertifyService: AlertifyService, private customToastrService: CustomToastrService, private dialogService: DialogService){}

  @Input() options: Partial<FileUploadOptions>;

  public selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;
    const fileData: FormData = new FormData();
    for(const file of files) {
      (file.fileEntry as FileSystemFileEntry).file((_file: File) => {
        fileData.append(_file.name, _file, file.relativePath);
      });
    }
    
    this.dialogService.openDialog({
      componentType: FileUploadDialogComponent,
      data: FileUploadDialogState.Yes,
      afterClosed: () => {
        this.httpClientService.post({
          controller:this.options.controller,
          action:this.options.action,
          queryString: this.options.queryString,
          headers: new HttpHeaders({"responseType": "blob"})
        }, fileData).subscribe(data => {
          const message: string = "Dosyalar başarılı bir şekilde eklenmiştir.";
          if(this.options.isAdminPage)
          {
            this.alertifyService.message(message, {
              dismissOthers: true,
              messageType: MessageType.Success,
              position: Position.TopRight,
            })
          }
          else
          {
            this.customToastrService.message(message, "Başarılı", {
              messageType: ToastrMessageType.Success,
              position: ToastrPosition.TopRight,
            })
          }
        }, (errorResponse: HttpErrorResponse) => {
          const message: string = "Dosyalar yüklenirken bir hata ile karşılaşıldı.";
          if(this.options.isAdminPage)
          {
            this.alertifyService.message(message, {
              messageType: MessageType.Error,
              position: Position.TopRight,
            })
          }
          else
          {
            this.customToastrService.message(message, "Başarısız", {
              messageType: ToastrMessageType.Error,
              position: ToastrPosition.TopRight,
          })
        }
     });
      }
    })
 }
}

  export class FileUploadOptions {
    controller?: string;
    action?: string;
    queryString? : string;
    accept? : string;
    explantion? : string;
    isAdminPage?: boolean = false;
  }

