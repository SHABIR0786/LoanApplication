import {Component, DoCheck, OnInit} from '@angular/core';
import {DataService} from '../../services/data.service';

@Component({
    selector: 'app-order-credit',
    templateUrl: './order-credit.component.html',
    styleUrls: ['./order-credit.component.css']
})
export class OrderCreditComponent implements OnInit, DoCheck {

    data: any = {};

    constructor(private _dataService: DataService) {
    }

    ngDoCheck(): void {
        this._dataService.updateData(this.data, 'orderCredit');
    }

    ngOnInit(): void {
        this.data = this._dataService.loanApplication.orderCredit;
    }

    proceedToNext() {
        // this._ngWizardService.next();
    }

    proceedToPrevious() {
        // this._ngWizardService.previous();
    }
}
