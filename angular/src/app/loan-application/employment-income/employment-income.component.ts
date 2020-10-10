import { Component, DoCheck, OnInit } from "@angular/core";
import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { IEmploymentIncomeModel } from "../../interfaces/IEmploymentIncomeModel";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { Router } from "@angular/router";

@Component({
  selector: "app-employment-income",
  templateUrl: "./employment-income.component.html",
  styleUrls: ["./employment-income.component.css"],
})
export class EmploymentIncomeComponent implements OnInit, DoCheck {
  data: IEmploymentIncomeModel = {};

  form: FormGroup;
  states = [];
  incomeSources = [];
  isApplyingWithCoBorrower = false;

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _route: Router
  ) {}

  get borrowerEmploymentInfo(): FormArray {
    return this.form.get("borrowerEmploymentInfo") as FormArray;
  }

  get coBorrowerEmploymentInfo(): FormArray {
    return this.form.get("coBorrowerEmploymentInfo") as FormArray;
  }

  get additionalIncomes(): FormArray {
    return this.form.get("additionalIncomes") as FormArray;
  }

  getBorrowerEmpInfoFormGroup(index) {
    return this.borrowerEmploymentInfo.controls[index] as FormGroup;
  }

  getCoBorrowerEmpInfoFormGroup(index) {
    return this.coBorrowerEmploymentInfo.controls[index] as FormGroup;
  }

  ngOnInit(): void {
    this.data = this._dataService.loanApplication.employmentIncome;
    const loanApplication = this._dataService.loanApplication;
    this.isApplyingWithCoBorrower =
      loanApplication.personalInformation &&
      loanApplication.personalInformation.isApplyingWithCoBorrower;

    this.initForm();
    this.loadStates();
    this.loadIncomeSources();

    this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
      if (formData && formData.employmentIncome) {
        this.form.patchValue(formData.employmentIncome);
      }
    });
  }

  ngDoCheck() {
    this.data = this.form.value;
    this._dataService.updateValidationsFormArr(
      this.form.get("borrowerEmploymentInfo") as FormArray,
      "borrowerEmploymentIncome"
    );
    this._dataService.updateData(this.form.value, "employmentIncome");
  }

  loadStates() {
    this.states = [
      { id: 1, name: "AL" },
      { id: 2, name: "AK" },
      { id: 3, name: "AS" },
      { id: 4, name: "AZ" },
      { id: 5, name: "AR" },
      { id: 6, name: "CA" },
      { id: 7, name: "CO" },
      { id: 8, name: "CT" },
      { id: 9, name: "DE" },
      { id: 10, name: "DC" },
      { id: 11, name: "FM" },
      { id: 12, name: "FL" },
      { id: 13, name: "GA" },
      { id: 14, name: "GU" },
      { id: 15, name: "HI" },
      { id: 16, name: "ID" },
      { id: 17, name: "IL" },
      { id: 18, name: "IN" },
      { id: 19, name: "IA" },
      { id: 20, name: "KS" },
      { id: 21, name: "KY" },
      { id: 22, name: "LA" },
      { id: 23, name: "ME" },
      { id: 24, name: "MH" },
      { id: 25, name: "MD" },
      { id: 26, name: "MA" },
      { id: 27, name: "MI" },
      { id: 28, name: "MN" },
      { id: 29, name: "MS" },
      { id: 30, name: "MO" },
      { id: 31, name: "MT" },
      { id: 32, name: "NE" },
      { id: 33, name: "NV" },
      { id: 34, name: "NH" },
      { id: 35, name: "NJ" },
      { id: 36, name: "NM" },
      { id: 37, name: "NY" },
      { id: 38, name: "NC" },
      { id: 39, name: "ND" },
      { id: 40, name: "MP" },
      { id: 41, name: "OH" },
      { id: 42, name: "OK" },
      { id: 43, name: "OR" },
      { id: 44, name: "PW" },
      { id: 45, name: "PA" },
      { id: 46, name: "PR" },
      { id: 47, name: "RI" },
      { id: 48, name: "SC" },
      { id: 49, name: "SD" },
      { id: 50, name: "TN" },
      { id: 51, name: "TX" },
      { id: 52, name: "UT" },
      { id: 53, name: "VT" },
      { id: 54, name: "VI" },
      { id: 55, name: "VA" },
      { id: 56, name: "WA" },
      { id: 57, name: "WV" },
      { id: 58, name: "WI" },
      { id: 59, name: "WY" },
    ];
  }

  initForm() {
    this.form = new FormGroup({
      id: new FormControl(this.data.id),
      borrowerMonthlyIncome: this.initBorrowerMonthlyIncome(1),
      borrowerEmploymentInfo: new FormArray([]),
      additionalIncomes: new FormArray([]),
    });
    this.addBorrowerEmploymentInfo();

    this.addAdditionalIncome();
    this.addAdditionalIncome();
    this.addAdditionalIncome();

    if (this.isApplyingWithCoBorrower) {
      this.form.addControl("coBorrowerEmploymentInfo", new FormArray([]));
      this.form.addControl(
        "coBorrowerMonthlyIncome",
        this.initBorrowerMonthlyIncome(2)
      );
      this.addCoBorrowerEmploymentInfo();
    } else {
      this.form.removeControl("coBorrowerMonthlyIncome");
      this.form.removeControl("coBorrowerEmploymentInfo");
    }
  }

  initBorrowerMonthlyIncome(borrowerTypeId: number) {
    return new FormGroup({
      id: new FormControl(""),
      base: new FormControl(""),
      overtime: new FormControl(""),
      bonuses: new FormControl(""),
      commissions: new FormControl(""),
      dividends: new FormControl(""),
      borrowerTypeId: new FormControl(borrowerTypeId),
    });
  }

  newBorrowerEmploymentInfo(borrowerTypeId): FormGroup {
    return new FormGroup({
      id: new FormControl(""),
      isSelfEmployed: new FormControl(""),
      employerName: new FormControl("", [Validators.required]),
      position: new FormControl("", [Validators.required]),
      address1: new FormControl(""),
      address2: new FormControl(""),
      city: new FormControl(""),
      stateId: new FormControl(""),
      zipCode: new FormControl(""),
      startDate: new FormControl("", [Validators.required]),
      endDate: new FormControl(""),
      borrowerTypeId: new FormControl(borrowerTypeId),
    });
  }

  newAdditionalIncome(borrowerTypeId): FormGroup {
    return new FormGroup({
      id: new FormControl(""),
      borrowerTypeId: new FormControl(1),
      incomeSourceId: new FormControl(""),
      amount: new FormControl(""),
    });
  }

  addBorrowerEmploymentInfo() {
    this.borrowerEmploymentInfo.push(this.newBorrowerEmploymentInfo(1));
  }

  addCoBorrowerEmploymentInfo() {
    this.coBorrowerEmploymentInfo.push(this.newBorrowerEmploymentInfo(2));
  }

  addAdditionalIncome() {
    this.additionalIncomes.push(this.newAdditionalIncome(1));
  }

  clearEmploymentInfoForm($event, index) {
    $event.preventDefault();
    $event.stopPropagation();
    this.getBorrowerEmpInfoFormGroup(index).reset();
  }

  removeEmploymentInfoForm($event, index) {
    $event.preventDefault();
    $event.stopPropagation();
    this.borrowerEmploymentInfo.removeAt(index);
  }

  clearCoBorrowerEmploymentInfoForm($event, index) {
    $event.preventDefault();
    $event.stopPropagation();
    this.getCoBorrowerEmpInfoFormGroup(index).reset();
  }

  removeCoBorrowerEmploymentInfoForm($event, index) {
    $event.preventDefault();
    $event.stopPropagation();
    this.coBorrowerEmploymentInfo.removeAt(index);
  }

  loadIncomeSources() {
    this.incomeSources = [
      {
        id: 1,
        name: "Accessory Unit Income",
      },
      {
        id: 2,
        name: "Alimony/Child Support",
      },
      {
        id: 3,
        name: "Automobile/Expense Account",
      },
      {
        id: 4,
        name: "Boarder Income",
      },
    ];
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  proceedToNext() {
    if (this.form.valid) {
      // this._ngWizardService.next();
      this._route.navigate(["app/order-credit"]);
    } else {
      this.form.markAllAsTouched();
    }
  }

  proceedToPrevious() {
    // this._ngWizardService.previous();
    this._route.navigate(["app/asset"]);
  }
}
