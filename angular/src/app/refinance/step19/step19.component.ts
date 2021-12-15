import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IRefinanceBuyingHomeModel } from "@app/interfaces/IRefinanceBuyingHomeModel";
import { RefinanceHomeBuyingDataService } from "../../services/refinanceHomeBuyingData.service";
import { RefinanceHomeBuyingService } from "../../services/refinance-home-buying.service";

@Component({
  selector: "app-step19",
  templateUrl: "./step19.component.html",
  styleUrls: ["./step19.component.css"],
})
export class Step19Component implements OnInit {
  constructor(
    private _route: Router,
    private _refinancehomeBuyingService: RefinanceHomeBuyingService,
    private _refinanceHomeBuyingDataService: RefinanceHomeBuyingDataService
  ) {}
  formData: IRefinanceBuyingHomeModel = {};
  ngOnInit(): void {
    this.formData = this._refinanceHomeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this._route.navigate(["app/refinance-step1"]);
    }
  }
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step18"]);
  }
  SubmitForm(value) {
    this.formData.refferedBy = value;
    this._refinanceHomeBuyingDataService.data = this.formData;

    console.log(this._refinanceHomeBuyingDataService.data);
    console.log(this.formData);

    //     this._refinancehomeBuyingService
    // .post<Result<IRefinanceBuyingHomeModel>>("Add", this.formData)
    // .subscribe(
    //   (response) => {
    //     console.log(response);
    //     // this._dataService.loanApplication = response.result;
    //     // this.form.patchValue(this._dataService.loanApplication.loanDetails);
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );

    // this._route.navigate(["app/home"]);
  }
}
