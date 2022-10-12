import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
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
  model: RefinancePost = new RefinancePost();
  deps = 0;
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
    if (this.model.currentStateId) {
      this.getStateById(this.model.currentStateId);
    }
    this.model = this.offline.getStep().data;
  }
  getStates() {
    this.api.get("State/states").subscribe((x: any) => {
      if (x && x.result) this.states = x.result;
      this.model.empState = 1;
      this.model.currentStateId = 1;
      this.model.personalStateId = 1;
      this.model.propertyStateId = 1;
    });
  }
  onStateChange(event) {
    console.log(event.target.value);
    this.getStateById(event.target.value);
  }
  getStateById(id) {
    this.api.get("State/State?id=" + id).subscribe((x: any) => {
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
  minDep() {
    if (this.deps > 0) {
      this.deps--;
    }
  }
  maxDep() {
    this.deps++;
  }
  saveStep() {
    this.offline.saveStep(3, this.model);
  }
  onNextStep(f, step) {
    this.submitted = true;
    if (f.valid) {
      this.router.navigate(["/app/refinance/personal-info", step]);
      this.saveStep();
      this.submitted = false;
    }
  }

  coBorrowerNextClick(f) {
    this.submitted = true;
    if (f.valid) {
      this.router.navigate(["/app/refinance/income/1"]);
      this.saveStep();
      this.submitted = false;
    }
  }
  milClick(obj: boolean) {
    this.model.isMilitaryMember = obj == true ? 1 : 0;
    this.saveStep();
  }

  doneClicked(f) {
    if (f.valid) {
      this.router.navigate(["/app/refinance/personal-info/6"]);
    }
  }
}
