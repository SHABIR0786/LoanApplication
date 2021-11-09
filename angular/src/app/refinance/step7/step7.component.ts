import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-step7",
  templateUrl: "./step7.component.html",
  styleUrls: ["./step7.component.css"],
})
export class Step7Component implements OnInit {
  constructor() {}

  ngOnInit(): void {}
  ngAfterViewInit() {
    document.getElementById("myRange").oninput = function (e) {
      var value = e.target.value;
      // var value = (this.value-this.min)/(this.max-this.min)*100
      this.style.background =
        "linear-gradient(to right, #F47741 0%, #F47741 " +
        value +
        "%, #000000 " +
        value +
        "%, black 100%)";
    };
    var value = document.getElementById("myRange").value;
    document.getElementById("myRange").style.background =
      "linear-gradient(to right, #F47741 0%, #F47741 " +
      value +
      "%, #000000 " +
      value +
      "%, black 100%)";
  }
}
