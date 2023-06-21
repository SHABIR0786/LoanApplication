import { BaseService } from "../../../services/base.service";
import { HttpClient } from "@angular/common/http";
import { ApiRoute } from "../../../../shared/constant/api-route";
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AcknowlegdementsAgreementsService extends BaseService{
  constructor(private httpService: HttpClient) {
    super(httpService, "http://localhost:21021/api");
  }
  createApplicationAgreement(data) {
    return this.post(ApiRoute.createApplicationAgreement, data);
  }
}
