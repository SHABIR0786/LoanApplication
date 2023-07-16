import { BaseService } from "../../../services/base.service";
import { HttpClient } from "@angular/common/http";
import { ApiRoute } from "../../../../shared/constant/api-route";
import { Injectable } from "@angular/core";
import { AppConsts } from "@shared/AppConsts";

@Injectable({
  providedIn: "root",
})
export class FinancialInfoRealEstateService extends BaseService {
  constructor(private httpService: HttpClient) {
    super(httpService, "http://localhost:21021/api");
  }
  getAllFinancialInfoAssetsLiabilities(data) {
    return this.get(ApiRoute.getMortgageApplicationAssetandLiability, {
      Sorting: "",
      SkipCount: 0,
      MaxResultCount: 10,
    });
  }
  createFinancialInfoAssetsLiabilities(data) {
    return this.post(ApiRoute.createMortgageApplicationAssetandLiability, data);
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
    return this.post(ApiRoute.createFinancialRealEstate, data);
  }
}
