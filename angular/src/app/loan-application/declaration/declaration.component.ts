import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IDeclarationModel } from '../../interfaces/IDeclarationModel';
import { IDeclarationBorrowereDemographicsInformationModel } from '../../interfaces/IDeclarationBorrowereDemographicsInformationModel';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.css']
})
export class DeclarationComponent implements OnInit {

  @Input() data: IDeclarationModel = {};
  @Input() data2: IDeclarationBorrowereDemographicsInformationModel = {};
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


      // next tab

      isHispanicOrLatino: new FormControl(this.data2.isHispanicOrLatino),
      isMexican: new FormControl(this.data2.isMexican),
      isPuertoRican: new FormControl(this.data2.isPuertoRican),
      isCuban: new FormControl(this.data2.isCuban),
      isOtherHispanicOrLatino: new FormControl(this.data2.isOtherHispanicOrLatino),
      origin: new FormControl(this.data2.origin),

      isNotHispanicOrLatino: new FormControl(this.data2.isNotHispanicOrLatino),
      isNotProvideInformation: new FormControl(this.data2.isNotProvideInformation),
      isAmericanIndianOrAlaskaNative: new FormControl(this.data2.isAmericanIndianOrAlaskaNative),
      nameOfEnrolledOrPrincipalTribe: new FormControl(this.data2.nameOfEnrolledOrPrincipalTribe),

      isAsian: new FormControl(this.data2.isAsian),
      isAsianIndian: new FormControl(this.data2.isAsianIndian),
      isChinese: new FormControl(this.data2.isChinese),
      isFilipino: new FormControl(this.data2.isFilipino),
      isJapanese: new FormControl(this.data2.isJapanese),
      isKorean: new FormControl(this.data2.isKorean),
      isVietnamese: new FormControl(this.data2.isVietnamese),
      isOtherAsian: new FormControl(this.data2.isOtherAsian),
      enterRace: new FormControl(this.data2.enterRace),


      isBlackOrAfricanAmerican: new FormControl(this.data2.isBlackOrAfricanAmerican),
      isNativeHawaiianOrOtherPacificIslander: new FormControl(this.data2.isNativeHawaiianOrOtherPacificIslander),
      isNativeHawaiian: new FormControl(this.data2.isNativeHawaiian),
      isGuamanianOrChamorro: new FormControl(this.data2.isGuamanianOrChamorro),
      isSamoan: new FormControl(this.data2.isSamoan),
      isOtherPacificIslander: new FormControl(this.data2.isOtherPacificIslander),
      EnterRace2: new FormControl(this.data2.EnterRace2),
      isWhite: new FormControl(this.data2.isWhite),
      isWishToprovideInformation: new FormControl(this.data2.isWishToprovideInformation),

      isMale: new FormControl(this.data2.isMale),
      isFemale: new FormControl(this.data2.isFemale),
      isDonotProvideSexInformattion: new FormControl(this.data2.isDonotProvideSexInformattion),

      
    });
  }

}
