import {
  Component,
  DoCheck,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IExpenseModel } from "@app/interfaces/IExpenseModel";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { LoanApplicationService } from "../../services/loan-application.service";

@Component({
  selector: "app-expenses",
  templateUrl: "./expenses.component.html",
  styleUrls: ["./expenses.component.css"],
})
export class ExpensesComponent implements OnInit, DoCheck {
  data: IExpenseModel = {};

  form: FormGroup;

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _route: Router,
    private _activatedRoute: ActivatedRoute,
    private _loanApplicationService: LoanApplicationService
  ) {}

  ngOnInit(): void {
    this.data = this._dataService.loanApplication.expenses;

    this.initForm();

    this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
      if (formData && formData.expenses) {
        this.form.patchValue(formData.expenses);
      }
    });
  }

  ngDoCheck() {
    this.data = this.form.value;
    this._dataService.updateValidations(this.form, "monthlyHousingExpenses");
    this._dataService.updateData(this.form.value, "expenses");
  }

  initForm() {
    this.form = new FormGroup({
      id: new FormControl(this.data.id),
      isLiveWithFamilySelectRent: new FormControl(
        this.data.isLiveWithFamilySelectRent
      ),
      rent: new FormControl(this.data.rent),
      otherHousingExpenses: new FormControl(this.data.otherHousingExpenses, [
        Validators.required,
      ]),
      firstMortgage: new FormControl(this.data.firstMortgage, [
        Validators.required,
      ]),
      secondMortgage: new FormControl(this.data.secondMortgage),
      hazardInsurance: new FormControl(this.data.hazardInsurance),
      realEstateTaxes: new FormControl(this.data.realEstateTaxes, [
        Validators.required,
      ]),
      mortgageInsurance: new FormControl(this.data.mortgageInsurance, [
        Validators.required,
      ]),
      homeOwnersAssociation: new FormControl(this.data.homeOwnersAssociation, [
        Validators.required,
      ]),
    });
    this.form
      .get("isLiveWithFamilySelectRent")
      .valueChanges.subscribe((isLiveWithFamilySelectRent) => {
        if (isLiveWithFamilySelectRent === "true") {
          this.form.get("rent").setValidators([Validators.required]);

          this.form.get("firstMortgage").setValue(null);
          this.form.get("firstMortgage").setValidators(null);
          this.form.get("realEstateTaxes").setValue(null);
          this.form.get("realEstateTaxes").setValidators(null);
          this.form.get("mortgageInsurance").setValue(null);
          this.form.get("mortgageInsurance").setValidators(null);
          this.form.get("homeOwnersAssociation").setValue(null);
          this.form.get("homeOwnersAssociation").setValidators(null);

          this.form.get("secondMortgage").setValue(null);
          this.form.get("hazardInsurance").setValue(null);
        } else {
          this.form.get("rent").setValue(null);
          this.form.get("rent").setValidators(null);

          this.form.get("firstMortgage").setValidators([Validators.required]);
          this.form.get("realEstateTaxes").setValidators([Validators.required]);
          this.form
            .get("mortgageInsurance")
            .setValidators([Validators.required]);
          this.form
            .get("homeOwnersAssociation")
            .setValidators([Validators.required]);
        }
        this.form.get("rent").updateValueAndValidity();
        this.form.get("firstMortgage").updateValueAndValidity();
        this.form.get("realEstateTaxes").updateValueAndValidity();
        this.form.get("mortgageInsurance").updateValueAndValidity();
        this.form.get("homeOwnersAssociation").updateValueAndValidity();
      });
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
    if (this.form.valid) {
      //this._ngWizardService.next();
      this._activatedRoute.queryParams.subscribe(async (params) => {
        const id = params["id"];
        if (id) {
          this._route.navigate(["app/asset"], {
            queryParams: {
              id: id,
            },
          });
        } else {
          this._route.navigate(["app/asset"]);
        }
      });
    } else {
      this.form.markAllAsTouched();
    }
  }

  proceedToPrevious() {
    this._activatedRoute.queryParams.subscribe(async (params) => {
      const id = params["id"];
      if (id) {
        this._route.navigate(["app/personal-information"], {
          queryParams: {
            id: id,
          },
        });
      } else {
        this._route.navigate(["app/personal-information"]);
      }
    });
    // this._ngWizardService.previous();
  }
}
