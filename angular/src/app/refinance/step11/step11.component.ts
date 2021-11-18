import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-step11",
  templateUrl: "./step11.component.html",
  styleUrls: ["./step11.component.css"],
})
export class Step11Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step10"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step12"]);
  }
}
