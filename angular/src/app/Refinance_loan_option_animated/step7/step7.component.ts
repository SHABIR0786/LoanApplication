import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step7",
  templateUrl: "./step7.component.html",
  styleUrls: ["./step7.component.css"],
})
export class RefinanceLoanOptionsStep7Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step6"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step8"]);
  }
}
