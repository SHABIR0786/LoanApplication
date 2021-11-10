import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-pay-off-your-mortgage-faster",
  templateUrl: "./pay-off-your-mortgage-faster.component.html",
  styleUrls: ["./pay-off-your-mortgage-faster.component.css"],
})
export class PayOffYourMortgageFasterComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
