import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';

@Component({
    selector: 'app-summary',
    templateUrl: './summary.component.html',
    styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

    @Output() onSubmit: EventEmitter<any> = new EventEmitter<any>();
    @Output() proceedToStep: EventEmitter<any> = new EventEmitter<any>();
    errors = {};

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService
    ) {
    }

    ngOnInit(): void {
        this._dataService.validations.subscribe(errors => {
            this.errors = errors;
        });
    }

    submitForm() {
        this.onSubmit.emit();
    }

    proceedToPrevious() {
        this._ngWizardService.previous();
    }

    showGroupError(groupName) {
        let fields = [];
        switch (groupName) {
            case 'purposeOfLoan':
                fields = [
                    'isWorkingWithOfficer',
                    'loanOfficerId',
                    'purposeOfLoan',
                    'requestedLoanAmount',
                    'estimatedPurchasePrice',
                    'downPaymentAmount',
                    'sourceOfDownPayment',
                ];
                return (this.errors['loanDetails'] || []).some((error: any) => fields.includes(error.controlName));
            case 'propertyDetails':
                fields = [
                    'stateId',
                    'propertyTypeId',
                    'propertyUseId',
                ];
                return (this.errors['loanDetails'] || []).some((error: any) => fields.includes(error.controlName));
            case 'jointCredit':
                fields = [
                    'isApplyingWithCoBorrower',
                    'useIncomeOfPersonOtherThanBorrower',
                ];
                return (this.errors['jointCredit'] || []).some((error: any) => fields.includes(error.controlName));
            case 'borrowerPersonalInformation':
                return (this.errors['borrowerPersonalInformation'] || []).length;
            case 'residentialAddress':
                return (this.errors['residentialAddress'] || []).length;
            case 'monthlyHousingExpenses':
                return (this.errors['monthlyHousingExpenses'] || []).length;
            case 'borrowerEmploymentIncome':
                return (this.errors['borrowerEmploymentIncome'] || []).length;
        }

        return false;
    }

    hasAnyErrors() {
        // return false;
        return Object.keys(this.errors).some(key => this.errors[key].length !== 0);
    }

    goToStep(index: number) {
        this.proceedToStep.emit(index - 1);
    }
}
