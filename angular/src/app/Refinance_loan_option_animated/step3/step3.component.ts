import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-step3",
  templateUrl: "./step3.component.html",
  styleUrls: ["./step3.component.css"],
})
export class RefinanceLoanOptionsStep3Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step2"]);
  }
  // proceedToNext() {
  //   this._route.navigate(["app/refinance-loan-option-step3"]);
  // }
}
