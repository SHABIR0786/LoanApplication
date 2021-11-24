import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step5",
  templateUrl: "./lone-option-step5.component.html",
  styleUrls: ["./lone-option-step5.component.css"],
})
export class LoneOptionStep5Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step4"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step6"]);
  }
}
