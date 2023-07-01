import { Injectable } from "@angular/core";

import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { AppConsts } from "@shared/AppConsts";
import { ApiRoute } from "../../shared/constant/api-route";
@Injectable({
  providedIn: "root",
})
export class BorrowService extends BaseService {
  constructor(private httpService: HttpClient) {
    super(httpService, AppConsts.remoteServiceBaseUrl);
  }
  getAllCitizenshipType() {
    return this.get(ApiRoute.getCitizenshipType, null);
  }
  createMortgageLoanApplication(data) {
    return this.post(ApiRoute.createMortgageLoanApplication, data);
  }
  getCountries() {
    return this.get(ApiRoute.getCountry, null);
  }
  getStates() {
    return this.get(ApiRoute.getStates, null);
  }
  getCities() {
    return this.get(ApiRoute.getCities, null);
  }
}
