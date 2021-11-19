import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step14",
  templateUrl: "./animated-step14.component.html",
  styleUrls: ["./animated-step14.component.css"],
})
export class AnimatedStep14Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step13"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step15"]);
  }
}
