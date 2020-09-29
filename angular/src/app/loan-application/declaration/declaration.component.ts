import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IDeclarationModel } from '../../interfaces/IDeclarationModel';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.css']
})
export class DeclarationComponent implements OnInit {

  @Input() data: IDeclarationModel = {};
  @Output() onDataChange: EventEmitter<any> = new EventEmitter<any>();
  form: FormGroup;
  constructor() { }

  ngOnInit(): void {
    this.data = this.form.value;
    if (this.form.valid) {
        this.onDataChange.next(this.form.value);
    }
  }

  initForm() {
    this.form = new FormGroup({
      isOutstandingJudgmentsAgainstYou: new FormControl(this.data.isOutstandingJudgmentsAgainstYou),
      isDeclaredBankrupt: new FormControl(this.data.isDeclaredBankrupt),
      isPropertyForeClosedUponOrGivenTitle: new FormControl(this.data.isPropertyForeClosedUponOrGivenTitle),
      isPartyToLawsuit: new FormControl(this.data.isPartyToLawsuit),
      isObligatedOnAnyLoanWhichResultedForeclosure: new FormControl(this.data.isObligatedOnAnyLoanWhichResultedForeclosure),
      isPresentlyDelinquent: new FormControl(this.data.isPresentlyDelinquent),
      isObligatedToPayAlimonyChildSupport: new FormControl(this.data.isObligatedToPayAlimonyChildSupport),
      isAnyPartOfTheDownPayment: new FormControl(this.data.isAnyPartOfTheDownPayment),
      isCoMakerOrEndorser: new FormControl(this.data.isCoMakerOrEndorser),
      isUSCitizen: new FormControl(this.data.isUSCitizen),
      isPermanentResidentSlien: new FormControl(this.data.isPermanentResidentSlien),
      isIntendToOccupyThePropertyAsYourPrimary: new FormControl(this.data.isIntendToOccupyThePropertyAsYourPrimary),
      isOwnershipInterestInPropertyInTheLastThreeYears: new FormControl(this.data.isOwnershipInterestInPropertyInTheLastThreeYears),
      declarationsSection: new FormControl(this.data.declarationsSection),
    });
  }

}
