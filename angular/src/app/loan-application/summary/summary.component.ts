import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { LoanApplicationService } from "../../services/loan-application.service";
import { Router } from "@angular/router";
import { AppConsts } from "@shared/AppConsts";

@Component({
  selector: "app-summary",
  templateUrl: "./summary.component.html",
  styleUrls: ["./summary.component.css"],
})
export class SummaryComponent implements OnInit {
  @Output() proceedToStep: EventEmitter<any> = new EventEmitter<any>();
  errors = {};
  isShowAllStepsReadOnlyModeBool = false;
  formData: ILoanApplicationModel;
  isApplyingWithCoBorrower: boolean = false;

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _loanApplicationService: LoanApplicationService,
    private _route: Router
  ) {}

  ngOnInit(): void {
    this._dataService.validations.subscribe((errors) => {
      this.errors = errors;
    });
    this.formData = this._dataService.loanApplication;
    this.isApplyingWithCoBorrower =
      this.formData.personalInformation &&
      this.formData.personalInformation.isApplyingWithCoBorrower;
    if (!this.isApplyingWithCoBorrower) {
      if (this.formData.manualAssetEntries) {
        this.formData.manualAssetEntries.forEach((element) => {
          element.borrowerTypeId = AppConsts.typeBorrower;
        });
      }
      if (
        this.formData.employmentIncome &&
        this.formData.employmentIncome.coBorrowerEmploymentInfo
      ) {
        this.formData.employmentIncome.coBorrowerEmploymentInfo = [{}];
      }
      if (
        this.formData.additionalDetails &&
        this.formData.additionalDetails.nameOfIndividualsCoBorrowerOnTitle
      ) {
        this.formData.additionalDetails.nameOfIndividualsCoBorrowerOnTitle = "";
      }
      if (
        this.formData.employmentIncome &&
        this.formData.employmentIncome.coBorrowerMonthlyIncome
      ) {
        this.formData.employmentIncome.coBorrowerMonthlyIncome = {};
      }
      if (
        this.formData.declaration &&
        this.formData.declaration.coBorrowerDeclaration
      ) {
        this.formData.declaration.coBorrowerDeclaration = {};
      }
      if (
        this.formData.declaration &&
        this.formData.declaration.coBorrowerDemographic
      ) {
        this.formData.declaration.coBorrowerDemographic = {};
      }
    }
    console.log(this.formData);
  }

  sanitizeFormData(formData) {
    formData = Object.assign({}, formData);
    for (const key in formData) {
      if (formData.hasOwnProperty(key)) {
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

  prepareFormData(response) {
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        response[key] = response[key] || {};
      }
    }
    return response;
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

  proceedToPrevious() {
    //  this._ngWizardService.previous();
    this._route.navigate(["app/declaration"]);
  }

  showGroupError(groupName) {
    let fields = [];
    switch (groupName) {
      case "purposeOfLoan":
        fields = [
          "isWorkingWithOfficer",
          "loanOfficerId",
          "purposeOfLoan",
          "requestedLoanAmount",
          "estimatedPurchasePrice",
          "downPaymentAmount",
          "sourceOfDownPayment",
        ];
        return (this.errors["loanDetails"] || []).some((error: any) =>
          fields.includes(error.controlName)
        );
      case "propertyDetails":
        fields = ["stateId", "propertyTypeId", "propertyUseId"];
        return (this.errors["loanDetails"] || []).some((error: any) =>
          fields.includes(error.controlName)
        );
      case "jointCredit":
        fields = [
          "isApplyingWithCoBorrower",
          "useIncomeOfPersonOtherThanBorrower",
        ];
        return (this.errors["jointCredit"] || []).some((error: any) =>
          fields.includes(error.controlName)
        );
      case "borrowerPersonalInformation":
        return (this.errors["borrowerPersonalInformation"] || []).length;
      case "residentialAddress":
        return (this.errors["residentialAddress"] || []).length;
      case "monthlyHousingExpenses":
        return (this.errors["monthlyHousingExpenses"] || []).length;
      case "borrowerEmploymentIncome":
        return (this.errors["borrowerEmploymentIncome"] || []).length;
    }

    return false;
  }

  hasAnyErrors() {
    return false;
    // return Object.keys(this.errors).some(key => this.errors[key].length !== 0);
  }

  goToStep(index: string) {
    //this.proceedToStep.emit(index - 1);
    this._route.navigate([index]);
  }

  expandAll() {
    this.isShowAllStepsReadOnlyModeBool = true;
  }

  collapse() {
    this.isShowAllStepsReadOnlyModeBool = false;
  }

  ConvertToInt(val) {
    return parseInt(val);
  }
}
