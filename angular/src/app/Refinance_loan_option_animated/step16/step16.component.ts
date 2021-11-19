import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step16",
  templateUrl: "./step16.component.html",
  styleUrls: ["./step16.component.css"],
})
export class RefinanceLoanOptionsStep16Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}

  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step15"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step17"]);
  }
}
