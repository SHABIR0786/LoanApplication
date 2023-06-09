import { Injectable } from '@angular/core';

import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";

import { ApiRoute } from "../../shared/constant/api-route";
@Injectable({
  providedIn: 'root'
})
export class BorrowService extends BaseService{
  constructor(private httpService: HttpClient) {
    super(httpService, "http://localhost:21021/api");
  }
  getAllCitizenshipType() {
    return this.get(ApiRoute.getCitizenshipType, null);
  }
  createMortgageLoanApplication(data) {
    return this.post(ApiRoute.createMortgageLoanApplication, data);
  }
}
