import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IExpenseModel } from '@app/interfaces/IExpenseModel';
@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  //id = Math.random().toString(36).substring(2);
  @Input() heading: string;
  @Input() form: FormGroup;
  @Input() data: IExpenseModel;
  @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();




  constructor() { }

  ngOnInit(): void {
  }

  initForm() {
    this.form = new FormGroup({
      isLiveWithFamilySelectRent: new FormControl(this.data.isLiveWithFamilySelectRent),
      rent: new FormControl(this.data.rent, [Validators.required]),
      otherHousingExpenses: new FormControl(this.data.otherHousingExpenses, [Validators.required]),
      firstMortgage: new FormControl(this.data.firstMortgage, [Validators.required]),
      secondMortgage: new FormControl(this.data.secondMortgage),
      hazardInsurance: new FormControl(this.data.hazardInsurance),
      realEstateTaxes: new FormControl(this.data.realEstateTaxes, [Validators.required]),
      mortgageInsurance: new FormControl(this.data.mortgageInsurance, [Validators.required]),
      homeownersAssociation: new FormControl(this.data.homeownersAssociation, [Validators.required])
    });
  }

  onRentChange() {
    debugger;
    this.data;

  }

}
