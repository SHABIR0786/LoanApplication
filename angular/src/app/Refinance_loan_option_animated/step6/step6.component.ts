import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step6",
  templateUrl: "./step6.component.html",
  styleUrls: ["./step6.component.css"],
})
export class RefinanceLoanOptionsStep6Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step5"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step7"]);
  }
}
