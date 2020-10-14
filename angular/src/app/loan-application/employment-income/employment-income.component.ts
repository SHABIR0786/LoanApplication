import { Component, DoCheck, OnInit } from "@angular/core";
import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { IEmploymentIncomeModel } from "../../interfaces/IEmploymentIncomeModel";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { Router } from "@angular/router";
import { IBorrowerMonthlyIncomeModel } from "../../interfaces/IBorrowerMonthlyIncomeModel";
import { IBorrowerEmploymentInfoModel } from "../../interfaces/IBorrowerEmploymentInfoModel";
import { IAdditionalIncomeModel } from "../../interfaces/IAdditionalIncomeModel";

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

    for (
      let index = 0;
      index < this.data.borrowerEmploymentInfo.length;
      index++
    ) {
      const borrowerEmploymentInfo = this.data.borrowerEmploymentInfo[index];
      borrowerEmploymentInfo.stateIdName = this.getDataById(
        this.states,
        borrowerEmploymentInfo.stateId
      );
    }

    if (this.isApplyingWithCoBorrower)
      for (
        let index = 0;
        index < this.data.coBorrowerEmploymentInfo.length;
        index++
      ) {
        const coBorrowerEmploymentInfo = this.data.coBorrowerEmploymentInfo[
          index
        ];
        coBorrowerEmploymentInfo.stateIdName = this.getDataById(
          this.states,
          coBorrowerEmploymentInfo.stateId
        );
      }

    for (let index = 0; index < this.data.additionalIncomes.length; index++) {
      const additionalIncomes = this.data.additionalIncomes[index];
      additionalIncomes.incomeSourceIdName = this.getDataById(
        this.incomeSources,
        additionalIncomes.incomeSourceId
      );
    }
  }

  getDataById(arr, id) {
    const data = (arr || []).find((i) => i.id === id);
    return data ? data.name : null;
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
      borrowerMonthlyIncome: this.initBorrowerMonthlyIncome(
        this.data.borrowerMonthlyIncome || { borrowerTypeId: 1 }
      ),
      borrowerEmploymentInfo: new FormArray([]),
      additionalIncomes: new FormArray([]),
    });

    if (
      this.data.borrowerEmploymentInfo &&
      this.data.borrowerEmploymentInfo.length
    ) {
      this.data.borrowerEmploymentInfo.forEach((d) =>
        this.addBorrowerEmploymentInfo(d)
      );
    } else {
      this.addBorrowerEmploymentInfo();
    }

    if (this.data.additionalIncomes && this.data.additionalIncomes.length) {
      this.data.additionalIncomes.forEach((d) => this.addAdditionalIncome(d));
    } else {
      this.addAdditionalIncome();
      this.addAdditionalIncome();
      this.addAdditionalIncome();
    }

    if (this.isApplyingWithCoBorrower) {
      this.form.addControl("coBorrowerEmploymentInfo", new FormArray([]));
      this.form.addControl(
        "coBorrowerMonthlyIncome",
        this.initBorrowerMonthlyIncome(
          this.data.coBorrowerMonthlyIncome || { borrowerTypeId: 2 }
        )
      );

      if (
        this.data.coBorrowerEmploymentInfo &&
        this.data.coBorrowerEmploymentInfo.length
      ) {
        this.data.coBorrowerEmploymentInfo.forEach((d) =>
          this.addCoBorrowerEmploymentInfo(d)
        );
      } else {
        this.addCoBorrowerEmploymentInfo();
      }
    } else {
      this.form.removeControl("coBorrowerMonthlyIncome");
      this.form.removeControl("coBorrowerEmploymentInfo");
    }
  }

  initBorrowerMonthlyIncome(data: IBorrowerMonthlyIncomeModel) {
    return new FormGroup({
      id: new FormControl(data.id),
      base: new FormControl(data.base),
      overtime: new FormControl(data.overtime),
      bonuses: new FormControl(data.bonuses),
      commissions: new FormControl(data.commissions),
      dividends: new FormControl(data.dividends),
      borrowerTypeId: new FormControl(data.borrowerTypeId),
    });
  }

  newBorrowerEmploymentInfo(data: IBorrowerEmploymentInfoModel): FormGroup {
    return new FormGroup({
      id: new FormControl(data.id),
      isSelfEmployed: new FormControl(data.isSelfEmployed),
      employerName: new FormControl(data.employerName, [Validators.required]),
      position: new FormControl(data.position, [Validators.required]),
      address1: new FormControl(data.address1),
      address2: new FormControl(data.address2),
      city: new FormControl(data.city),
      stateId: new FormControl(data.stateId),
      zipCode: new FormControl(data.zipCode),
      startDate: new FormControl(data.startDate, [Validators.required]),
      endDate: new FormControl(data.endDate),
      borrowerTypeId: new FormControl(data.borrowerTypeId),
    });
  }

  newAdditionalIncome(data?: IAdditionalIncomeModel): FormGroup {
    return new FormGroup({
      id: new FormControl(data.id),
      borrowerTypeId: new FormControl(data.borrowerTypeId),
      incomeSourceId: new FormControl(data.incomeSourceId),
      amount: new FormControl(data.amount),
    });
  }

  addBorrowerEmploymentInfo(data?: IBorrowerEmploymentInfoModel) {
    this.borrowerEmploymentInfo.push(
      this.newBorrowerEmploymentInfo(data || { borrowerTypeId: 1 })
    );
  }

  addCoBorrowerEmploymentInfo(data?: IBorrowerEmploymentInfoModel) {
    this.coBorrowerEmploymentInfo.push(
      this.newBorrowerEmploymentInfo(data || { borrowerTypeId: 2 })
    );
  }

  addAdditionalIncome(data?: IAdditionalIncomeModel) {
    this.additionalIncomes.push(
      this.newAdditionalIncome(data || { borrowerTypeId: 1 })
    );
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
