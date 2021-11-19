import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step11",
  templateUrl: "./animated-step11.component.html",
  styleUrls: ["./animated-step11.component.css"],
})
export class AnimatedStep11Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step10"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step12"]);
  }
}
