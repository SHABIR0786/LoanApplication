import { BaseService } from "../../../services/base.service";
import { HttpClient } from "@angular/common/http";
import { ApiRoute } from "../../../../shared/constant/api-route";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class DemographicInfoService extends BaseService {
  constructor(private httpService: HttpClient) {
    super(httpService, "http://localhost:21021/api");
  }
  create(data) {
    return this.post(ApiRoute.createDemoGraphicInfo, data);
  }
}
