import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-income-info",
  templateUrl: "./income-info.component.html",
  styleUrls: ["./income-info.component.css", "./../index.component.css"],
})
export class IncomeInfoComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
  states: any[] = [];
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
        this.router.navigate(["1"]);
      }
    });
  }

  ngOnInit() {
    this.getStates();
    this.model = this.offline.getStep().data;
  }
  getStates() {
    this.api.get("State/states").subscribe((x: any) => {
      if (x && x.result) this.states = x.result;
    });
  }
  // routerLink="/app/refinance/assets-info/1"
  callToDb() {
    this.api
      .post("LeadRefinancingDetails/Add", this.model)
      .subscribe((x: any) => {
        if (x.success == true) {
          this.model.leadApplicationDetailRefinancingId = 1;
          this.saveStep();
          this.router.navigate(["/app/refinance/assets-info/1"]);
        }
        console.log({ x });
      });
  }
  saveStep() {
    this.offline.saveStep(4, this.model);
  }
}
