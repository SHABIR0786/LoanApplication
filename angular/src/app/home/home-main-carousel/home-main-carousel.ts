import { Component, DoCheck, OnInit } from "@angular/core";

@Component({
  templateUrl: "./home-main-carousel.html",
  styleUrls: ["./home-main-carousel.css"],
  selector: "home-main-carousel",
})
export class HomeMainCarousel implements OnInit {
  mainImage: object = {
    background: "url('assets/img/house.png') no-repeat 0% 0% no-repeat",
  };
  caption: string = "Best California Home Loans";

  mainImage1: object = {
    background: "url('assets/img/new-home.png') 0% 0% no-repeat",
    "background-size": "100% 100%",
  };
  caption1: string = "Best California House Loans";

  ngOnInit(): void {}
}
