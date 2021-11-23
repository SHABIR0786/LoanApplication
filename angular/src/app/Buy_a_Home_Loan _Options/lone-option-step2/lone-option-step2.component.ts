import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-lone-option-step2",
  templateUrl: "./lone-option-step2.component.html",
  styleUrls: ["./lone-option-step2.component.css"],
})
export class LoneOptionStep2Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step1"]);
  }
}
