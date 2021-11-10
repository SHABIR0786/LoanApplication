import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-refinance-free-consultation",
  templateUrl: "./refinance-free-consultation.component.html",
  styleUrls: ["./refinance-free-consultation.component.css"],
})
export class RefinanceFreeConsultationComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
