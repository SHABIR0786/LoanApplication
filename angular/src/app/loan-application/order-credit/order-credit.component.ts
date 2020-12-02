import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../services/data.service";

import { createStore } from "redux";
function todos(state = [], action) {
  switch (action.type) {
    case "ADD_TODO":
      return state.concat([action.text]);
    default:
      return state;
  }
}
const store = createStore(todos, ["Use Redux"]);

function select(state) {
  return state.some.deep.property;
}

let currentValue;
function handleChange() {
  let previousValue = currentValue;
  currentValue = select(store.getState());

  if (previousValue !== currentValue) {
    console.log(
      "Some deep nested property changed from",
      previousValue,
      "to",
      currentValue
    );
  }
}

const unsubscribe = store.subscribe(handleChange);
@Component({
  selector: "app-order-credit",
  templateUrl: "./order-credit.component.html",
  styleUrls: ["./order-credit.component.css"],
})
export class OrderCreditComponent implements OnInit, DoCheck {
  data: any = {};

  constructor(private _dataService: DataService, private _route: Router) {}

  ngDoCheck(): void {
    this._dataService.updateData(this.data, "orderCredit");
  }

  ngOnInit(): void {
    console.log(this._dataService.loanApplication);
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
