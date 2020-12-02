//import { PersonalInformationComponent } from './../personal-information/personal-information.component';
import { IBorrowerModel } from "./../../interfaces/IBorrowerModel";
//import { Borrower } from './../../../shared/service-proxies/service-proxies';
import { Component, DoCheck, OnInit } from "@angular/core";
import { DataService } from "../../services/data.service";
import { IAdditionalDetailModel } from "../../interfaces/IAdditionalDetailModel";
import { Router } from "@angular/router";
import { IPersonalInformationModel } from "@app/interfaces/IPersonalInformationModel";

import { createStore } from "redux";
function todos(state = [], action) {
  switch (action.type) {
    case "ADD_TODO":
      return state.concat([action.text]);
    default:
      return state;
  }
}
const store = createStore(todos, ["Use Redux"]);

function select(state) {
  return state.some.deep.property;
}

let currentValue;
function handleChange() {
  let previousValue = currentValue;
  currentValue = select(store.getState());

  if (previousValue !== currentValue) {
    console.log(
      "Some deep nested property changed from",
      previousValue,
      "to",
      currentValue
    );
  }
}

const unsubscribe = store.subscribe(handleChange);
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

  constructor(private _dataService: DataService, private _route: Router) {}

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
    this._route.navigate(["app/econsent"]);
  }

  proceedToPrevious() {
    // this._ngWizardService.previous();
    this._route.navigate(["app/order-credit"]);
  }
}
