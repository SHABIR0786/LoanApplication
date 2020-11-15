import { Component } from "@angular/core";
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
export class HomeTestmionals {
  // buyingAHome: string = "Buying A home Guide";
}
