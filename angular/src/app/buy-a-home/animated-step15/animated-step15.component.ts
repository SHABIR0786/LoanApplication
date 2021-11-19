import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step15",
  templateUrl: "./animated-step15.component.html",
  styleUrls: ["./animated-step15.component.css"],
})
export class AnimatedStep15Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step14"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step16"]);
  }
}
