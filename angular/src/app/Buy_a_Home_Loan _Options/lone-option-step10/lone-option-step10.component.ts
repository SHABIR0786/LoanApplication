import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step10",
  templateUrl: "./lone-option-step10.component.html",
  styleUrls: ["./lone-option-step10.component.css"],
})
export class LoneOptionStep10Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step9"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step11"]);
  }
}
