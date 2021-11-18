import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step16",
  templateUrl: "./step16.component.html",
  styleUrls: ["./step16.component.css"],
})
export class Step16Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step15"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step17"]);
  }
}
