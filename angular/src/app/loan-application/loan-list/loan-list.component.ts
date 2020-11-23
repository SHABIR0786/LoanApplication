import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-loan-list",
  templateUrl: "./loan-list.component.html",
  styleUrls: ["./loan-list.component.css"],
})
export class LoanListComponent implements OnInit, DoCheck {
  data = [{}];
  constructor() {}

  ngOnInit(): void {
    this.loadData();
  }

  ngDoCheck(): void {}

  loadData() {
    this.data = [
      {
        borrower: "A",
        fileName: "B",
        loanStatus: "C",
        statusDate: "D",
        estClose: "E",
        rateLoc: "F",
        processor: "G",
        originator: "H",
        contact: "I",
      },
    ];
  }
}
