import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step17",
  templateUrl: "./animated-step17.component.html",
  styleUrls: ["./animated-step17.component.css"],
})
export class AnimatedStep17Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step16"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step18"]);
  }
}
