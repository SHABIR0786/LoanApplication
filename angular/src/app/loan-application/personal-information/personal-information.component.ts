import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {IPersonalInformationModel} from '../../interfaces/IPersonalInformationModel';
import {IBorrowerModel} from '../../interfaces/IBorrowerModel';
import {IAddressModel} from '../../interfaces/IAddressModel';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';

@Component({
    selector: 'app-personal-information',
    templateUrl: './personal-information.component.html',
    styleUrls: ['./personal-information.component.css']
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
    ) {
    }

    get residentialAddressForm(): FormGroup {
        return this.form.get('residentialAddress') as FormGroup;
    }

    get previousAddressesFormArray(): FormArray {
        return this.form.get('previousAddresses') as FormArray;
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
    }

    ngDoCheck() {
        this.data = this.form.value;
        this._dataService.updateValidations(this.form, 'jointCredit');
        this._dataService.updateValidations(this.form.get('borrower') as FormGroup, 'borrowerPersonalInformation');
        this._dataService.updateValidations(this.form.get('residentialAddress') as FormGroup, 'residentialAddress');
        this._dataService.updateValidations(this.form.get('mailingAddress') as FormGroup, 'mailingAddress');
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    loadStates() {
        this.states = [
            {
                id: 1,
                name: 'CA'
            }
        ];
    }

    initForm() {
        this.form = new FormGroup({
            isApplyingWithCoBorrower: new FormControl(this.data.isApplyingWithCoBorrower, [Validators.required]),
            useIncomeOfPersonOtherThanBorrower: new FormControl(this.data.useIncomeOfPersonOtherThanBorrower, [Validators.required]),
            agreePrivacyPolicy: new FormControl(this.data.agreePrivacyPolicy, [Validators.required]),
            borrower: this.initBorrowerForm(this.data.borrower),
            coBorrower: this.initBorrowerForm(this.data.coBorrower),
            isMailingAddressSameAsResidential: new FormControl(this.data.isMailingAddressSameAsResidential),
            residentialAddress: this.initAddressForm(this.data.residentialAddress, 1, true),
            mailingAddress: this.initAddressForm(this.data.mailingAddress, 2, false),
            previousAddresses: new FormArray([]),
        });

        this.form.get('isApplyingWithCoBorrower').valueChanges.subscribe(isApplyingWithCoBorrower => {
            if (isApplyingWithCoBorrower) {
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValidators([Validators.required]);

                this.data.coBorrower = {};
                this.form.setControl('coBorrower', this.initBorrowerForm(this.data.coBorrower));
            } else {
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValue(null);
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValidators(null);

                this.form.removeControl('coBorrower');
            }
            this.form.get('useIncomeOfPersonOtherThanBorrower').updateValueAndValidity();
        });

        this.form.get('isMailingAddressSameAsResidential').valueChanges.subscribe(isMailingAddressSameAsResidential => {
            if (isMailingAddressSameAsResidential) {
                this.form.removeControl('mailingAddress');
            } else {
                this.data.mailingAddress = {};
                this.form.addControl('mailingAddress', this.initAddressForm(this.data.mailingAddress, 2, false));
            }
        });
    }

    initBorrowerForm(data: IBorrowerModel) {
        return new FormGroup({
            firstName: new FormControl(data.firstName, [Validators.required]),
            middleInitial: new FormControl(data.middleInitial),
            lastName: new FormControl(data.lastName, [Validators.required]),
            suffix: new FormControl(data.suffix),
            email: new FormControl(data.email, [Validators.required]),
            dateOfBirth: new FormControl(data.dateOfBirth, [Validators.required]),
            socialSecurityNumber: new FormControl(data.socialSecurityNumber, [Validators.required]),
            maritalStatusId: new FormControl(data.maritalStatusId, [Validators.required]),
            numberOfDependents: new FormControl(data.numberOfDependents),
            cellPhone: new FormControl(data.cellPhone, [Validators.required]),
            homePhone: new FormControl(data.homePhone),
        });
    }

    initAddressForm(data: IAddressModel, addressTypeId: number, required: boolean) {
        return new FormGroup({
            addressLine1: new FormControl(data.addressLine1, required ? [Validators.required] : []),
            addressLine2: new FormControl(data.addressLine2,),
            city: new FormControl(data.city, required ? [Validators.required] : []),
            stateId: new FormControl(data.stateId, required ? [Validators.required] : []),
            zipCode: new FormControl(data.zipCode, required ? [Validators.required] : []),
            totalYears: new FormControl(data.totalYears, required ? [Validators.required] : []),
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
