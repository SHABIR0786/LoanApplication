import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';
import {ILoanApplicationModel} from '../../interfaces/ILoanApplicationModel';
import {LoanApplicationService} from '../../services/loan-application.service';

@Component({
    selector: 'app-summary',
    templateUrl: './summary.component.html',
    styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

    @Output() proceedToStep: EventEmitter<any> = new EventEmitter<any>();
    errors = {};
    isShowAllStepsReadOnlyModeBool = false;
    formData: ILoanApplicationModel;

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService,
        private _loanApplicationService: LoanApplicationService,
    ) {
    }

    ngOnInit(): void {
        this._dataService.validations.subscribe(errors => {
            this.errors = errors;
        });
        this.formData = this._dataService.loanApplication;
    }

    sanitizeFormData(formData) {
        formData = Object.assign({}, formData);
        for (const key in formData) {
            if (formData.hasOwnProperty(key)) {
                if (typeof formData[key] === 'object' && Object.keys(formData[key]).length === 0) {
                    formData[key] = undefined;
                }
            }
        }
        return formData;
    }

    prepareFormData(response) {
        for (const key in response) {
            if (response.hasOwnProperty(key)) {
                response[key] = response[key] || {};
            }
        }
        return response;
    }

    submitForm() {
        const formData = this.sanitizeFormData(this._dataService.loanApplication);
        this._loanApplicationService.post('Add', formData).subscribe((response: any) => {
            this._dataService.loanApplication = this.prepareFormData(response.result);
        }, error => {
            console.log(error);
        });
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
        return false;
        // return Object.keys(this.errors).some(key => this.errors[key].length !== 0);
    }

    goToStep(index: number) {
        this.proceedToStep.emit(index - 1);
    }

    expandAll() {
        this.isShowAllStepsReadOnlyModeBool = true;
    }

    collapse() {
        this.isShowAllStepsReadOnlyModeBool = false;
    }
}
