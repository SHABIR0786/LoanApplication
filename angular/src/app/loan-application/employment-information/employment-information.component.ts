import {Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
    selector: 'app-employment-information',
    templateUrl: './employment-information.component.html',
    styleUrls: ['./employment-information.component.css']
})
export class EmploymentInformationComponent implements OnInit, DoCheck {

    id = Math.random().toString(36).substring(2);
    @Input() heading = 'Borrower';
    @Input() data: any = {};
    @Input() showHeading: boolean = false;
    @Input() secondary: boolean = false;
    @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();

    constructor() {
    }

    ngOnInit(): void {
    }

    ngDoCheck() {
        this.onDataChange.next(this.data);
    }
}
