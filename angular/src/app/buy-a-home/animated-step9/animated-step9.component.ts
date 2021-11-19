import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step9",
  templateUrl: "./animated-step9.component.html",
  styleUrls: ["./animated-step9.component.css"],
})
export class AnimatedStep9Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step8"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step10"]);
  }
}
