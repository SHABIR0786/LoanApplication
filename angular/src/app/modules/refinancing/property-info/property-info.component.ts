import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-property-info",
  templateUrl: "./property-info.component.html",
  styleUrls: ["./property-info.component.css", "./../index.component.css"],
})
export class PropertyInfoComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService
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
    this.model = this.offline.getStep().data;
  }

  onScoreClick(obj: string) {
    this.model.creditScore = obj;
    this.saveStep();
  }
  onHomeClick(obj: string) {
    this.model.typeOfHome = obj;
    this.saveStep();
  }
  onCurHome(obj: string) {
    this.model.currentlyUsingHomeAs = obj;
    this.saveStep();
  }
  milClick(obj: boolean) {
    this.model.isMilitaryMember = obj == true ? 1 : 0;
    this.saveStep();
  }
  saveStep() {
    this.offline.saveStep(1, this.model);
  }
}
