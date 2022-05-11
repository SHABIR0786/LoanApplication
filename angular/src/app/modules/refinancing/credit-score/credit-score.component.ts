import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-credit-score",
  templateUrl: "./credit-score.component.html",
  styleUrls: ["./credit-score.component.css", "./../index.component.css"],
})
export class CreditScoreComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService
  ) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        this.router.navigate(["1"]);
      }
    });
  }

  ngOnInit() {
    this.model = this.offline.getStep().data;
  }

  saveStep() {
    this.offline.saveStep(1, this.model);
  }
}
