import { Component, OnInit } from "@angular/core";
import { LoanstatusService } from "../../../shared/service/loanstatus.service";
import { AdminDashboardService } from "../../../shared/service/admin-dashboard.service";

@Component({
  selector: "app-admin-dashboard",
  templateUrl: "./admin-dashboard.component.html",
  styleUrls: ["./admin-dashboard.component.css"],
})
export class AdminDashboardComponent implements OnInit {
  constructor(private LoanstatusService: LoanstatusService,private AdminDashboardService:AdminDashboardService) {}
  loanStatus: any;
  loanApplicantName: any;
  loanApplicationNumber: any;
  loanApplicantAddress: any;
  loanProgramName: any;
  loanProgramId: any;
  mortageConsultant: any;
  NMLSId: any;
  formFile: FileParameter;

  ngOnInit(): void {
    this.getLoanStatusById();
    this.getLoanDetailsById();
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

  uploadFile(files:any){
    debugger
    this.formFile = {
      fileName: files[0].name,
      data: files[0],
    };
    var data = {
      UserId:1,
      DisclosureId:1,
      LoanId:1,
      formFile:this.formFile
    }
    this.AdminDashboardService.uploadDocument(data).subscribe((res)=>{

    })
    
  }
}
export interface FileParameter {
  data: any;
  fileName: string;
}
