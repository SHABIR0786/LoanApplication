import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ILoanDetailModel} from '../../interfaces/ILoanDetailModel';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';

@Component({
    selector: 'app-loan-details',
    templateUrl: './loan-details.component.html',
    styleUrls: ['./loan-details.component.css']
})
export class LoanDetailsComponent implements OnInit, DoCheck {

    id = Math.random().toString(36).substring(2);
    @Input() data: ILoanDetailModel = {
        purposeOfLoan: 1
    };
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;
    states = [];
    loanPurposes = [];
    sourceOfDownPayments = [];
    propertyTypes = [];
    propertyUses = [];
    loanOfficers = [];

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService
    ) {
    }

    ngOnInit(): void {
        this.initForm();
        this.loadStates();
        this.loadLoanPurposes();
        this.loadSourceOfDownPayments();
        this.loadPropertyTypes();
        this.loadPropertyUses();
        this.loadLoanOfficers();
    }

    ngDoCheck() {
        this.data = this.form.value;
        this._dataService.updateValidations(this.form);
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    initForm() {
        this.form = new FormGroup({
            referredBy: new FormControl(this.data.referredBy),
            isWorkingWithOfficer: new FormControl(this.data.isWorkingWithOfficer, [Validators.required]),
            loanOfficerId: new FormControl(this.data.loanOfficerId, [Validators.required]),
            purposeOfLoan: new FormControl(this.data.purposeOfLoan, [Validators.required]),
            estimatedValue: new FormControl(this.data.estimatedValue),
            currentLoanAmount: new FormControl(this.data.currentLoanAmount),
            requestedLoanAmount: new FormControl(this.data.requestedLoanAmount, [Validators.required]),
            estimatedPurchasePrice: new FormControl(this.data.estimatedPurchasePrice, [Validators.required]),
            downPaymentAmount: new FormControl(this.data.downPaymentAmount, [Validators.required]),
            downPaymentPercentage: new FormControl(this.data.downPaymentPercentage),
            sourceOfDownPayment: new FormControl(this.data.sourceOfDownPayment, [Validators.required]),
            giftAmount: new FormControl(this.data.giftAmount),
            giftExplanation: new FormControl(this.data.giftExplanation),
            haveSecondMortgage: new FormControl(this.data.haveSecondMortgage),
            secondMortgageAmount: new FormControl(this.data.secondMortgageAmount),
            payLoanWithNewLoan: new FormControl(this.data.payLoanWithNewLoan),

            startedLookingForNewHome: new FormControl(this.data.startedLookingForNewHome),
            refinancingCurrentHome: new FormControl(this.data.refinancingCurrentHome),
            yearAcquired: new FormControl(this.data.yearAcquired, [
                Validators.pattern('^\\d{4}$'),
                Validators.min(1900),
                Validators.max(new Date().getFullYear()),
            ]),
            originalPrice: new FormControl(this.data.originalPrice),
            city: new FormControl(this.data.city),
            stateId: new FormControl(this.data.stateId, [Validators.required]),
            propertyTypeId: new FormControl(this.data.propertyTypeId, [Validators.required]),
            propertyUseId: new FormControl(this.data.propertyUseId, [Validators.required]),
        });

        const estimatedPurchasePriceControl = this.form.get('estimatedPurchasePrice');
        const downPaymentAmountControl = this.form.get('downPaymentAmount');
        const sourceOfDownPaymentControl = this.form.get('sourceOfDownPayment');
        const downPaymentPercentage = this.form.get('downPaymentPercentage');

        const requestedLoanAmount = this.form.get('requestedLoanAmount');

        const startedLookingForNewHome = this.form.get('startedLookingForNewHome');

        this.form.get('purposeOfLoan').valueChanges.subscribe(purposeOfLoan => {

            if (purposeOfLoan === 1) {
                estimatedPurchasePriceControl.setValidators([Validators.required]);
                downPaymentAmountControl.setValidators([Validators.required]);
                sourceOfDownPaymentControl.setValidators([Validators.required]);
                startedLookingForNewHome.setValidators([Validators.required]);

                requestedLoanAmount.setValue(null);
                requestedLoanAmount.setValidators(null);
            }

            if (purposeOfLoan === 2 || purposeOfLoan === 3) {
                estimatedPurchasePriceControl.setValue(null);
                estimatedPurchasePriceControl.setValidators(null);
                downPaymentAmountControl.setValue(null);
                downPaymentAmountControl.setValidators(null);
                sourceOfDownPaymentControl.setValue(null);
                sourceOfDownPaymentControl.setValidators(null);
                downPaymentPercentage.setValue(null);
                startedLookingForNewHome.setValidators(null);
                startedLookingForNewHome.setValue(null);

                requestedLoanAmount.setValidators([Validators.required]);
            }

            estimatedPurchasePriceControl.updateValueAndValidity();
            downPaymentAmountControl.updateValueAndValidity();
            sourceOfDownPaymentControl.updateValueAndValidity();
            requestedLoanAmount.updateValueAndValidity();
            startedLookingForNewHome.updateValueAndValidity();
        });

        this.form.get('haveSecondMortgage').valueChanges.subscribe(haveSecondMortgage => {
            if (!haveSecondMortgage) {
                this.form.get('secondMortgageAmount').setValue(null);
                this.form.get('payLoanWithNewLoan').setValue(null);
            }
        });

        this.form.get('sourceOfDownPayment').valueChanges.subscribe(sourceOfDownPayment => {
            if (sourceOfDownPayment !== 4) {
                this.form.get('giftAmount').setValue(null);
                this.form.get('giftExplanation').setValue(null);
            }
        });

        this.form.get('isWorkingWithOfficer').valueChanges.subscribe(isWorkingWithOfficer => {
            if (isWorkingWithOfficer) {
                this.form.get('loanOfficerId').setValidators([Validators.required]);
            } else {
                this.form.get('loanOfficerId').setValue(null);
                this.form.get('loanOfficerId').setValidators(null);
            }
            this.form.get('loanOfficerId').updateValueAndValidity();
        });
    }

    proceedToNext() {
        if (this.form.valid) {
            this._ngWizardService.next();
        } else {
            this.form.markAllAsTouched();
        }
    }

    loadLoanPurposes() {
        this.loanPurposes = [
            {
                id: 1,
                name: 'Purchase a Home'
            },
            {
                id: 2,
                name: 'No Cash-Out Refinance'
            },
            {
                id: 3,
                name: 'Cash-Out Refinance'
            },
        ];
    }

    loadStates() {
        this.states = [
            {
                id: 1,
                name: 'CA'
            }
        ];
    }

    loadPropertyTypes() {
        this.propertyTypes = [
            {
                id: 1,
                name: 'Single Family Residence'
            },
            {
                id: 2,
                name: 'Condominium'
            },
            {
                id: 3,
                name: '2+ Units'
            },
            {
                id: 4,
                name: 'Co Operative'
            },
        ];
    }

    loadPropertyUses() {
        this.propertyUses = [
            {
                id: 1,
                name: 'Primary Home'
            },
            {
                id: 2,
                name: 'Vacation Home'
            },
            {
                id: 3,
                name: 'Investment Home'
            }
        ];
    }

    loadLoanOfficers() {
        this.loanOfficers = [
            {
                id: 1,
                name: 'John Doe'
            }
        ];
    }

    loadSourceOfDownPayments() {
        this.sourceOfDownPayments = [
            {
                id: 1,
                name: 'Checking/Savings'
            },
            {
                id: 2,
                name: 'Equity on Pending Sale'
            },
            {
                id: 3,
                name: 'Equity on Sold Property'
            },
            {
                id: 4,
                name: 'Gift Funds'
            },
            {
                id: 5,
                name: 'Retirement Funds'
            },
            {
                id: 6,
                name: 'Secured Borrowed Funds'
            },
            {
                id: 7,
                name: 'Stocks and Bonds'
            },
            {
                id: 8,
                name: 'Trust Funds'
            },
        ];
    }
}
