import {
  Component,
  DoCheck,
  EventEmitter,
  Input,
  OnInit,
  Output,
  SimpleChanges,
} from "@angular/core";
import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { IPersonalInformationModel } from "../../interfaces/IPersonalInformationModel";
import { IBorrowerModel } from "../../interfaces/IBorrowerModel";
import { IAddressModel } from "../../interfaces/IAddressModel";
import { NgWizardService } from "ng-wizard";
import { DataService } from "../../services/data.service";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";

@Component({
  selector: "app-personal-information",
  templateUrl: "./personal-information.component.html",
  styleUrls: ["./personal-information.component.css"],
})
export class PersonalInformationComponent implements OnInit, DoCheck {
  @Input() data: IPersonalInformationModel = {
    borrower: {},
    coBorrower: {},
    residentialAddress: {},
    mailingAddress: {},
    previousAddresses: [],
  };
  @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

  form: FormGroup;
  states = [];

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService
  ) {}

  get residentialAddressForm(): FormGroup {
    return this.form.get("residentialAddress") as FormGroup;
  }

  get previousAddressesFormArray(): FormArray {
    return this.form.get("previousAddresses") as FormArray;
  }

  getPreviousAddressForm(index): FormGroup {
    return this.previousAddressesFormArray.controls[index] as FormGroup;
  }

  addPreviousAddress() {
    this.previousAddressesFormArray.push(this.initAddressForm({}, 3, true));
  }

  ngOnInit(): void {
    this.initForm();
    this.loadStates();

    this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
      if (formData && formData.personalInformation) {
        this.form.patchValue(formData.personalInformation);
      }
    });
  }

  ngDoCheck() {
    this.data = this.form.value;
    this._dataService.updateValidations(this.form, "jointCredit");
    this._dataService.updateValidations(
      this.form.get("borrower") as FormGroup,
      "borrowerPersonalInformation"
    );
    this._dataService.updateValidations(
      this.form.get("residentialAddress") as FormGroup,
      "residentialAddress"
    );
    this._dataService.updateValidations(
      this.form.get("mailingAddress") as FormGroup,
      "mailingAddress"
    );
   
      this.onDataChange.next(this.form.value);
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
      isApplyingWithCoBorrower: new FormControl(
        this.data.isApplyingWithCoBorrower,
        [Validators.required]
      ),
      useIncomeOfPersonOtherThanBorrower: new FormControl(
        this.data.useIncomeOfPersonOtherThanBorrower,
        [Validators.required]
      ),
      agreePrivacyPolicy: new FormControl(this.data.agreePrivacyPolicy, [
        Validators.required,
      ]),
      borrower: this.initBorrowerForm(this.data.borrower),
      coBorrower: this.initBorrowerForm(this.data.coBorrower),
      isMailingAddressSameAsResidential: new FormControl(
        this.data.isMailingAddressSameAsResidential
      ),
      residentialAddress: this.initAddressForm(
        this.data.residentialAddress,
        1,
        true
      ),
      mailingAddress: this.initAddressForm(this.data.mailingAddress, 2, false),
      previousAddresses: new FormArray([]),
    });

    this.form
      .get("isApplyingWithCoBorrower")
      .valueChanges.subscribe((isApplyingWithCoBorrower) => {
        if (isApplyingWithCoBorrower) {
          this.form
            .get("useIncomeOfPersonOtherThanBorrower")
            .setValidators([Validators.required]);

          this.data.coBorrower = {};
          this.form.setControl(
            "coBorrower",
            this.initBorrowerForm(this.data.coBorrower)
          );
        } else {
          this.form.get("useIncomeOfPersonOtherThanBorrower").setValue(null);
          this.form
            .get("useIncomeOfPersonOtherThanBorrower")
            .setValidators(null);

          this.form.removeControl("coBorrower");
        }
        this.form
          .get("useIncomeOfPersonOtherThanBorrower")
          .updateValueAndValidity();
      });

    this.form
      .get("isMailingAddressSameAsResidential")
      .valueChanges.subscribe((isMailingAddressSameAsResidential) => {
        if (isMailingAddressSameAsResidential) {
          this.form.removeControl("mailingAddress");
        } else {
          this.data.mailingAddress = {};
          this.form.addControl(
            "mailingAddress",
            this.initAddressForm(this.data.mailingAddress, 2, false)
          );
        }
      });
  }

  initBorrowerForm(data: IBorrowerModel) {
    return new FormGroup({
      id: new FormControl(data.id),
      firstName: new FormControl(data.firstName, [Validators.required]),
      middleInitial: new FormControl(data.middleInitial),
      lastName: new FormControl(data.lastName, [Validators.required]),
      suffix: new FormControl(data.suffix),
      email: new FormControl(data.email, [Validators.required]),
      dateOfBirth: new FormControl(data.dateOfBirth, [Validators.required]),
      socialSecurityNumber: new FormControl(data.socialSecurityNumber, [
        Validators.required,
      ]),
      maritalStatusId: new FormControl(data.maritalStatusId, [
        Validators.required,
      ]),
      numberOfDependents: new FormControl(data.numberOfDependents),
      cellPhone: new FormControl(data.cellPhone, [Validators.required]),
      homePhone: new FormControl(data.homePhone),
    });
  }

  initAddressForm(
    data: IAddressModel,
    addressTypeId: number,
    required: boolean
  ) {
    return new FormGroup({
      id: new FormControl(data.id),
      addressLine1: new FormControl(
        data.addressLine1,
        required ? [Validators.required] : []
      ),
      addressLine2: new FormControl(data.addressLine2),
      city: new FormControl(data.city, required ? [Validators.required] : []),
      stateId: new FormControl(
        data.stateId,
        required ? [Validators.required] : []
      ),
      zipCode: new FormControl(
        data.zipCode,
        required ? [Validators.required] : []
      ),
      totalYears: new FormControl(
        data.totalYears,
        required ? [Validators.required] : []
      ),
      totalMonths: new FormControl(data.totalMonths),
    });
  }

  onChange(event, key) {
    this.data[key] = event;
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  proceedToNext() {
    if (this.form.valid) {
      this._ngWizardService.next();
    } else {
      this.form.markAllAsTouched();
    }
  }

  proceedToPrevious() {
    this._ngWizardService.previous();
  }
}
