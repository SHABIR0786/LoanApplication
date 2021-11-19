import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step12",
  templateUrl: "./animated-step12.component.html",
  styleUrls: ["./animated-step12.component.css"],
})
export class AnimatedStep12Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step11"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step13"]);
  }
}
