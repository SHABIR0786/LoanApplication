import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IPersonalDetailModel} from '../../interfaces/IPersonalDetailModel';
import {IBorrowerModel} from '../../interfaces/IBorrowerModel';

@Component({
    selector: 'app-personal-information',
    templateUrl: './personal-information.component.html',
    styleUrls: ['./personal-information.component.css']
})
export class PersonalInformationComponent implements OnInit, DoCheck {

    @Input() data: IPersonalDetailModel = {
        borrower: {},
        coBorrower: {},
    };
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;

    constructor() {
    }

    ngOnInit(): void {
        this.initForm();
    }

    ngDoCheck() {
        this.data = this.form.value;
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    initForm() {
        this.form = new FormGroup({
            isApplyingWithCoBorrower: new FormControl(this.data.isApplyingWithCoBorrower, [Validators.required]),
            useIncomeOfPersonOtherThanBorrower: new FormControl(this.data.useIncomeOfPersonOtherThanBorrower, [Validators.required]),
            borrower: this.initBorrowerForm(this.data.borrower),
            coBorrower: this.initBorrowerForm(this.data.coBorrower)
        });

        this.form.get('isApplyingWithCoBorrower').valueChanges.subscribe(isApplyingWithCoBorrower => {
            debugger;
            if (isApplyingWithCoBorrower) {
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValidators([Validators.required]);
                // this.form.setControl('coBorrower', this.initBorrowerForm(this.data.coBorrower));
            } else {
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValue(null);
                this.form.get('useIncomeOfPersonOtherThanBorrower').setValidators(null);
                // this.form.removeControl('coBorrower');
            }
            this.form.get('useIncomeOfPersonOtherThanBorrower').updateValueAndValidity();
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

    onChange(event, key) {
        this.data[key] = event;
    }
}
