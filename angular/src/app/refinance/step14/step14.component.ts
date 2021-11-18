import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step14",
  templateUrl: "./step14.component.html",
  styleUrls: ["./step14.component.css"],
})
export class Step14Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step13"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step15"]);
  }
}
