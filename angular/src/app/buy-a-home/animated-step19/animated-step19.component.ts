import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IBuyingHomeModel } from "@app/interfaces/IBuyingHomeModel";
import { HomeBuyingService } from "../../services/home-buying.service";
import { HomeBuyingDataService } from "../../services/homeBuyingData.service";
@Component({
  selector: "app-animated-step19",
  templateUrl: "./animated-step19.component.html",
  styleUrls: ["./animated-step19.component.css"],
})
export class AnimatedStep19Component implements OnInit {
  formData: IBuyingHomeModel;
  constructor(
    private _route: Router,
    private _homeBuyingService: HomeBuyingService,
    private _homeBuyingDataService: HomeBuyingDataService
  ) {}

  ngOnInit(): void {
    this.formData = this._homeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this._route.navigate(["app/buy-a-home-animated-step1"]);
    }
  }
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step18"]);
  }
  SubmitForm(value) {
    this.formData.refferedBy = value;
    this._homeBuyingDataService.data = this.formData;
    console.log(this._homeBuyingDataService.data);
    console.log(this.formData);

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

    // this._route.navigate(["app/home"]);
  }
}
