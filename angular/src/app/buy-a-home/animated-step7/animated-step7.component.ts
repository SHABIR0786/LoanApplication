import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step7",
  templateUrl: "./animated-step7.component.html",
  styleUrls: ["./animated-step7.component.css"],
})
export class AnimatedStep7Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step6"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step8"]);
  }
}
