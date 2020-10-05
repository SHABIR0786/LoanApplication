import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {NgWizardService, STEP_STATE} from 'ng-wizard';
import {IConsentModel} from '../../interfaces/IConsentModel';
import {IBorrowerModel} from '../../interfaces/IBorrowerModel';

@Component({
    selector: 'app-econsent',
    templateUrl: './econsent.component.html',
    styleUrls: ['./econsent.component.css']
})
export class EconsentComponent implements OnInit, DoCheck {

    @Input() data: IConsentModel = {};
    @Input() borrower: IBorrowerModel = {};
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;

    constructor(private _ngWizardService: NgWizardService) {
    }

    ngOnInit(): void {
        this.initForm();
    }

    ngDoCheck() {
        this.data = this.form.value;
        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    initForm() {
        this.form = new FormGroup({
            agreeEConsent: new FormControl(this.data.agreeEConsent),
            firstName: new FormControl(this.data.firstName, [Validators.required]),
            lastName: new FormControl(this.data.lastName, [Validators.required]),
            email: new FormControl(this.data.email, [Validators.required]),
        });
    }

    proceedToNext() {
        if (this.form.valid) {
            this._ngWizardService.next();
        } else {
            this.form.markAllAsTouched();
        }
    }

    proceedToPrevious() {
        this._ngWizardService.previous();
    }
}
