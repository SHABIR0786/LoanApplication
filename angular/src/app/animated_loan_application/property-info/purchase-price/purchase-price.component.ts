import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data.service";
import { LoanApplicationService } from "../../../services/loan-application.service";
import { ILoanApplicationModel } from "../../../interfaces/ILoanApplicationModel";
import { Result } from "common";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ILoanDetailModel } from "../../../interfaces/ILoanDetailModel";

@Component({
  selector: "app-purchase-price",
  templateUrl: "./purchase-price.component.html",
  styleUrls: ["./purchase-price.component.css"],
})
export class PurchasePriceComponent implements OnInit {
  data: ILoanDetailModel = {};
  form: FormGroup;

  constructor(
    private _route: Router,
    private _dataService: DataService,
    private _loanApplicationService: LoanApplicationService,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const response: Result<ILoanApplicationModel> = this._activatedRoute
      .snapshot.data.loanApp;
    if (response && response.success) {
      this._dataService.loanApplication = response.result;
      this.data = response.result.loanDetails;
      if (this.form) this.form.patchValue(response.result.loanDetails);
    }
    this.initForm();
  }

  initForm() {
    this.form = new FormGroup({
      estimatedPurchasePrice: new FormControl(
        this.data.estimatedPurchasePrice,
        [Validators.required]
      ),
      downPaymentAmount: new FormControl(this.data.downPaymentAmount, [
        Validators.required,
      ]),
      downPaymentPercentage: new FormControl(this.data.downPaymentPercentage, [
        Validators.required,
      ]),
      estimatedAnnualTaxes: new FormControl(this.data.estimatedAnnualTaxes, [
        Validators.required,
      ]),
      estimatedAnnualHomeInsurance: new FormControl(
        this.data.estimatedAnnualHomeInsurance,
        [Validators.required]
      ),
    });
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
    this._loanApplicationService
      .post<Result<ILoanApplicationModel>>("Add", formData)
      .subscribe(
        (response) => {
          this._dataService.loanApplication = response.result;
          this.form.patchValue(this._dataService.loanApplication.loanDetails);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  proceedToNext() {
    let fields = [
      "estimatedPurchasePrice",
      "downPaymentAmount",
      "downPaymentPercentage",
      "estimatedAnnualTaxes",
      "estimatedAnnualHomeInsurance",
    ];
    const hasError = fields.some(
      (field) => this.form.get(field) && !this.form.get(field).valid
    );

    if (hasError) {
      fields.forEach(
        (field) => this.form.get(field) && this.form.get(field).markAsTouched()
      );
    } else {
      this._dataService.loanApplication.loanDetails = this.data;
      this.submitForm();
      this._activatedRoute.queryParams.subscribe(async (params) => {
        const id = params["id"];
        if (id) {
          this._route.navigate(["app/property-info/credit-score"], {
            queryParams: {
              id: id,
            },
          });
        }
      });
    }
  }
}
