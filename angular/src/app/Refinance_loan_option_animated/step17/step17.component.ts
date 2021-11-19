import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step17",
  templateUrl: "./step17.component.html",
  styleUrls: ["./step17.component.css"],
})
export class RefinanceLoanOptionsStep17Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step16"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step18"]);
  }
}
