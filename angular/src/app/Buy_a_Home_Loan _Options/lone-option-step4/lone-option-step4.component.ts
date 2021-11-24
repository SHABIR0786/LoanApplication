import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step4",
  templateUrl: "./lone-option-step4.component.html",
  styleUrls: ["./lone-option-step4.component.css"],
})
export class LoneOptionStep4Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step3"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step5"]);
  }
}
