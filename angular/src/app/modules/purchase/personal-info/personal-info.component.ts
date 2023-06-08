import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AddFinanceApiModel, PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-personal-info",
  templateUrl: "./personal-info.component.html",
  styleUrls: ["./personal-info.component.css", "./../index.component.css"],
})
export class PersonalInfoComponent implements OnInit {
  submitted = false;
  number: number = 1;
  model: PostModel = new PostModel();
  states: any[] = [];
  cities: any[] = [];
  dependents: number = 0;
  matched = false;
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
    this.getState();
    if (this.model.currentStateId) {
      this.getStateById(this.model.currentStateId);
    }

    this.model = this.offline.getStep().data;
  }
  getState() {
    this.api.get("StateService/GetStates").subscribe((x: any) => {
      this.states = x.result;
      this.model.empState = "1";
      this.model.currentStateId = 1;
      this.model.newHomeState = "1";
    });
  }

  onStateChange(event) {
    console.log(event.target.value);
    this.getStateById(event.target.value);
  }
  getStateById(id) {
    this.api.get("StateService/GetStates?id=" + id).subscribe((x: any) => {
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
  onPersClick(f, step) {
    this.submitted = true;
    if (this.model.personalPassword === this.model.personalPasswordCon) {
      this.matched = true;
    }
    console.log(this.submitted, this.matched, f.errors);
    if (f.valid && this.matched) {
      this.router.navigate(["/app/purchase/personal-info", step]);
      this.submitted = false;
      this.matched = false;
      this.saveStep();
    }
  }
  referClick(e) {
    if (e == "true") {
      this.model.isSomeOneRefer = 1;
    } else {
      this.model.isSomeOneRefer = 0;
    }
    // this.model.isSomeOneRefer = e ? 1 : 0;
    console.log(this.model.isSomeOneRefer);
    this.saveStep();
  }
  maritalClick(e: string) {
    this.model.maritialStatus = e;
    this.saveStep();
  }

  onDepPlusClick() {
    this.dependents += 1;
  }
  onDepMinClick() {
    if (this.dependents > 0) this.dependents -= 1;
  }
  onDepNext() {
    this.model.numberOfDependents = this.dependents;
    this.saveStep();
  }
  onDepSkipNext() {
    this.model.numberOfDependents = 0;
    this.saveStep();
  }
  ownApply(e: boolean) {
    this.model.isApplyOwn = e ? 1 : 0;
    this.saveStep();
  }
  onPersonalClick() {
    this.saveStep();
  }
  onExpenClick() {
    this.saveStep();
  }
  saveToDb() {
    this.saveStep();
    var _model = new AddFinanceApiModel();
    _model.map(this.model);
    this.api
      .post("LeadPurchasingDetailService/Add", _model)
      .subscribe((x: any) => {
        if (x.success == true)
          this.router.navigate(["/app/purchase/income-info/1"]);
      });
  }
  saveStep() {
    this.offline.saveStep(4, this.model);
  }

  doneClicked(f) {
    if (f.valid) {
      this.router.navigate(["/app/purchase/personal-info/8"]);
    }
  }
}
