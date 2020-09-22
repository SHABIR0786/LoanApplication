import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
    selector: 'app-borrower-information',
    templateUrl: './borrower-information.component.html',
    styleUrls: ['./borrower-information.component.css']
})
export class BorrowerInformationComponent implements OnInit, DoCheck  {

    id = Math.random().toString(36).substring(2);
    @Input() heading = 'Borrower';
    @Input() data: any = {};
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    constructor() {
    }

    ngOnInit(): void {
    }

    ngDoCheck() {
        this.onDataChange.next(this.data);
    }
}
