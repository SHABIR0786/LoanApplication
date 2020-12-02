import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IPaginationOptions, PageResult, Result } from "common";
import { LoanApplicationService } from "../../services/loan-application.service";
import { LoanListDto } from "./loan-list.component-types";

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
  selector: "app-loan-list",
  templateUrl: "./loan-list.component.html",
  styleUrls: ["./loan-list.component.css"],
})
export class LoanListComponent implements OnInit {
  data: LoanListDto[] = [];
  totalCount = 0;
  pageNumber = 1;
  pageSize = 10;

  constructor(
    private _loanApplicationService: LoanApplicationService,
    private _route: Router
  ) {}

  ngOnInit(): void {
    this.loadData({
      maxResultCount: this.pageSize,
      skipCount: (this.pageNumber - 1) * this.pageSize,
    });
  }

  loadData(options: IPaginationOptions) {
    this._loanApplicationService.post("GetAll", options).subscribe(
      (response: Result<PageResult<LoanListDto>>) => {
        this.data = response.result.items;
        this.data = response.result.items;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  handleEdit(id: number) {
    this._route.navigate(["app/loan-detail"], {
      queryParams: {
        id: id,
      },
    });
  }
}
