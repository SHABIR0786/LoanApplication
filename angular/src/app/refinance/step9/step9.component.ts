import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step9",
  templateUrl: "./step9.component.html",
  styleUrls: ["./step9.component.css"],
})
export class Step9Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step8"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step10"]);
  }
}
