import { Component, DoCheck, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';

@Component({
    selector: 'app-order-credit',
    templateUrl: './order-credit.component.html',
    styleUrls: ['./order-credit.component.css']
})
export class OrderCreditComponent implements OnInit, DoCheck {

    data: any = {};

    constructor(
        private _dataService: DataService,
        private _route: Router,
    ) {
    }

    ngDoCheck(): void {
        this._dataService.updateData(this.data, 'orderCredit');
    }

    ngOnInit(): void {
        this.data = this._dataService.loanApplication.orderCredit;
    }

    proceedToNext() {
        // this._ngWizardService.next();
        this._route.navigate(["app/additional-detail"]);
    }

    proceedToPrevious() {
        this._route.navigate(["app/employment-income"]);
    }
}
