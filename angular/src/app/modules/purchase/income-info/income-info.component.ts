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
  model: EmployementDetailAdd = new EmployementDetailAdd();
  states = [];
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
    this.getStates();
    if (this.model.currentStateId) {
      this.getStateById(this.model.employementTaxeId);
    }
  }
  onStateChange(event) {
    this.getStateById(event.target.value);
  }

  getStates() {
    this.stateService.getStates().subscribe((x: any) => {
      this.states = x;
      this.model.empState = 1;
      this.model.currentStateId = 1;
      this.model.newHomeState = "1";
    });
  }
  getStateById(id) {
    if (id) {
      this.api.get("StateService/GetStateById?id=" + id).subscribe((x: any) => {
        if (x && x.result) {
          this.model.currentStateName = x.result.stateName;
          console.log(this.model.currentStateName);
          // this.model.empState = "1";
          // this.model.currentStateId = 1;

          // this.model.newHomeState = "1";
          // this.model.newHomeState = x.result[0].id;
        }
      });
    }
  }
  EmpHistory(e) {
    console.log(e);
    this.model.currentOrPastEmployementHistory = e;
  }
  onHaveMoreClick(e) {}
  onIncomeComplete() {
    this.saveStep();
  }
  saveEmpToDb(f) {
    this.submitted = true;
    var _model = new EmployementDetailAdd();
    _model.map(this.model);
    if (f.valid) {
      this.model.leadApplicationDetailPurchasingId = 1;
      this.saveStep();
      this.api
        .post("LeadEmploymentDetailsService/Add", _model)
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
