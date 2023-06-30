import { BaseService } from "../../../services/base.service";
import { HttpClient } from "@angular/common/http";
import { ApiRoute } from "../../../../shared/constant/api-route";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class LoanPropertyInfoService extends BaseService {
  constructor(private httpService: HttpClient) {
    super(httpService, "http://localhost:21021/api");
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
  create(data: any) {
    return this.post(ApiRoute.createFinancialInfo, data);
  }
}
