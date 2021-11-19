import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step13",
  templateUrl: "./animated-step13.component.html",
  styleUrls: ["./animated-step13.component.css"],
})
export class AnimatedStep13Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step12"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step14"]);
  }
}
