import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormArray, FormControl, FormGroup} from '@angular/forms';
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
    states = [];
    assetTypes = [];

    constructor(
        private _ngWizardService: NgWizardService,
        private _dataService: DataService
    ) {
    }

    get manualAssetEntries(): FormArray {
        return this.form.get('manualAssetEntries') as FormArray;
    }

    ngOnInit(): void {
        this.initForm();
        this.loadStates();
        this.loadAssetTypes();

        this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
            if (formData && formData.manualAssetEntries) {
                this.form.patchValue({manualAssetEntries: formData.manualAssetEntries});
            }
        });
    }

    ngDoCheck() {
        this.data = this.form.value.manualAssetEntries;
        this._dataService.updateValidations(this.form, 'manualAssetEntries');

        if (this.form.valid) {
            this.onDataChange.next(this.form.value.manualAssetEntries);
        }
    }

    initForm() {
        this.form = new FormGroup({
            manualAssetEntries: new FormArray([])
        });
    }

    addAsset() {
        this.manualAssetEntries.push(this.initAssetForm(1));
    }

    removeAsset(index) {
        this.manualAssetEntries.removeAt(index);
    }

    initAssetForm(assetTypeId) {
        const form = new FormGroup({
            id: new FormControl(''),
            assetTypeId: new FormControl(assetTypeId),
            name: new FormControl(''),
            bankName: new FormControl(''),
            description: new FormControl(''),
            accountNumber: new FormControl(''),
            cashValue: new FormControl(''),
            address: new FormControl(''),
            address2: new FormControl(''),
            city: new FormControl(''),
            stateId: new FormControl(''),
            zipCode: new FormControl(''),
            propertyStatus: new FormControl(''),
            propertyIsUsedAs: new FormControl(''),
            propertyType: new FormControl(''),
            presentMarketValue: new FormControl(''),
            outstandingMortgageBalance: new FormControl(''),
            monthlyMortgagePayment: new FormControl(''),
            purchasePrice: new FormControl(''),
            grossRentalIncome: new FormControl(''),
            taxesInsuranceAndOther: new FormControl(''),
            stockAndBonds: new FormArray([]),
        });

        form.get('assetTypeId').valueChanges.subscribe(id => {
            if (id === 12) {
                const control = form.get('stockAndBonds') as FormArray;
                if (!control.length) {
                    control.push(this.initStockAndBond());
                    control.push(this.initStockAndBond());
                    control.push(this.initStockAndBond());
                }
            } else {
                form.get('stockAndBonds').patchValue([]);
            }
        });

        return form;
    }

    initStockAndBond() {
        return new FormGroup({
            id: new FormControl(''),
            companyName: new FormControl(''),
            accountNumber: new FormControl(''),
            value: new FormControl(''),
        });
    }

    loadStates() {
        this.states = [
            {
                id: 1,
                name: 'CA'
            }
        ];
    }

    loadAssetTypes() {
        this.assetTypes = [
            {
                id: 1,
                name: 'Cash Deposit on sales contract'
            },
            {
                id: 2,
                name: 'Certificate of Deposit'
            },
            {
                id: 3,
                name: 'Checking Account'
            },
            {
                id: 4,
                name: 'Gifts'
            },
            {
                id: 5,
                name: 'Gift of equity'
            },
            {
                id: 6,
                name: 'Money Market Fund'
            },
            {
                id: 7,
                name: 'Mutual Funds'
            },
            {
                id: 8,
                name: 'New Proceed from Real Estate Funds'
            },
            {
                id: 9,
                name: 'Real Estate Owned'
            },
            {
                id: 10,
                name: 'Retirement Funds'
            },
            {
                id: 11,
                name: 'Saving Accounts'
            },
            {
                id: 12,
                name: 'Stock and Bonds'
            },
            {
                id: 13,
                name: 'Trust Account'
            },
        ];
    }

    getAssetTypeById(assetTypeId) {
        const data = this.assetTypes.find(type => type.id === assetTypeId);
        return data ? data.name : null;
    }

    trackByFn(index: any, item: any) {
        return index;
    }
}
