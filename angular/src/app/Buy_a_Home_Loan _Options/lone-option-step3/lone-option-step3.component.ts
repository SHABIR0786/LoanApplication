import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step3",
  templateUrl: "./lone-option-step3.component.html",
  styleUrls: ["./lone-option-step3.component.css"],
})
export class LoneOptionStep3Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step2"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step4"]);
  }
}
