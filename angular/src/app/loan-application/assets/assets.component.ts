import { Component, DoCheck, OnInit } from "@angular/core";
import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { IAssetModel } from "../../interfaces/IAssetModel";
import { Router } from "@angular/router";
import { AppConsts } from "@shared/AppConsts";
import { ActivatedRoute } from "@angular/router";
import { LoanApplicationService } from "../../services/loan-application.service";
import { Result } from "common";

@Component({
  selector: "app-assets",
  templateUrl: "./assets.component.html",
  styleUrls: ["./assets.component.css"],
})
export class AssetsComponent implements OnInit, DoCheck {
  id = Math.random().toString(36).substring(2);
  data: IAssetModel[] = [];

  form: FormGroup;
  states = [];
  assetTypes = [];
  borrowerTypeIds = [];
  propertyStatuses = [];
  propertyIsUsedAsArr = [];
  propertyTypes = [];
  isApplyingWithCoBorrower: boolean = false;

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _route: Router,
    private _activatedRoute: ActivatedRoute,
    private _loanApplicationService: LoanApplicationService
  ) {}

  get manualAssetEntries(): FormArray {
    return this.form.get("manualAssetEntries") as FormArray;
  }

  ngOnInit(): void {
    const response: Result<ILoanApplicationModel> = this._activatedRoute
      .snapshot.data.loanApp;

    if (response && response.success) {
      this._dataService.loanApplication = response.result;

      this.data = this._dataService.loanApplication.manualAssetEntries;
      const loanApplication = this._dataService.loanApplication;
      this.isApplyingWithCoBorrower =
        loanApplication.personalInformation &&
        loanApplication.personalInformation.isApplyingWithCoBorrower;

      if (loanApplication.manualAssetEntries) {
        if (!this.isApplyingWithCoBorrower) {
          loanApplication.manualAssetEntries.forEach((element) => {
            element.borrowerTypeId = AppConsts.typeBorrower;
          });
        }
      }

      this._dataService.formData.subscribe(
        (formData: ILoanApplicationModel) => {
          if (formData && formData.manualAssetEntries) {
            this.form.patchValue({
              manualAssetEntries: formData.manualAssetEntries,
            });
          }
        }
      );
    }

    this.initForm();
    this.loadStates();
    this.loadAssetTypes();
    this.loadBelongsTo();
    this.loadPropertyStatuses();
    this.loadPropertyIsUsedAs();
    this.loadPropertyTypes();
  }

  ngDoCheck() {
    this.data = this.form.value.manualAssetEntries;
    this._dataService.updateValidations(this.form, "manualAssetEntries");
    this._dataService.updateData(
      this.form.value.manualAssetEntries,
      "manualAssetEntries"
    );
  }

  initForm() {
    this.form = new FormGroup({
      manualAssetEntries: new FormArray(
        this.data.map((d) => this.initAssetForm(d || {}))
      ),
    });
  }

  addAsset() {
    if (this.isApplyingWithCoBorrower) {
      this.manualAssetEntries.push(this.initAssetForm({ assetTypeId: 1 }));
    } else {
      this.manualAssetEntries.push(
        this.initAssetForm({
          assetTypeId: 1,
          borrowerTypeId: AppConsts.typeBorrower,
        })
      );
    }
  }

  removeAsset(index) {
    this.manualAssetEntries.removeAt(index);
  }

  initAssetForm(data: IAssetModel = {}) {
    const form = new FormGroup({
      id: new FormControl(data.id),
      assetTypeId: new FormControl(data.assetTypeId),
      borrowerTypeId: new FormControl(data.borrowerTypeId),
      name: new FormControl(data.name),
      bankName: new FormControl(data.bankName),
      description: new FormControl(data.description),
      accountNumber: new FormControl(data.accountNumber),
      cashValue: new FormControl(data.cashValue),
      address: new FormControl(data.address),
      address2: new FormControl(data.address2),
      city: new FormControl(data.city),
      stateId: new FormControl(data.stateId),
      zipCode: new FormControl(data.zipCode),
      propertyStatus: new FormControl(data.propertyStatus),
      propertyIsUsedAs: new FormControl(data.propertyIsUsedAs),
      propertyType: new FormControl(data.propertyType),
      presentMarketValue: new FormControl(data.presentMarketValue),
      outstandingMortgageBalance: new FormControl(
        data.outstandingMortgageBalance
      ),
      monthlyMortgagePayment: new FormControl(data.monthlyMortgagePayment),
      purchasePrice: new FormControl(data.purchasePrice),
      grossRentalIncome: new FormControl(data.grossRentalIncome),
      taxesInsuranceAndOther: new FormControl(data.taxesInsuranceAndOther),
      stockAndBonds: new FormArray(
        (data.stockAndBonds || []).map((d) => this.initStockAndBond(d || {}))
      ),
    });

    form.get("assetTypeId").valueChanges.subscribe((id) => {
      if (id === 12) {
        const control = form.get("stockAndBonds") as FormArray;
        if (!control.length) {
          control.push(this.initStockAndBond({}));
          control.push(this.initStockAndBond({}));
          control.push(this.initStockAndBond({}));
        }
      } else {
        form.get("stockAndBonds").patchValue([]);
        form.get("description").setValue(null);
        form.get("bankName").setValue(null);
        form.get("accountNumber").setValue(null);
        form.get("cashValue").setValue(null);
        form.get("address").setValue(null);
        form.get("address2").setValue(null);
        form.get("city").setValue(null);
        form.get("stateId").setValue(null);
        form.get("zipCode").setValue(null);
        form.get("propertyStatus").setValue(null);
        form.get("propertyIsUsedAs").setValue(null);
        form.get("propertyType").setValue(null);
        form.get("presentMarketValue").setValue(null);
        form.get("outstandingMortgageBalance").setValue(null);
        form.get("monthlyMortgagePayment").setValue(null);
        form.get("purchasePrice").setValue(null);
        form.get("purchasePrice").setValue(null);
        form.get("grossRentalIncome").setValue(null);
        form.get("taxesInsuranceAndOther").setValue(null);
      }
    });

    return form;
  }

  initStockAndBond(data: any = {}) {
    return new FormGroup({
      id: new FormControl(data.id),
      companyName: new FormControl(data.companyName),
      accountNumber: new FormControl(data.accountNumber),
      value: new FormControl(data.value),
    });
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

  loadAssetTypes() {
    this.assetTypes = [
      {
        id: 1,
        name: "Cash Deposit on sales contract",
      },
      {
        id: 2,
        name: "Certificate of Deposit",
      },
      {
        id: 3,
        name: "Checking Account",
      },
      {
        id: 4,
        name: "Gifts",
      },
      {
        id: 5,
        name: "Gift of equity",
      },
      {
        id: 6,
        name: "Money Market Fund",
      },
      {
        id: 7,
        name: "Mutual Funds",
      },
      {
        id: 8,
        name: "Net Proceed from Real Estate Funds",
      },
      {
        id: 9,
        name: "Real Estate Owned",
      },
      {
        id: 10,
        name: "Retirement Funds",
      },
      {
        id: 11,
        name: "Saving Accounts",
      },
      {
        id: 12,
        name: "Stock and Bonds",
      },
      {
        id: 13,
        name: "Trust Account",
      },
    ];
  }

  loadBelongsTo() {
    this.borrowerTypeIds = [
      {
        id: 1,
        name: "Borrower",
      },
      {
        id: 2,
        name: "Co-Borrower",
      },
      {
        id: 3,
        name: "Both",
      },
    ];
  }

  loadPropertyStatuses() {
    this.propertyStatuses = [];
  }

  loadPropertyIsUsedAs() {
    this.propertyIsUsedAsArr = [];
  }

  loadPropertyTypes() {
    this.propertyTypes = [];
  }

  getAssetTypeById(assetTypeId) {
    const data = this.assetTypes.find((type) => type.id === assetTypeId);
    return data ? data.name : null;
  }

  trackByFn(index: any, item: any) {
    return index;
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
    this.submitForm();
    this._activatedRoute.queryParams.subscribe(async (params) => {
      if (this.form.valid) {
        const id = params["id"];
        if (id) {
          this._route.navigate(["app/employment-income"], {
            queryParams: {
              id: id,
            },
          });
        } else {
          this._route.navigate(["app/employment-income"]);
        }
      } else {
        this.form.markAllAsTouched();
      }
    });
  }

  proceedToPrevious() {
    this.submitForm();
    this._activatedRoute.queryParams.subscribe(async (params) => {
      if (this.form.valid) {
        const id = params["id"];
        if (id) {
          this._route.navigate(["app/expense"], {
            queryParams: {
              id: id,
            },
          });
        } else {
          this._route.navigate(["app/expense"]);
        }
      } else {
        this.form.markAllAsTouched();
      }
    });
  }
}
