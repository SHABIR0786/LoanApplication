import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IExpenseModel} from '@app/interfaces/IExpenseModel';
import {NgWizardService} from 'ng-wizard';

@Component({
    selector: 'app-expenses',
    templateUrl: './expenses.component.html',
    styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit, DoCheck {

    @Input() data: IExpenseModel = {};
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;

    constructor(private _ngWizardService: NgWizardService) {
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
            isLiveWithFamilySelectRent: new FormControl(this.data.isLiveWithFamilySelectRent),
            rent: new FormControl(this.data.rent, [Validators.required]),
            otherHousingExpenses: new FormControl(this.data.otherHousingExpenses, [Validators.required]),
            firstMortgage: new FormControl(this.data.firstMortgage, [Validators.required]),
            secondMortgage: new FormControl(this.data.secondMortgage),
            hazardInsurance: new FormControl(this.data.hazardInsurance),
            realEstateTaxes: new FormControl(this.data.realEstateTaxes, [Validators.required]),
            mortgageInsurance: new FormControl(this.data.mortgageInsurance, [Validators.required]),
            homeOwnersAssociation: new FormControl(this.data.homeOwnersAssociation, [Validators.required])
        });

        this.form.get('isLiveWithFamilySelectRent').valueChanges.subscribe(isLiveWithFamilySelectRent => {
            if (isLiveWithFamilySelectRent) {
                this.form.get('rent').setValidators([Validators.required]);

                this.form.get('firstMortgage').setValue(null);
                this.form.get('firstMortgage').setValidators(null);
                this.form.get('realEstateTaxes').setValue(null);
                this.form.get('realEstateTaxes').setValidators(null);
                this.form.get('mortgageInsurance').setValue(null);
                this.form.get('mortgageInsurance').setValidators(null);
                this.form.get('homeOwnersAssociation').setValue(null);
                this.form.get('homeOwnersAssociation').setValidators(null);

                this.form.get('secondMortgage').setValue(null);
                this.form.get('hazardInsurance').setValue(null);

            } else {
                this.form.get('rent').setValue(null);
                this.form.get('rent').setValidators(null);

                this.form.get('firstMortgage').setValidators([Validators.required]);
                this.form.get('realEstateTaxes').setValidators([Validators.required]);
                this.form.get('mortgageInsurance').setValidators([Validators.required]);
                this.form.get('homeOwnersAssociation').setValidators([Validators.required]);
            }
            this.form.get('rent').updateValueAndValidity();
            this.form.get('firstMortgage').updateValueAndValidity();
            this.form.get('realEstateTaxes').updateValueAndValidity();
            this.form.get('mortgageInsurance').updateValueAndValidity();
            this.form.get('homeOwnersAssociation').updateValueAndValidity();
        });
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
