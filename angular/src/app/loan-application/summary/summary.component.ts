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
    errors: string[] = [];

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
                return this.errors.some((error: any) => fields.includes(error.controlName));
            case 'propertyDetails':
                fields = [
                    'stateId',
                    'propertyTypeId',
                    'propertyUseId',
                ];
                return this.errors.some((error: any) => fields.includes(error.controlName));
        }

        return false;
    }
}
