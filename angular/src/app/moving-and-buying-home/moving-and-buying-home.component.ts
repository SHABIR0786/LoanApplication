import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-moving-and-buying-home",
  templateUrl: "./moving-and-buying-home.component.html",
  styleUrls: ["./moving-and-buying-home.component.css"],
})
export class MovingAndBuyingHomeComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  ReadMore:boolean = true
  visible:boolean = false

  readmore(){
    this.ReadMore =!this.ReadMore
    this.visible =!this.visible
  }
}
