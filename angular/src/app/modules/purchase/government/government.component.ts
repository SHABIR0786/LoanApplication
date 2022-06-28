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
  questions: any[] = [];
  ans = [{ id: 1, jwab: 1 }];
  qans(id) {
    return this.ans.find((x) => x.id == id) ? 1 : 0;
  }
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
    this.getAllQuestions();
  }
  getCitizenShipType() {
    this.api.get("CitizenshipType/citizenship-types").subscribe((x: any) => {
      this.cs = x.result;
    });
  }
  getAllQuestions() {
    let url = "/LeadApplicationQuestions/GetAll";
    this.api.get(url).subscribe((x: any) => {
      this.questions = x.result;
    });
  }
  onGovClick() {
    const final = this.apiModel.map(this.model);
    this.api.post("LeadPurchasingDetails/update", final).subscribe((d: any) => {
      if (d.success === true) {
        this.router.navigate(["/app/purchase/gov/2"]);
        this.model.leadApplicationDetailPurchasingId = 1;
        alert("Done");
      } else {
        alert("Oops");
        console.clear();
        console.log({ d });
      }
    });
    this.saveStep();
  }
  onQsClick() {
    this.saveStep();
  }
  onAgreeClick() {
    this.saveStep();
  }
  onQAns(id, ans) {
    let req: any = {
      leadApplicationDetailPurchasingId: this.model
        .leadApplicationDetailPurchasingId,
      questionId: id,
      isYes: ans,
    };
    let url = "/LeadQuestionAnswers/Add";
    this.api.post(url, req).subscribe((x) => {
      console.log(id);
    });
  }
  onFinalNext() {
    this.saveStep();
    const final = this.apiModel.map(this.model);

    this.api.post("LeadPurchasingDetails/update", final).subscribe((d: any) => {
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
