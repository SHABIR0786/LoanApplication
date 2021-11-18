import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step19",
  templateUrl: "./step19.component.html",
  styleUrls: ["./step19.component.css"],
})
export class Step19Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step18"]);
  }
}
