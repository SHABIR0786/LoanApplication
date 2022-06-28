import { Component, OnInit } from "@angular/core";
import { LoanstatusService } from "../../../shared/service/loanstatus.service";

@Component({
  selector: "app-admin-panel-layout",
  templateUrl: "./admin-panel-layout.component.html",
  styleUrls: ["./admin-panel-layout.component.css"],
})
export class AdminPanelLayoutComponent implements OnInit {
  constructor(private LoanstatusService: LoanstatusService) {}
  toggleSidebar: boolean;
  loanStatus: any;
  loanApplicantName: any;
  loanApplicationNumber: any;
  loanApplicantAddress: any;
  loanProgramName: any;
  loanProgramId: any;

  ngOnInit(): void {
    this.getLoanStatusById();
    this.getLoanDetailsById();

    this.toggleSidebar = false;
    $(document).ready(function () {
      $(".droprdown_class_a").click(function () {
        $(this).toggleClass("active_class");
        $(this).children().toggleClass("caret_active");
        $(this).next().toggleClass("d-none");
      });
      $(".nav_bars_show_active").click(function () {
        $(".buttons_nav").toggleClass("buttons_nav_active");
      });
    });
  }
  toggleSidebarFunc() {
    this.toggleSidebar = !this.toggleSidebar;
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
}
