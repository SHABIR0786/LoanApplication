import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-property-info",
  templateUrl: "./property-info.component.html",
  styleUrls: ["./property-info.component.css"],
})
export class PropertyInfoComponent implements OnInit {
  number: number = 1;
  yes = false;
  isEdit = false;
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
  onNewHomeClick() {
    this.offline.saveStep(3, this.model);
  }
  onNextTwoClick() {
    this.offline.saveStep(3, this.model);
  }
  onNextThreeClick() {
    this.offline.saveStep(3, this.model);
  }
  onCreditClick(e) {
    this.model.creditScore = e;
    this.offline.saveStep(3, this.model);
  }
  onHomeTypeClick(e) {
    this.model.homeType = e;
    this.offline.saveStep(3, this.model);
  }
  onAccountNextClick() {
    this.offline.saveStep(3, this.model);
  }
  onNoaNextClick() {
    this.offline.saveStep(3, this.model);
  }
  onHomePlanClick(e) {
    this.model.homePlan = e;
    this.offline.saveStep(3, this.model);
  }
  onMilitaryClick(e) {
    this.model.isMillitary = e;
    this.offline.saveStep(3, this.model);
  }
  onEditNextClick() {
    this.offline.saveStep(3, this.model);
  }
}
