import { Component, OnInit } from "@angular/core";
import { LoanstatusService } from "../../../shared/service/loanstatus.service";
import { LoanManagementService } from "../../../shared/service/loanmanagement.service";
import {
  AdminLoanDetailServiceServiceProxy,
  AdminLoanProgramServiceServiceProxy,
  AdminLoanStatusServiceServiceProxy,
  AdminLoanSummaryStatusServiceServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { indexOf } from "lodash";
@Component({
  selector: "app-admin-dashboard",
  templateUrl: "./admin-dashboard.component.html",
  styleUrls: ["./admin-dashboard.component.css"],
})
export class AdminDashboardComponent implements OnInit {
  constructor(
    private LoanstatusService: LoanstatusService,
    private LoanManagmentService: LoanManagementService,
    private adminLoanDetailService: AdminLoanDetailServiceServiceProxy,
    private adminLoanProgramService: AdminLoanProgramServiceServiceProxy,
    private adminLoanStatusService: AdminLoanStatusServiceServiceProxy,
    private adminLoanStatusSummaryService: AdminLoanSummaryStatusServiceServiceProxy
  ) {}
  loanStatus: any;
  loanApplicantName: any;
  loanApplicationNumber: any;
  loanApplicantAddress: any;
  loanProgramName: any;
  loanProgramId: any;
  mortageConsultant: any;
  NMLSId: any;
  disclouser: any;
  ////////////////////////
  adminLoanDetails: any;
  adminLoanProgramId: any;
  adminLoanProgramName: any;
  adminLoanId: any;
  adminLoanStatusId: any;
  adminLoanStatus: string;
  title: any;
  ngOnInit(): void {
    this.getLoanStatusById();
    this.getLoanDetailsById();
    this.getAdminDisclouserDetails();
    this.getAdminLoanDetail();
  }
  getAdminLoanDetail() {
    this.adminLoanDetailService.getAll().subscribe((res) => {
      this.adminLoanDetails = res[0];
      this.adminLoanProgramId = this.adminLoanDetails.loanProgramId;
      this.adminLoanId = this.adminLoanDetails.loanApplicationId;
      this.getAdminLoanProgramById();
      this.getAdminLoanSummaryStatusById();
    });
  }
  getAdminLoanProgramById() {
    this.adminLoanProgramService
      .getById(this.adminLoanProgramId)
      .subscribe((res) => {
        this.adminLoanProgramName = res.loanProgram;
      });
  }
  getAdminLoanSummaryStatusById() {
    this.adminLoanStatusSummaryService
      .getById(this.adminLoanId)
      .subscribe((res) => {
        this.adminLoanStatusId = res.statusId;

        this.adminLoanStatusService
          .getById(this.adminLoanStatusId)
          .subscribe((res) => {
            this.adminLoanStatus = res.status;
          });
      });
  }
  ////////////////////////////////
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

  getAdminDisclouserDetails() {
    let obj = {
      params: {
        id: 1,
      },
    };
    this.LoanManagmentService.getallAdminDisclouser(obj).subscribe(
      (res: any) => {
        debugger;
        this.disclouser = res.result.title;
        console.log(res);
      }
    );
  }

  // UploadDocument() {
  //   const content_ = new FormData();

  //   if (loanId === null || loanId === undefined)
  //     throw new Error("The parameter 'loanId' cannot be null.");
  //   else content_.append("LoanId", loanId.toString());

  //   if (disclosureId === null || disclosureId === undefined)
  //     throw new Error("The parameter 'disclosureId' cannot be null.");
  //   else content_.append("DisclosureId", disclosureId.toString());

  //   if (userId === null || userId === undefined)
  //     throw new Error("The parameter 'userId' cannot be null.");
  //   else content_.append("UserId", userId.toString());

  //   if (formFile === null || formFile === undefined)
  //     throw new Error("The parameter 'formFile' cannot be null.");
  //   else
  //     content_.append(
  //       "formFile",
  //       formFile.data,
  //       formFile.fileName ? formFile.fileName : "formFile"
  //     );

  //   let options_: any = {
  //     body: content_,

  //     observe: "response",

  //     responseType: "blob",

  //     headers: new HttpHeaders({
  //       Accept: "text/plain",
  //     }),
  //   };
  //   this.LoanManagmentService.UploadDocument(obj).subscribe();
  // }
}
