import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step9",
  templateUrl: "./step9.component.html",
  styleUrls: ["./step9.component.css"],
})
export class RefinanceLoanOptionsStep9Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step8"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step10"]);
  }
}
