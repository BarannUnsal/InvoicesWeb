import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { CreateInvoice } from 'src/app/contracts/createinvoice';
import { ListInvoice } from 'src/app/contracts/ListInvoice';
import { HttpClientService } from '../httipclientserivce.service';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  constructor(private httpClientService: HttpClientService) { }

  create(invoice: CreateInvoice, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "invoices"
    }, invoice)
      .subscribe(result => {
        successCallBack();
      }, (errorResponse: HttpErrorResponse) => {
        const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
        let message = "";
        _error.forEach((v, index) => {
          v.value.forEach((_v, _index) => {
            message += `${_v}<br>`;
          });
        });
        errorCallBack(message);
      });
  }

  async read(page: number = 0, size: number = 5, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<{ totalCount: number, invoice: ListInvoice[] }> {
    const promiseData: Promise<{ totalCount: number, invoice: ListInvoice[] }> = this.httpClientService.get<{ totalCount: number, invoice: ListInvoice[] }>({
      controller: "invoices",
      queryString: `page=${page}&size=${size}`
    }).toPromise();

    promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))

    return await promiseData;
  }

  async delete(id: string){
    const deleteObservable: Observable<any> = this.httpClientService.delete<any>({
      controller: "invoices"
    }, id);

    await firstValueFrom(deleteObservable);
  }
}