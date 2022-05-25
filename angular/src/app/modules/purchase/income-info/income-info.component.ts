import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {
  EmployementDetailAdd,
  PostModel,
} from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-income-info",
  templateUrl: "./income-info.component.html",
  styleUrls: ["./income-info.component.css"],
})
export class IncomeInfoComponent implements OnInit {
  number: number = 1;
  yes = false;
  model: PostModel = new PostModel();
  states = [];
  _model: EmployementDetailAdd = new EmployementDetailAdd();
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
    this.model = this.offline.getStep().data;
    this.getState();
  }
  getState() {
    this.api.get("State/states").subscribe((x: any) => {
      this.states = x.result;
    });
  }
  onHaveMoreClick(e) {}
  onIncomeComplete() {
    this.saveStep();
  }
  saveEmpToDb() {
    this._model.leadApplicationDetailPurchasingId = 1;
    this.saveStep();
    this.api
      .post("/LeadEmploymentDetail/Add", this._model)
      .subscribe((x: any) => {
        if (x.success == true) {
          this.router.navigate(["/app/purchase/income-info/4"]);
        }
      });
  }
  saveStep() {
    this.offline.saveStep(5, this.model);
  }
}
