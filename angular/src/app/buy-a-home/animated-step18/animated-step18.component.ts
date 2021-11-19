import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step18",
  templateUrl: "./animated-step18.component.html",
  styleUrls: ["./animated-step18.component.css"],
})
export class AnimatedStep18Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step17"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step19"]);
  }
}
