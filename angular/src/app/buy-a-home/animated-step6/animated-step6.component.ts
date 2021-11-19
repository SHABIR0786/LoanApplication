import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step6",
  templateUrl: "./animated-step6.component.html",
  styleUrls: ["./animated-step6.component.css"],
})
export class AnimatedStep6Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step5"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step7"]);
  }
}
