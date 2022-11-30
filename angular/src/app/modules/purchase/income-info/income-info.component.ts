import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {
  EmployementDetailAdd,
  PostModel,
} from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";
import {
  AddLeadEmploymentDetails,
  LeadEmploymentDetailsServiceServiceProxy,
  StateServiceServiceProxy,
} from "@shared/service-proxies/service-proxies";
import * as moment from "moment";

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
  _model: AddLeadEmploymentDetails = new AddLeadEmploymentDetails();
  submitted = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService,
    private api: ApiService,
    private stateService: StateServiceServiceProxy,
    private leadEmpDetail: LeadEmploymentDetailsServiceServiceProxy
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
    this.stateService.getStates().subscribe((res) => {
      this.states = res;
    });
    // this.api.get("State/states").subscribe((x: any) => {
    //   this.states = x.result;
    //   this.model.empState = "1";
    //   this.model.currentStateId = 1;
    //   this.model.newHomeState = "1";
    // });
  }
  onHaveMoreClick(e) {}
  onIncomeComplete() {
    this.saveStep();
  }
  saveEmpToDb(f) {
    debugger;
    this.submitted = true;
    if (f.valid) {
      this._model.leadApplicationDetailPurchasingId = 1;
      this.saveStep();
      ///////////
      if (this._model.estimatedStartDate) {
        this._model.estimatedStartDate = moment(this._model.estimatedStartDate)
          .add("5", "hours")
          .add("30", "minutes");
      } else {
        this._model.estimatedStartDate = null;
      }
      this.leadEmpDetail.add(this._model).subscribe((res) => {
        if (res != null) {
          this.router.navigate(["/app/purchase/income-info/4"]);
        }
      });
      // this.api
      //   .post("/LeadEmploymentDetail/Add", this._model)
      //   .subscribe((x: any) => {
      //     if (x.success == true) {
      //       this.router.navigate(["/app/purchase/income-info/4"]);
      //     }
      //   });
    }
  }
  saveStep() {
    this.offline.saveStep(5, this.model);
  }

  onNextClick(f, step) {
    debugger;
    this.submitted = true;
    if (f.valid) {
      this.router.navigate(["/app/purchase/income-info/" + step]);
      this.submitted = false;
    }
  }
}
