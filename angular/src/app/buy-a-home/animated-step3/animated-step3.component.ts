import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step3",
  templateUrl: "./animated-step3.component.html",
  styleUrls: ["./animated-step3.component.css"],
})
export class AnimatedStep3Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step2"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step4"]);
  }
}
