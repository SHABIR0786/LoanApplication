import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step2",
  templateUrl: "./animated-step2.component.html",
  styleUrls: ["./animated-step2.component.css"],
})
export class AnimatedStep2Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step1"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step3"]);
  }
}
