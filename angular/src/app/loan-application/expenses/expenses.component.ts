import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IExpenseModel} from '@app/interfaces/IExpenseModel';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';
import {ILoanApplicationModel} from '../../interfaces/ILoanApplicationModel';
import { Router } from '@angular/router';

@Component({
    selector: 'app-expenses',
    templateUrl: './expenses.component.html',
    styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit, DoCheck {

    data: IExpenseModel = {};

    form: FormGroup;

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService,
        private _route: Router,
    ) {
    }

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
        this._dataService.updateValidations(this.form, 'monthlyHousingExpenses');
        this._dataService.updateData(this.form.value, 'expenses');
    }

    initForm() {
        this.form = new FormGroup({
            id: new FormControl(this.data.id),
            isLiveWithFamilySelectRent: new FormControl(this.data.isLiveWithFamilySelectRent),
            rent: new FormControl(this.data.rent),
            otherHousingExpenses: new FormControl(this.data.otherHousingExpenses, [Validators.required]),
            firstMortgage: new FormControl(this.data.firstMortgage, [Validators.required]),
            secondMortgage: new FormControl(this.data.secondMortgage),
            hazardInsurance: new FormControl(this.data.hazardInsurance),
            realEstateTaxes: new FormControl(this.data.realEstateTaxes, [Validators.required]),
            mortgageInsurance: new FormControl(this.data.mortgageInsurance, [Validators.required]),
            homeOwnersAssociation: new FormControl(this.data.homeOwnersAssociation, [Validators.required])
        });
        debugger;
        this.form.get('isLiveWithFamilySelectRent').valueChanges.subscribe(isLiveWithFamilySelectRent => {
            if (isLiveWithFamilySelectRent === "true") {
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
        debugger;
        if (this.form.valid) {
            //this._ngWizardService.next();
            this._route.navigate(["app/asset"]);
        } else {
            this.form.markAllAsTouched();
        }
    }

    proceedToPrevious() {
        this._route.navigate(["app/personal-information"]);
       // this._ngWizardService.previous();
    }
}
