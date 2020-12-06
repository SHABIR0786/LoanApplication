import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { FormArray, FormGroup } from "@angular/forms";
import { ILoanApplicationModel } from "../interfaces/ILoanApplicationModel";
import { ActivatedRoute } from "@angular/router";
import { LoanApplicationService } from "./loan-application.service";
import { Result } from "common";

@Injectable()
export class DataService {
  errors = {};
  validationSource = new BehaviorSubject<any>(this.errors);
  validations = this.validationSource.asObservable();

  formDataSource = new BehaviorSubject<ILoanApplicationModel>({});
  formData = this.formDataSource.asObservable();

  loanApplication: ILoanApplicationModel = {
    loanDetails: {
      purposeOfLoan: 1,
    },
    personalInformation: {
      borrower: {},
      coBorrower: {},
      residentialAddress: {},
      mailingAddress: {},
      previousAddresses: [],
    },
    expenses: {},
    manualAssetEntries: [],
    employmentIncome: {
      borrowerMonthlyIncome: {},
      borrowerEmploymentInfo: [{}],
      coBorrowerMonthlyIncome: {},
      coBorrowerEmploymentInfo: [{}],
      additionalIncomes: [{}],
    },
    orderCredit: {},
    additionalDetails: {},
    eConsent: {},
    declaration: {
      borrowerDeclaration: {},
      coBorrowerDeclaration: {},
      borrowerDemographic: {},
      coBorrowerDemographic: {},
    },
  };

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _loanApplicationService: LoanApplicationService
  ) {
    this._activatedRoute.queryParams.subscribe((params) => {
      const id = params["id"];
      if (id) {
        this._loanApplicationService.get(`Get?id=${id}`).subscribe(
          (response: Result<ILoanApplicationModel>) => {
            if (response.success) {
              debugger;
              this.loanApplication = response.result;
              if (!this.loanApplication.declaration) {
                if (!this.loanApplication.declaration.borrowerDeclaration)
                  this.loanApplication.declaration.borrowerDeclaration = {};
              }
              console.log(this.loanApplication);
            }
          },
          (error) => {
            console.log(error);
          }
        );
      }
    });
  }

  updateValidations(formGroup: FormGroup, formName: string) {
    if (formGroup) {
      this.errors[formName] = Object.keys(formGroup.controls)
        .map((key) => ({
          controlName: key,
          error: formGroup.controls[key].errors !== null,
        }))
        .filter((error) => error.error);
      this.validationSource.next(this.errors);
    }
  }

  updateValidationsFormArr(formArray: FormArray, formName: string) {
    if (formArray && formArray.length) {
      const arr = formArray.controls.map((formGroup: FormGroup) => {
        return Object.keys(formGroup.controls)
          .map((key) => ({
            controlName: key,
            error: formGroup.controls[key].errors !== null,
          }))
          .filter((error) => error.error);
      });
      this.errors[formName] = [].concat.apply([], arr);
      this.validationSource.next(this.errors);
    }
  }

  updateFormData(formData: ILoanApplicationModel) {
    debugger;
    this.formDataSource.next(formData);
  }

  updateData(data, key) {
    this.loanApplication[key] = data;
  }
}
