import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step5",
  templateUrl: "./step5.component.html",
  styleUrls: ["./step5.component.css"],
})
export class RefinanceLoanOptionsStep5Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step4"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step6"]);
  }
}
