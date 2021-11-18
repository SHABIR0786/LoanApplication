import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step12",
  templateUrl: "./step12.component.html",
  styleUrls: ["./step12.component.css"],
})
export class Step12Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step11"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step13"]);
  }
}
