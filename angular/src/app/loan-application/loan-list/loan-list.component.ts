import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IPaginationOptions, PageResult, Result } from "common";
import { LoanApplicationService } from "../../services/loan-application.service";
import { LoanListDto } from "./loan-list.component-types";

@Component({
  selector: "app-loan-list",
  templateUrl: "./loan-list.component.html",
  styleUrls: ["./loan-list.component.css"],
})
export class LoanListComponent implements OnInit {
  data: LoanListDto[] = [];
  totalCount = 0;
  pageNumber = 1;
  pageSize = 10;

  constructor(private _loanApplicationService: LoanApplicationService) {}

  ngOnInit(): void {
    this.loadData({
      maxResultCount: this.pageSize,
      skipCount: (this.pageNumber - 1) * this.pageSize,
    });
  }

  loadData(options: IPaginationOptions) {
    this._loanApplicationService.post("GetAll", options).subscribe(
      (response: Result<PageResult<LoanListDto>>) => {
        this.data = response.result.items;
        this.data = response.result.items;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
