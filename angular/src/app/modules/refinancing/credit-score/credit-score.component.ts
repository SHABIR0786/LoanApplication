import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-credit-score",
  templateUrl: "./credit-score.component.html",
  styleUrls: ["./credit-score.component.css", "./../index.component.css"],
})
export class CreditScoreComponent implements OnInit {
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
