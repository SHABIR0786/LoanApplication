import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-gov-info",
  templateUrl: "./gov-info.component.html",
  styleUrls: ["./gov-info.component.css", "./../index.component.css"],
})
export class GovInfoComponent implements OnInit {
  number: number = 1;
  constructor(private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        this.router.navigate(["1"]);
      }
    });
  }

  ngOnInit() {}
}
