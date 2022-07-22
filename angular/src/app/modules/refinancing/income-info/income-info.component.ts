import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {
  EmployementDetailAdd,
  RefinancePost,
} from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-income-info",
  templateUrl: "./income-info.component.html",
  styleUrls: ["./income-info.component.css", "./../index.component.css"],
})
export class IncomeInfoComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
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
  // routerLink="/app/refinance/assets-info/1"
  callToDb() {
    this.api
      .post("LeadRefinancingDetails/Add", this.model)
      .subscribe((x: any) => {
        if (x.success == true) {
          this.model.leadApplicationDetailRefinancingId = 1;
          this.saveStep();
          this.router.navigate(["/app/refinance/assets-info/1"]);
        }
        console.log({ x });
      });
  }
  saveEmpToDb() {
    let _model: EmployementDetailAdd = new EmployementDetailAdd();
    _model.leadApplicationDetailRefinancingId = 1;
    _model.employeeTypeId = this.model.w2Emp;
    _model.employerName = this.model.w2EmpName;
    _model.employementAddress = this.model.empAddress;
    _model.employementSuite = this.model.empAptUnit;
    _model.employementCity = this.model.empCity;
    _model.employementTaxeId = this.model.empState;
    _model.employementZip = this.model.empZip;
    _model.employerPhoneNumber = this.model.empPhoneNumber;
    _model.isCurrentJob = this.model.isCurrentJob;
    _model.estimatedStartDate = this.model.empEstDate;
    _model.jobTitle = this.model.jobTitle;
    _model.estimatedAnnualBaseSalary = this.model.estAnnualBaseSalary;
    _model.estimatedAnnualBonus = this.model.estAnnualBonus;
    _model.estimatedAnnualCommission = this.model.estAnnualCommision;
    _model.estimatedAnnualOvertime = this.model.estAnnualOverTime;
    _model.isCoBorrower = this.model.coboIncType;
    this.api.post("/LeadEmploymentDetail/Add", _model).subscribe((x: any) => {
      if (x.success == true) {
        this.router.navigate(["/app/refinance/income/5"]);
      }
    });
  }
  saveStep() {
    this.offline.saveStep(4, this.model);
  }
}
