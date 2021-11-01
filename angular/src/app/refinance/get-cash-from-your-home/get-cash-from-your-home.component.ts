import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-get-cash-from-your-home",
  templateUrl: "./get-cash-from-your-home.component.html",
  styleUrls: ["./get-cash-from-your-home.component.css"],
})
export class GetCashFromYourHomeComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
