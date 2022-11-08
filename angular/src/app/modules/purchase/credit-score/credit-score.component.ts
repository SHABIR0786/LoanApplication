import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AddFinanceApiModel, PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-credit-score",
  templateUrl: "./credit-score.component.html",
  styleUrls: ["./credit-score.component.css"],
})
export class CreditScoreComponent implements OnInit {
  submitted = false;
  number: number = 1;
  model: PostModel = new PostModel();
  apiModel: AddFinanceApiModel = new AddFinanceApiModel();

  constructor(
    private router: Router,
    private offline: OfflineService,
    private api: ApiService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        router.navigate(["1"]);
      }
    });
  }

  ngOnInit(): void {}

  onAgreeClick() {
    if (this.model.govAgree1 && this.model.govAgree2 && this.model.govAgree3) {
      this.submitted = false;

      this.saveStep();
      this.router.navigate(["/app/purchase/credit-score/2"]);
    } else {
      this.submitted = true;
    }
  }
  saveStep() {
    this.offline.saveStep(8, this.model);
  }

  onFinalNext(f, step) {
    this.submitted = true;
    if (f.valid) {
      this.saveStep();
      const final = this.apiModel.map(this.model);
      this.submitted = false;
      this.api
        .post("LeadPurchasingDetails/update", final)
        .subscribe((d: any) => {
          if (d.success === true) {
            alert("Done");
          } else {
            alert("Oops");
            console.clear();
            console.log({ d });
          }
        });
      this.router.navigate(["/app/purchase/credit-score/" + step]);
    }
  }
}
