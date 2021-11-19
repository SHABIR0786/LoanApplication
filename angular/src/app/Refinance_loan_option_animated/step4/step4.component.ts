import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step4",
  templateUrl: "./step4.component.html",
  styleUrls: ["./step4.component.css"],
})
export class RefinanceLoanOptionsStep4Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}

  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step3"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step5"]);
  }
}
