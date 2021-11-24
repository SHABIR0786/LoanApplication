import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step6",
  templateUrl: "./lone-option-step6.component.html",
  styleUrls: ["./lone-option-step6.component.css"],
})
export class LoneOptionStep6Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step5"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step7"]);
  }
}
