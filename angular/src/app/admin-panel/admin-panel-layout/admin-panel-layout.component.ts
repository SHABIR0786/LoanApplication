import { Component, OnInit, Input } from "@angular/core";
import { LoanstatusService } from "../../../shared/service/loanstatus.service";

@Component({
  selector: "app-admin-panel-layout",
  templateUrl: "./admin-panel-layout.component.html",
  styleUrls: ["./admin-panel-layout.component.css"],
})
export class AdminPanelLayoutComponent implements OnInit {
  @Input() pageName: string;
  constructor(private LoanstatusService: LoanstatusService) {}

  loanStatus: any;
  loanApplicantName: any;
  loanApplicationNumber: any;
  loanApplicantAddress: any;
  loanProgramName: any;
  loanProgramId: any;
  mortageConsultant: any;
  NMLSId: any;

  ngOnInit(): void {
    this.getLoanStatusById();
    this.getLoanDetailsById();
    debugger;
    console.log("pageName", this.pageName);
  }

  getLoanStatusById() {
    let obj = {
      params: {
        id: 1,
      },
    };
    this.LoanstatusService.getLoanStatusbyId(obj).subscribe((res: any) => {
      this.loanStatus = res.result.status;
    });
  }

  getLoanDetailsById() {
    let obj = {
      params: {
        id: 1,
      },
    };
    this.LoanstatusService.getLoanDetailsById(obj).subscribe(
      (loanDetails: any) => {
        console.log(loanDetails);
        this.loanApplicantName = loanDetails.result.borrowerName;
        this.loanApplicationNumber = loanDetails.result.loanNo;
        this.loanApplicantAddress = loanDetails.result.propertyAddress;
        this.mortageConsultant = loanDetails.result.mortageConsultant;
        this.NMLSId = loanDetails.result.nmlsId;
        this.getLoanProgramById(loanDetails.result.loanProgramId);
      }
    );
  }

  getLoanProgramById(programId: any) {
    let obj = {
      params: {
        id: programId,
      },
    };
    this.LoanstatusService.getLoanProgramDetailsById(obj).subscribe(
      (result: any) => {
        this.loanProgramName = result.result.loanProgram;
      }
    );
  }

  checkProfilePageView() {
    if (!localStorage.getItem("profilePage"))
      localStorage.setItem("profilePage", "true");
    else localStorage.removeItem("profilePage");
    return localStorage.getItem("profilePage") ? false : true;
  }
}
