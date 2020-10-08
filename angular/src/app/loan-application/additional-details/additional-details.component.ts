import {Component, DoCheck, OnInit} from '@angular/core';
import {DataService} from '../../services/data.service';
import {IAdditionalDetailModel} from '../../interfaces/IAdditionalDetailModel';
import { Router } from '@angular/router';

@Component({
    selector: 'app-additional-details',
    templateUrl: './additional-details.component.html',
    styleUrls: ['./additional-details.component.css']
})
export class AdditionalDetailsComponent implements OnInit, DoCheck {

    data: IAdditionalDetailModel = {};

    constructor(private _dataService: DataService,
        private _route: Router,) {
    }

    ngDoCheck(): void {
        this._dataService.updateData(this.data, 'additionalDetails');
    }

    ngOnInit(): void {
        this.data = this._dataService.loanApplication.additionalDetails;
    }

    proceedToNext() {
        // this._ngWizardService.next();
        this._route.navigate(["app/econsent"]);
    }

    proceedToPrevious() {
        // this._ngWizardService.previous();
        this._route.navigate(["app/order-credit"]);
    }

}
