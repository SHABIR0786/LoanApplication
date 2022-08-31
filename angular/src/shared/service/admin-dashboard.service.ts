import { Injectable } from '@angular/core';
import { HttpService } from "../http/http.service";
import { ApiRoute } from "../constant/api-route";
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminDashboardService {

  constructor(private httpService: HttpService) {}

  uploadDocument(data){
    
    let params = new HttpParams()
    .set('LoanId', "1")
    .set('DisclosureId',"1")

   const options={
    params:params
   };
   
    return this.httpService.post(
      ApiRoute.uploadAdminLoanApplicationDocument,null,null,options);
  }

}
