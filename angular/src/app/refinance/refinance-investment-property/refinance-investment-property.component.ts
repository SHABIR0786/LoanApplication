import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-refinance-investment-property",
  templateUrl: "./refinance-investment-property.component.html",
  styleUrls: ["./refinance-investment-property.component.css"],
})
export class RefinanceInvestmentPropertyComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
