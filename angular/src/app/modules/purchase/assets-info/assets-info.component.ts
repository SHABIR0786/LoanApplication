import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-assets-info",
  templateUrl: "./assets-info.component.html",
  styleUrls: ["./assets-info.component.css"],
})
export class AssetsInfoComponent implements OnInit {
  number: number = 1;
  yes = false;
  model: PostModel = new PostModel();
  accType: any[] = [];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService,
    private api: ApiService
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
    this.getAccountTypes();
    this.model = this.offline.getStep().data;
  }
  getAccountTypes() {
    this.api.get("Financial/account-types").subscribe((x: any) => {
      this.accType = x.result;
    });
  }
  stepOneClick() {
    this.saveStep();
  }

  saveStep() {
    this.offline.saveStep(6, this.model);
  }
}
