import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step15",
  templateUrl: "./step15.component.html",
  styleUrls: ["./step15.component.css"],
})
export class RefinanceLoanOptionsStep15Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-loan-option-step14"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-loan-option-step16"]);
  }
}
