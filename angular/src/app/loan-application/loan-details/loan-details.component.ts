import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ILoanDetailModel} from '../../interfaces/ILoanDetailModel';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
    selector: 'app-loan-details',
    templateUrl: './loan-details.component.html',
    styleUrls: ['./loan-details.component.css']
})
export class LoanDetailsComponent implements OnInit, DoCheck {

    id = Math.random().toString(36).substring(2);
    @Input() heading = 'Borrower';
    @Input() data: ILoanDetailModel = {
        purposeOfLoan: 1
    };
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;
    loanPurposes = [];
    sourceOfDownPayments = [];

    constructor() {
    }

    ngOnInit(): void {
        this.initForm();
        this.loadLoanPurposes();
        this.loadSourceOfDownPayments();
    }

    ngDoCheck() {
        this.data = this.form.value;
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    initForm() {
        this.form = new FormGroup({
            referredBy: new FormControl(this.data.referredBy),
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

            refinancingCurrentHome: new FormControl(this.data.refinancingCurrentHome),
            yearAcquired: new FormControl(this.data.yearAcquired),
            originalPrice: new FormControl(this.data.originalPrice),
            city: new FormControl(this.data.city),
            stateId: new FormControl(this.data.stateId),
            propertyTypeId: new FormControl(this.data.propertyTypeId),
            propertyUseId: new FormControl(this.data.propertyUseId),
        });

        const estimatedPurchasePriceControl = this.form.get('estimatedPurchasePrice');
        const downPaymentAmountControl = this.form.get('downPaymentAmount');
        const sourceOfDownPaymentControl = this.form.get('sourceOfDownPayment');
        const downPaymentPercentage = this.form.get('downPaymentPercentage');

        const requestedLoanAmount = this.form.get('requestedLoanAmount');

        this.form.get('purposeOfLoan').valueChanges.subscribe(purposeOfLoan => {

            if (purposeOfLoan === 1) {
                estimatedPurchasePriceControl.setValidators([Validators.required]);
                downPaymentAmountControl.setValidators([Validators.required]);
                sourceOfDownPaymentControl.setValidators([Validators.required]);

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

                requestedLoanAmount.setValidators([Validators.required]);
            }

            estimatedPurchasePriceControl.updateValueAndValidity();
            downPaymentAmountControl.updateValueAndValidity();
            sourceOfDownPaymentControl.updateValueAndValidity();
            requestedLoanAmount.updateValueAndValidity();
        });
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
