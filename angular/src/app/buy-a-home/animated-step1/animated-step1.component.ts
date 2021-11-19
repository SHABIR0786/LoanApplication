import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step1",
  templateUrl: "./animated-step1.component.html",
  styleUrls: ["./animated-step1.component.css"],
})
export class AnimatedStep1Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step2"]);
  }
}
