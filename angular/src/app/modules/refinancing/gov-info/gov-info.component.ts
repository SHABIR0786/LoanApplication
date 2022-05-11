import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
import { OfflineService } from "@app/services/offline.service";
import { environment } from "environments/environment";
import { ApiService } from "@app/services/api.service";
@Component({
  selector: "app-gov-info",
  templateUrl: "./gov-info.component.html",
  styleUrls: ["./gov-info.component.css", "./../index.component.css"],
})
export class GovInfoComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
  questions: any[] = [];
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
    this.getAllQuestions();
    this.model = this.offline.getStep().data;
  }
  getAllQuestions() {
    let url = "/LeadApplicationQuestions/GetAll";
    this.api.get(url).subscribe((x: any) => {
      this.questions = x.result;
    });
  }
  saveStep() {
    this.offline.saveStep(1, this.model);
  }
}
