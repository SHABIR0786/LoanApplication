import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IBuyingHomeLoanOptionModel } from "@app/interfaces/IBuyingHomeLoanOptionModel";
import { LoanOptionHomeBuyingDataService } from "../../services/loanOptionHomeBuyingData.service";

@Component({
  selector: "app-lone-option-step11",
  templateUrl: "./lone-option-step11.component.html",
  styleUrls: ["./lone-option-step11.component.css"],
})
export class LoneOptionStep11Component implements OnInit {
  constructor(
    private _route: Router,
    private _loanOptionHomeBuyingDataService: LoanOptionHomeBuyingDataService
  ) {}
  formData: IBuyingHomeLoanOptionModel;

  ngOnInit(): void {
    this.formData = this._loanOptionHomeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this._route.navigate(["app/buy-a-home-loan-options-animated-step1"]);
    }
  }
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step10"]);
  }
  proceedToNext(value) {
    this.formData.plan_page11 = value;
    this._loanOptionHomeBuyingDataService.data = this.formData;
    this._route.navigate(["app/buy-a-home-loan-options-animated-step12"]);
  }
}
