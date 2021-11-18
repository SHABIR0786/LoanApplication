import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step18",
  templateUrl: "./step18.component.html",
  styleUrls: ["./step18.component.css"],
})
export class Step18Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step17"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step19"]);
  }
}
