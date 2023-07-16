import { BaseService } from "../../../services/base.service";
import { HttpClient } from "@angular/common/http";
import { ApiRoute } from "../../../../shared/constant/api-route";
import { Injectable } from "@angular/core";
import { AppConsts } from "@shared/AppConsts";

@Injectable({
  providedIn: "root",
})
export class LoanOriginatorInfoService extends BaseService {
  constructor(private httpService: HttpClient) {
    super(httpService,  "http://localhost:21021/api");
  }
  create(data) {
    return this.post(ApiRoute.createLoanOriginatorInfo, data);
  }
}
