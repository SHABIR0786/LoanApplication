import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step13",
  templateUrl: "./step13.component.html",
  styleUrls: ["./step13.component.css"],
})
export class Step13Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step12"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step14"]);
  }
}
