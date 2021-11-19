import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step16",
  templateUrl: "./animated-step16.component.html",
  styleUrls: ["./animated-step16.component.css"],
})
export class AnimatedStep16Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step15"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step17"]);
  }
}
