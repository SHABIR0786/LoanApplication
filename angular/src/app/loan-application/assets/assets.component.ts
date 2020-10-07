import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {NgWizardService} from 'ng-wizard';
import {DataService} from '../../services/data.service';
import {ILoanApplicationModel} from '../../interfaces/ILoanApplicationModel';
import {IAssetModel} from '../../interfaces/IAssetModel';

@Component({
    selector: 'app-assets',
    templateUrl: './assets.component.html',
    styleUrls: ['./assets.component.css']
})
export class AssetsComponent implements OnInit, DoCheck {

    id = Math.random().toString(36).substring(2);
    @Input() data: IAssetModel[] = [];
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    form: FormGroup;

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService
    ) {
    }

    ngOnInit(): void {
        this.initForm();

        this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
            if (formData && formData.assets) {
                this.form.patchValue(formData.assets);
            }
        });
    }

    ngDoCheck() {
        this.data = this.form.value;
        this._dataService.updateValidations(this.form, 'assets');

        if (this.form.valid) {
            this.onDataChange.next(this.form.value);
        }
    }

    initForm() {
        // this.form = new FormGroup({
        // });
    }

}
