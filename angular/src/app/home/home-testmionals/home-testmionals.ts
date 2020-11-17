import { Component, DoCheck, OnInit } from "@angular/core";
import { CarouselConfig } from "ngx-bootstrap/carousel";

@Component({
  templateUrl: "./home-testmionals.html",
  styleUrls: ["./home-testmionals.css"],
  selector: "home-testmionals",
  providers: [
    {
      provide: CarouselConfig,
      useValue: { pauseOnFocus: true, showIndicators: false, itemsPerSlide: 1 },
    },
  ],
})
export class HomeTestmionals implements DoCheck, OnInit {
  testmionals = [];

  loadTestmionals() {
    this.testmionals = [
      {
        id: 1,
        comment:
          " Thanks you for all your help in making the mortgage process gosmoothlyl my husband and i couldn,t have done it without you",
        name: "Anne Davidson (San Francisco, CA)",
      },
      {
        id: 2,
        comment:
          "Thanks you for all your help in making the mortgage process gosmoothlyl ",
        name: "HELLO (San Francisco, CA)",
      },
    ];
  }

  ngDoCheck(): void {
    console.log(this.testmionals);
  }

  ngOnInit(): void {
    this.loadTestmionals();
  }
}
