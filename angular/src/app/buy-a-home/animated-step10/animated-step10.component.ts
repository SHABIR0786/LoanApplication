import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step10",
  templateUrl: "./animated-step10.component.html",
  styleUrls: ["./animated-step10.component.css"],
})
export class AnimatedStep10Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step9"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step11"]);
  }
}
