import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step8",
  templateUrl: "./animated-step8.component.html",
  styleUrls: ["./animated-step8.component.css"],
})
export class AnimatedStep8Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step7"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step9"]);
  }
}
