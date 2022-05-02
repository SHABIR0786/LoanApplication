import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-personal-info",
  templateUrl: "./personal-info.component.html",
  styleUrls: ["./personal-info.component.css", "./../index.component.css"],
})
export class PersonalInfoComponent implements OnInit {
  number: number = 1;
  model: PostModel = new PostModel();
  states: any[] = [];
  cities: any[] = [];
  dependents: number = 0;
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
    this.model = this.offline.getStep().data;
  }
  getState() {
    this.api.get("State/states").subscribe((x: any) => {
      this.states = x.result;
    });
  }

  onPersClick() {
    this.saveStep();
  }
  referClick(e: boolean) {
    this.model.isSomeOneRefer = e ? 1 : 0;
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
  saveStep() {
    this.offline.saveStep(4, this.model);
  }
}
