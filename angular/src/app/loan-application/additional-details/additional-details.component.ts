//import { PersonalInformationComponent } from './../personal-information/personal-information.component';
import { IBorrowerModel } from "./../../interfaces/IBorrowerModel";
//import { Borrower } from './../../../shared/service-proxies/service-proxies';
import { Component, DoCheck, OnInit } from "@angular/core";
import { DataService } from "../../services/data.service";
import { IAdditionalDetailModel } from "../../interfaces/IAdditionalDetailModel";
import { Router } from "@angular/router";
import { IPersonalInformationModel } from "@app/interfaces/IPersonalInformationModel";
import { ActivatedRoute } from "@angular/router";
import { LoanApplicationService } from "../../services/loan-application.service";

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
    private _activatedRoute: ActivatedRoute,
    private _loanApplicationService: LoanApplicationService
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

  prepareFormData(response) {
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        response[key] = response[key] || {};
      }
    }
    return response;
  }
  sanitizeFormData(formData) {
    formData = Object.assign({}, formData);

    this._activatedRoute.queryParams.subscribe(async (params) => {
      formData.id = params["id"];
    });
    for (const key in formData) {
      if (key && formData.hasOwnProperty(key) && formData[key]) {
        if (
          typeof formData[key] === "object" &&
          Object.keys(formData[key]).length === 0
        ) {
          formData[key] = undefined;
        }
      }
    }
    return formData;
  }
  submitForm() {
    const formData = this.sanitizeFormData(this._dataService.loanApplication);

    this._loanApplicationService.post("Add", formData).subscribe(
      (response: any) => {
        this._dataService.loanApplication = this.prepareFormData(
          response.result
        );
      },
      (error) => {
        console.log(error);
      }
    );
  }
  proceedToNext() {
    // this._ngWizardService.next();
    this.submitForm();
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
    this.submitForm();
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
