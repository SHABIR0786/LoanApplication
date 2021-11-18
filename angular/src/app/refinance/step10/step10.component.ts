import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step10",
  templateUrl: "./step10.component.html",
  styleUrls: ["./step10.component.css"],
})
export class Step10Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}

  proceedToPrevious() {
    this._route.navigate(["app/refinance-step9"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step11"]);
  }
}
