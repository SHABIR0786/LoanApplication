import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AddFinanceApiModel, PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-government",
  templateUrl: "./government.component.html",
  styleUrls: ["./government.component.css"],
})
export class GovernmentComponent implements OnInit {
  number: number = 1;
  yes = false;
  model: PostModel = new PostModel();
  apiModel: AddFinanceApiModel = new AddFinanceApiModel();
  cs: any[] = [];
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
    this.getCitizenShipType();
  }
  getCitizenShipType() {
    this.api.get("CitizenshipType/citizenship-types").subscribe((x: any) => {
      this.cs = x.result;
    });
  }
  onGovClick() {
    this.saveStep();
  }
  onQsClick() {
    this.saveStep();
  }
  onAgreeClick() {
    this.saveStep();
  }
  onFinalNext() {
    this.saveStep();
    console.table(this.offline.getStep().data);
    const final = this.apiModel.map(this.model);
    this.api.post("LeadPurchasingDetails/Add", final).subscribe((d: any) => {
      if (d.success === true) {
        alert("Done");
      } else {
        alert("Oops");
        console.clear();
        console.log({ d });
      }
    });
  }
  saveStep() {
    this.offline.saveStep(8, this.model);
  }
}
