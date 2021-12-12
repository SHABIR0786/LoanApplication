import { Result } from "common";
import { IBuyingHomeModel } from "@app/interfaces/IBuyingHomeModel";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HomeBuyingService } from "../../services/home-buying.service";
import { HomeBuyingDataService } from "../../services/homeBuyingData.service";

@Component({
  selector: "app-animated-step1",
  templateUrl: "./animated-step1.component.html",
  styleUrls: ["./animated-step1.component.css"],
})
export class AnimatedStep1Component implements OnInit {
  constructor(
    private _route: Router,
    private _homeBuyingService: HomeBuyingService,
    private _homeBuyingDataService: HomeBuyingDataService
  ) {}
  formData: IBuyingHomeModel = {};
  ngOnInit(): void {
    this.formData = this._homeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this.formData = {};
    }
  }

  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated"]);
  }

  proceedToNext(value) {
    this.formData.propertyType = value;
    // this._homeBuyingService
    // .post<Result<IBuyingHomeModel>>("Add", formData)
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
    this._homeBuyingDataService.data = this.formData;
    this._route.navigate(["app/buy-a-home-animated-step2"]);
  }
}
