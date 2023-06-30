import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";
import { FinancialServiceServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-assets-info",
  templateUrl: "./assets-info.component.html",
  styleUrls: ["./assets-info.component.css"],
})
export class AssetsInfoComponent implements OnInit {
  number: number = 1;
  yes = false;
  model: PostModel = new PostModel();
  accType: any[] = [];
  submitted = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService,
    private api: ApiService,
    private accountTypeService: FinancialServiceServiceProxy
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
    this.getAccountTypes();
    this.model = this.offline.getStep().data;
  }
  getAccountTypes() {
    this.accountTypeService.getFinancialAccountTypes().subscribe((res) => {
      this.accType = res;
    });
    // this.api.get("Financial/account-types").subscribe((x: any) => {
    //   this.accType = x.result;
    // });
  }
  stepOneClick() {
    this.saveStep();
  }

  saveStep() {
    this.offline.saveStep(6, this.model);
  }

  stepNextClick(f, step) {
    this.submitted = true;
    if (f.valid) {
      this.saveStep();
      this.submitted = false;

      this.router.navigate(["/app/purchase/assets-info/" + step]);
    }
  }
}
