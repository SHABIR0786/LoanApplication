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

    constructor() {
    }

    get borrowerEmploymentInfo(): FormArray {
        return this.form.get('borrowerEmploymentInfo') as FormArray;
    }

    getBorrowerEmpInfoFormGroup(index) {
        return this.borrowerEmploymentInfo.controls[index] as FormGroup;
    }

    ngOnInit(): void {
        this.initForm();
        this.loadStates();
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
            borrowerEmploymentInfo: new FormArray([]),
        });
        this.addBorrowerEmploymentInfo();

        this.form.valueChanges.subscribe(data => {
            if (this.form.valid) {
                this.onDataChange.next(this.form.value);
            }
        });
    }

    newBorrowerEmploymentInfo(): FormGroup {
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
            borrowerTypeId: new FormControl(''),
        });
    }

    addBorrowerEmploymentInfo() {
        this.borrowerEmploymentInfo.push(this.newBorrowerEmploymentInfo());
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
}
