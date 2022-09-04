import { Component, OnInit } from '@angular/core';
import { LoanManagementService } from '@shared/service/loanmanagement.service';

@Component({
  selector: 'app-loan-application-list',
  templateUrl: './loan-application-list.component.html',
  styleUrls: ['./loan-application-list.component.css']
})
export class LoanApplicationListComponent implements OnInit {
  Custom: any[];
  constructor(private LoanManagmentService: LoanManagementService) { }

  ngOnInit(): void {
    this.getLoanApplicationList();
  }
  getLoanApplicationList(){
    let obj = {
      params: {
        keyword: '',
        skip: 0,
        MaxResultCount:100
      },
    };
  this.LoanManagmentService.getLoanApplicationList(obj, null).subscribe(
    (res: any) => {
      console.log(res.result)
      this.Custom = res.result.items
    }
  );
}
}
