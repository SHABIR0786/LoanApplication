import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {IEmploymentIncomeModel} from '../../interfaces/IEmploymentIncomeModel';

@Component({
    selector: 'app-employment-income',
    templateUrl: './employment-income.component.html',
    styleUrls: ['./employment-income.component.css']
})
export class EmploymentIncomeComponent implements OnInit, DoCheck {

    @Input() data: IEmploymentIncomeModel = {};
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;
    states = [];
    incomeSources = [];
    private _isApplyingWithCoBorrower = false;

    constructor() {
    }

    @Input() set isApplyingWithCoBorrower(value: boolean) {
        this._isApplyingWithCoBorrower = value;
        if (this.form) {
            if (value) {
                this.form.addControl('coBorrowerEmploymentInfo', new FormArray([]));
                this.form.addControl('coBorrowerMonthlyIncome', this.initBorrowerMonthlyIncome(2));
                this.addCoBorrowerEmploymentInfo();
            } else {
                this.form.removeControl('coBorrowerMonthlyIncome');
                this.form.removeControl('coBorrowerEmploymentInfo');
            }
        }
    }

    get isApplyingWithCoBorrower(): boolean {
        return this._isApplyingWithCoBorrower;
    }

    get borrowerEmploymentInfo(): FormArray {
        return this.form.get('borrowerEmploymentInfo') as FormArray;
    }

    get coBorrowerEmploymentInfo(): FormArray {
        return this.form.get('coBorrowerEmploymentInfo') as FormArray;
    }

    get additionalIncomes(): FormArray {
        return this.form.get('additionalIncomes') as FormArray;
    }

    getBorrowerEmpInfoFormGroup(index) {
        return this.borrowerEmploymentInfo.controls[index] as FormGroup;
    }

    getCoBorrowerEmpInfoFormGroup(index) {
        return this.coBorrowerEmploymentInfo.controls[index] as FormGroup;
    }

    ngOnInit(): void {
        this.initForm();
        this.loadStates();
        this.loadIncomeSources();
    }

    ngDoCheck() {
        this.data = this.form.value;
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    loadStates() {
        this.states = [
            {
                id: 1,
                name: 'CA'
            }
        ];
    }

    initForm() {
        this.form = new FormGroup({
            borrowerMonthlyIncome: this.initBorrowerMonthlyIncome(1),
            borrowerEmploymentInfo: new FormArray([]),
            additionalIncomes: new FormArray([]),
        });
        this.addBorrowerEmploymentInfo();

        this.addAdditionalIncome();
        this.addAdditionalIncome();
        this.addAdditionalIncome();

        this.form.valueChanges.subscribe(data => {
            if (this.form.valid) {
                this.onDataChange.next(this.form.value);
            }
        });
    }

    initBorrowerMonthlyIncome(borrowerTypeId: number) {
        return new FormGroup({
            base: new FormControl(''),
            overtime: new FormControl(''),
            bonuses: new FormControl(''),
            commissions: new FormControl(''),
            dividends: new FormControl(''),
            borrowerTypeId: new FormControl(borrowerTypeId),
        });
    }

    newBorrowerEmploymentInfo(borrowerTypeId): FormGroup {
        return new FormGroup({
            isSelfEmployed: new FormControl(''),
            employerName: new FormControl('', [Validators.required]),
            position: new FormControl('', [Validators.required]),
            address1: new FormControl(''),
            address2: new FormControl(''),
            city: new FormControl(''),
            stateId: new FormControl(''),
            zipCode: new FormControl(''),
            startDate: new FormControl('', [Validators.required]),
            endDate: new FormControl(''),
            borrowerTypeId: new FormControl(borrowerTypeId),
        });
    }

    newAdditionalIncome(borrowerTypeId): FormGroup {
        return new FormGroup({
            borrowerTypeId: new FormControl(1),
            incomeSourceId: new FormControl(''),
            amount: new FormControl(''),
        });
    }

    addBorrowerEmploymentInfo() {
        this.borrowerEmploymentInfo.push(this.newBorrowerEmploymentInfo(1));
    }

    addCoBorrowerEmploymentInfo() {
        this.coBorrowerEmploymentInfo.push(this.newBorrowerEmploymentInfo(2));
    }

    addAdditionalIncome() {
        this.additionalIncomes.push(this.newAdditionalIncome(1));
    }

    clearEmploymentInfoForm($event, index) {
        $event.preventDefault();
        $event.stopPropagation();
        this.getBorrowerEmpInfoFormGroup(index).reset();
    }

    removeEmploymentInfoForm($event, index) {
        $event.preventDefault();
        $event.stopPropagation();
        this.borrowerEmploymentInfo.removeAt(index);
    }

    clearCoBorrowerEmploymentInfoForm($event, index) {
        $event.preventDefault();
        $event.stopPropagation();
        this.getCoBorrowerEmpInfoFormGroup(index).reset();
    }

    removeCoBorrowerEmploymentInfoForm($event, index) {
        $event.preventDefault();
        $event.stopPropagation();
        this.coBorrowerEmploymentInfo.removeAt(index);
    }

    loadIncomeSources() {
        this.incomeSources = [
            {
                id: 1,
                name: 'Accessory Unit Income'
            },
            {
                id: 2,
                name: 'Alimony/Child Support'
            },
            {
                id: 3,
                name: 'Automobile/Expense Account'
            },
            {
                id: 4,
                name: 'Boarder Income'
            },
        ];
    }

    trackByFn(index: any, item: any) {
        return index;
    }
}
