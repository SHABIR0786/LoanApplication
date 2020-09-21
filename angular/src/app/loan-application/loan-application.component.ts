import {Component, OnInit} from '@angular/core';
import {BorrowerEmploymentInformationServiceProxy, BorrowerInformationServiceProxy} from '@shared/service-proxies/service-proxies';
import {NgWizardConfig, NgWizardService, StepChangedArgs, THEME} from 'ng-wizard';
import {LoanApplicationService} from '../services/loan-application.service';

@Component({
    selector: 'app-loan-application',
    templateUrl: './loan-application.component.html',
    styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent implements OnInit {
    [x: string]: any;

    loanApplication: any = {
        id: undefined,
        mortgageType: {},
        propertyInformation: {},
        borrowerInformation: {},
        coBorrowerInformation: {},

        borrowerEmploymentInformation1: {},
        borrowerEmploymentInformation2: {},
        borrowerEmploymentInformation3: {},

        coBorrowerEmploymentInformation1: {},
        coBorrowerEmploymentInformation2: {},
        coBorrowerEmploymentInformation3: {},

        grossMonthlyIncomeBorrower: {},
        grossMonthlyIncomeCoBorrower: {},
        combinedMonthlyHousingExpensePresent: {},
        combinedMonthlyHousingExpenseProposed: {},
        grossMonthlyTotal: {}
    };

    config: NgWizardConfig = {
        selected: 0,
        theme: THEME.default,
        toolbarSettings: {
            toolbarExtraButtons: [
                {
                    text: 'Save', class: 'btn btn-info', event: () => {
                        const formData = Object.assign({}, this.loanApplication);

                        console.log(formData);

                        for (const key in formData) {
                            if (formData.hasOwnProperty(key)) {
                                if (typeof formData[key] === 'object' && Object.keys(formData[key]).length === 0) {
                                    formData[key] = undefined;
                                }
                            }
                        }

                        this._loanApplicationService.post('Add', formData).subscribe((response: any) => {
                            console.log(response);
                            this.loanApplication.id = response.result.id;
                        }, error => {
                            console.log(error);
                        });
                    }
                }
            ]
        }
    };

    constructor(private ngWizardService: NgWizardService,
                private _borrowerInformationService: BorrowerInformationServiceProxy,
                private _borrowerEmploymentInformationService: BorrowerEmploymentInformationServiceProxy,
                private _loanApplicationService: LoanApplicationService
    ) {
    }

    ngOnInit(): void {
    }

    showPreviousStep(event?: Event) {
        this.ngWizardService.previous();
    }

    showNextStep(event?: Event) {
        this.ngWizardService.next();
    }

    resetWizard(event?: Event) {
        this.ngWizardService.reset();
    }

    setTheme(theme: THEME) {
        this.ngWizardService.theme(theme);
    }

    stepChanged(args: StepChangedArgs) {
        console.log(args.step);
    }

    finish() {
        this.loanApplication.borrowerInformation.tenantId = this.appSession.tenantId;
        this.loanApplication.coBorrowerInformation.tenantId = this.appSession.tenantId;
        this._borrowerInformationService.createOrUpdate(this.loanApplication.borrowerInformation)
            .subscribe((result) => {
                if (result) {

                }
            });

        this._borrowerInformationService.createOrUpdate(this.loanApplication.coBorrowerInformation)
            .subscribe((result) => {
                if (result) {

                }
            });

        this.loanApplication.borrowerEmploymentinfromation.tenantId = this.appSession.tenantId;
        this.loanApplication.coBorrowerEmploymentinfromation.tenantId = this.appSession.tenantId;


        this._borrowerEmploymentInformationService.createOrUpdate(this.loanApplication.borrowerEmploymentinfromation)
            .subscribe((result) => {
                if (result) {

                }
            });

        this._borrowerEmploymentInformationService.createOrUpdate(this.loanApplication.coBorrowerEmploymentinfromation)
            .subscribe((result) => {
                if (result) {

                }
            });
    }

    onBorrowerChange(data) {
        this.loanApplication.borrowerInformation = data;
    }

    onCoBorrowerChange(data) {
        this.loanApplication.coBorrowerInformation = data;
    }

    onEmploymentInfoChange(data) {
        this.loanApplication.borrowerEmploymentInformation = data;
    }

    onChange(prop, data) {
        this.loanApplication[prop] = data;
    }
}
