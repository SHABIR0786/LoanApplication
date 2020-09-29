import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {IEmploymentIncomeModel} from '../../interfaces/IEmploymentIncomeModel';

@Component({
    selector: 'app-employment-income',
    templateUrl: './employment-income.component.html',
    styleUrls: ['./employment-income.component.css']
})
export class EmploymentIncomeComponent implements OnInit, DoCheck {

    @Input() data: IEmploymentIncomeModel = {
        borrowerEmploymentInfo: []
    };
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;

    constructor() {
    }

    ngOnInit(): void {
        this.initForm();
        this.data.borrowerEmploymentInfo.push({employerName: 'Folio3'});
    }

    ngDoCheck() {
        this.data = this.form.value;
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }


    initForm() {
        console.log(this.data);
        this.form = new FormGroup({
            // isLiveWithFamilySelectRent: new FormControl(this.data.isLiveWithFamilySelectRent),
            // rent: new FormControl(this.data.rent, [Validators.required]),
            // otherHousingExpenses: new FormControl(this.data.otherHousingExpenses, [Validators.required]),
            // firstMortgage: new FormControl(this.data.firstMortgage, [Validators.required]),
            // secondMortgage: new FormControl(this.data.secondMortgage),
            // hazardInsurance: new FormControl(this.data.hazardInsurance),
            // realEstateTaxes: new FormControl(this.data.realEstateTaxes, [Validators.required]),
            // mortgageInsurance: new FormControl(this.data.mortgageInsurance, [Validators.required]),
            // homeOwnersAssociation: new FormControl(this.data.homeOwnersAssociation, [Validators.required])
        });
    }
}
