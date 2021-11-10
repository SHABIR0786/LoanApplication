import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-home-buying-free-consultation",
  templateUrl: "./home-buying-free-consultation.component.html",
  styleUrls: ["./home-buying-free-consultation.component.css"],
})
export class HomeBuyingFreeConsultationComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

 ReadMore:boolean = true
 visible:boolean = false

 readmore(){
   this.ReadMore =!this.ReadMore
   this.visible =!this.visible
 }
}
