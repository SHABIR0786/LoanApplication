import { PersonalInformationComponent } from "./../personal-information/personal-information.component";
import { Borrower } from "./../../../shared/service-proxies/service-proxies";
import { Component, DoCheck, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { NgWizardConfig, NgWizardService, THEME } from "ng-wizard";
import { IConsentModel } from "../../interfaces/IConsentModel";
import { IBorrowerModel } from "../../interfaces/IBorrowerModel";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
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
  selector: "app-econsent",
  templateUrl: "./econsent.component.html",
  styleUrls: ["./econsent.component.css"],
})
export class EconsentComponent implements OnInit, DoCheck {
  data: IConsentModel = {};
  borrower: IBorrowerModel = {};
  form: FormGroup;
  isApplyingWithCoBorrower: boolean;
  coBorrower: IBorrowerModel = {};
  personalInformation: IPersonalInformationModel = {};

  config: NgWizardConfig = {
    selected: 0,
    theme: THEME.default,
    anchorSettings: {
      markDoneStep: false,
      enableAllAnchors: true,
    },
    toolbarSettings: {
      showNextButton: false,
      showPreviousButton: false,
      toolbarExtraButtons: [],
    },
  };

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _route: Router
  ) {}

  ngOnInit(): void {
    this.data = this._dataService.loanApplication.eConsent;
    this.borrower = this._dataService.loanApplication.personalInformation.borrower;
    this.coBorrower = this._dataService.loanApplication.personalInformation.coBorrower;
    this.personalInformation = this._dataService.loanApplication.personalInformation;

    this.data.firstName = this.borrower.firstName;
    this.data.lastName = this.borrower.lastName;
    this.data.email = this.borrower.email;
    if (this.coBorrower) {
      this.data.CoborrowerFirstName = this.coBorrower.firstName;
      this.data.CoborrowerLastName = this.coBorrower.lastName;
      this.data.CoborrowerEmail = this.coBorrower.email;
    }

    this.initForm();

    this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
      if (formData && formData.eConsent) {
        this.form.patchValue(formData.eConsent);
      }
    });
    const loanApplication = this._dataService.loanApplication;
    this.isApplyingWithCoBorrower =
      loanApplication.personalInformation &&
      loanApplication.personalInformation.isApplyingWithCoBorrower;
    const consentDetail = this._dataService.loanApplication;
  }

  ngDoCheck() {
    this.data = this.form.value;
    this._dataService.updateData(this.form.value, "eConsent");
    this.personalInformation.borrower.firstName = this.data.firstName;
    this.personalInformation.borrower.lastName = this.data.lastName;
    this.personalInformation.borrower.email = this.data.email;
    if (this.coBorrower) {
      this.personalInformation.coBorrower.firstName = this.data.CoborrowerFirstName;
      this.personalInformation.coBorrower.lastName = this.data.CoborrowerLastName;
      this.personalInformation.coBorrower.email = this.data.CoborrowerEmail;
    }
    this._dataService.updateData(
      this.personalInformation,
      "personalInformation"
    );
  }

  initForm() {
    this.form = new FormGroup({
      id: new FormControl(this.data.id),
      agreeEConsent: new FormControl(this.data.agreeEConsent),
      firstName: new FormControl(this.data.firstName),
      lastName: new FormControl(this.data.lastName),
      email: new FormControl(this.data.email),
      CoborrowerAgreeEConsent: new FormControl(
        this.data.CoborrowerAgreeEConsent
      ),
      CoborrowerFirstName: new FormControl(this.data.CoborrowerFirstName),
      CoborrowerLastName: new FormControl(this.data.CoborrowerLastName),
      CoborrowerEmail: new FormControl(this.data.CoborrowerEmail),
      IamBorrowerCoBorrower: new FormControl(this.data.IamBorrowerCoBorrower),
    });
  }

  proceedToNext(event?: string, stepIndex?: number) {
    debugger;
    if (event === "wizardStep") {
      this._ngWizardService.next();
    } else {
      if (this.form.valid) {
        this._route.navigate(["app/declaration"]);
      } else {
        this.form.markAllAsTouched();
      }
    }
  }

  onChange(event, key) {
    this.coBorrower.lastName = this.data.CoborrowerLastName;
    this.coBorrower.firstName = this.data.CoborrowerFirstName;
    this.borrower.lastName = this.data.lastName;
    this.borrower.firstName = this.data.firstName;
  }
  proceedToPrevious(event?: string) {
    if (event === "wizardStep") {
      this._ngWizardService.previous();
    } else {
      this._route.navigate(["app/additional-detail"]);
    }
  }
}
