import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-government",
  templateUrl: "./government.component.html",
  styleUrls: ["./government.component.css"],
})
export class GovernmentComponent implements OnInit {
  number: number = 1;
  yes = false;
  model: PostModel = new PostModel();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService
  ) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        router.navigate(["1"]);
      }
    });
  }

  ngOnInit() {
    this.model = this.offline.getStep().data;
  }

  onGovClick() {
    this.saveStep();
  }
  onQsClick() {
    this.saveStep();
  }
  onAgreeClick() {
    this.saveStep();
  }
  onFinalNext() {
    console.table(this.offline.getStep().data);
  }
  saveStep() {
    this.offline.saveStep(8, this.model);
  }
}
