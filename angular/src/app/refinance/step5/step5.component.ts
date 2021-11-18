import { Component, OnInit, AfterViewInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-step5",
  templateUrl: "./step5.component.html",
  styleUrls: ["./step5.component.css"],
})
export class Step5Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  ngAfterViewInit() {
    document.getElementById("myRange").oninput = function (e) {
      const Element = e.target as HTMLInputElement;
      var value = Element.value;
      // var value = (this.value-this.min)/(this.max-this.min)*100
      Element.style.background =
        "linear-gradient(to right, #F47741 0%, #F47741 " +
        value +
        "%, #000000 " +
        value +
        "%, black 100%)";
    };
    var Element = document.getElementById("myRange") as HTMLInputElement;
    var value = Element.value;
    document.getElementById("myRange").style.background =
      "linear-gradient(to right, #F47741 0%, #F47741 " +
      value +
      "%, #000000 " +
      value +
      "%, black 100%)";
  }
  proceedToPrevious() {
    this._route.navigate(["app/refinance-step4"]);
  }
  proceedToNext() {
    this._route.navigate(["app/refinance-step6"]);
  }
}
