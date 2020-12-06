//import { PersonalInformationComponent } from './../personal-information/personal-information.component';
import { IBorrowerModel } from "./../../interfaces/IBorrowerModel";
//import { Borrower } from './../../../shared/service-proxies/service-proxies';
import { Component, DoCheck, OnInit } from "@angular/core";
import { DataService } from "../../services/data.service";
import { IAdditionalDetailModel } from "../../interfaces/IAdditionalDetailModel";
import { Router } from "@angular/router";
import { IPersonalInformationModel } from "@app/interfaces/IPersonalInformationModel";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-additional-details",
  templateUrl: "./additional-details.component.html",
  styleUrls: ["./additional-details.component.css"],
})
export class AdditionalDetailsComponent implements OnInit, DoCheck {
  data: IAdditionalDetailModel = {};
  isApplyingWithCoBorrower: boolean;
  borrower: IBorrowerModel = {};
  coBorrower: IBorrowerModel = {};
  personalInformation: IPersonalInformationModel = {};

  constructor(
    private _dataService: DataService,
    private _route: Router,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.borrower = this._dataService.loanApplication.personalInformation.borrower;
    this.coBorrower = this._dataService.loanApplication.personalInformation.coBorrower;
    this.personalInformation = this._dataService.loanApplication.personalInformation;
    this.data = this._dataService.loanApplication.additionalDetails;

    if (!this.data.nameOfIndividualsOnTitle) {
      this.data.nameOfIndividualsOnTitle = this.borrower.firstName ?? "";
      this.data.nameOfIndividualsOnTitle +=
        (this.data.nameOfIndividualsOnTitle ? " " : "") +
        (this.borrower.lastName ?? "");
    }

    if (
      this.personalInformation.isApplyingWithCoBorrower &&
      !this.data.nameOfIndividualsCoBorrowerOnTitle
    ) {
      this.data.nameOfIndividualsCoBorrowerOnTitle =
        this.coBorrower.firstName ?? "";
      this.data.nameOfIndividualsCoBorrowerOnTitle +=
        (this.data.nameOfIndividualsCoBorrowerOnTitle ? " " : "") +
        (this.coBorrower.lastName ?? "");
    }

    const loanApplication = this._dataService.loanApplication;
    this.isApplyingWithCoBorrower =
      loanApplication.personalInformation &&
      loanApplication.personalInformation.isApplyingWithCoBorrower;
  }

  ngDoCheck(): void {
    this._dataService.updateData(this.data, "additionalDetails");
  }

  proceedToNext() {
    // this._ngWizardService.next();
    this._activatedRoute.queryParams.subscribe(async (params) => {
      const id = params["id"];
      if (id) {
        this._route.navigate(["app/econsent"], {
          queryParams: {
            id: id,
          },
        });
      } else {
        this._route.navigate(["app/econsent"]);
      }
    });
  }

  proceedToPrevious() {
    this._activatedRoute.queryParams.subscribe(async (params) => {
      const id = params["id"];
      if (id) {
        this._route.navigate(["app/order-credit"], {
          queryParams: {
            id: id,
          },
        });
      } else {
        this._route.navigate(["app/order-credit"]);
      }
    });
  }
}
