import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step10",
  templateUrl: "./step10.component.html",
  styleUrls: ["./step10.component.css"],
})
export class RefinanceLoanOptionsStep10Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step9"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step11"]);
  }
}
