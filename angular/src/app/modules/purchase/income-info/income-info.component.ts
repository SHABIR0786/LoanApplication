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
  submitted = false;
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
    if (this.model.currentStateId) {
      this.getStateById(this._model.employementTaxeId);
    }
  }
  onStateChange(event) {
    console.log(event.target.value);
    this.getStateById(event.target.value);
  }
  getState() {
    this.api.get("State/states").subscribe((x: any) => {
      this.states = x.result;
      this.model.empState = "1";
      this.model.currentStateId = 1;
      this.model.newHomeState = "1";
    });
  }
  getStateById(id) {
    this.api.get("State/State?id=" + id).subscribe((x: any) => {
      if (x && x.result) {
        this._model.employementStateName = x.result.stateName;
      }
    });
  }
  onHaveMoreClick(e) {}
  onIncomeComplete() {
    this.saveStep();
  }
  saveEmpToDb(f) {
    this.submitted = true;
    if (f.valid) {
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
  }
  saveStep() {
    this.offline.saveStep(5, this.model);
  }

  onNextClick(f, step) {
    this.submitted = true;
    if (f.valid) {
      this.router.navigate(["/app/purchase/income-info/" + step]);
      this.submitted = false;
    }
  }

  doneClicked(f) {
    if (f.valid) {
      this.router.navigate(["/app/purchase/income-info/6"]);
    }
  }
}
