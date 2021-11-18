import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step8",
  templateUrl: "./step8.component.html",
  styleUrls: ["./step8.component.css"],
})
export class Step8Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step7"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step9"]);
  }
}
