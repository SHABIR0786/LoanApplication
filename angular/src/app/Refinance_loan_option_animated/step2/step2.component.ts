import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step2",
  templateUrl: "./step2.component.html",
  styleUrls: ["./step2.component.css"],
})
export class RefinanceLoanOptionsStep2Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step1"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step3"]);
  }
}
