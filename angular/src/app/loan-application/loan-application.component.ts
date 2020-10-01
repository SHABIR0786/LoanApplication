import {Component, OnInit} from '@angular/core';
import {NgWizardConfig, NgWizardService, THEME} from 'ng-wizard';
import {LoanApplicationService} from '../services/loan-application.service';
import {ILoanApplicationModel} from '../interfaces/ILoanApplicationModel';

@Component({
    selector: 'app-loan-application',
    templateUrl: './loan-application.component.html',
    styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent implements OnInit {
    [x: string]: any;

    loanApplication: ILoanApplicationModel = {
        loanDetails: {},
        personalInformation: {
            borrower: {},
            coBorrower: {},
        },
        expenses: {},
        employmentIncome: {
            borrowerMonthlyIncome: {},
            borrowerEmploymentInfo: [{}]
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

    config: NgWizardConfig = {
        selected: 0,
        theme: THEME.default,
        toolbarSettings: {
            toolbarExtraButtons: [
                {
                    text: 'Save', class: 'btn btn-info', event: () => {
                        const formData = this.sanitizeFormData();
                        this._loanApplicationService.post('Add', formData).subscribe((response: any) => {
                            this.loanApplication = this.prepareFormData(response.result);
                        }, error => {
                            console.log(error);
                        });
                    }
                }
            ]
        }
    };

    constructor(private ngWizardService: NgWizardService, private _loanApplicationService: LoanApplicationService
    ) {
    }

    ngOnInit(): void {
    }

    onChange(data, key) {
        this.loanApplication[key] = data;
        console.log(this.loanApplication);
    }

    sanitizeFormData() {
        const formData = Object.assign({}, this.loanApplication);
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
}
