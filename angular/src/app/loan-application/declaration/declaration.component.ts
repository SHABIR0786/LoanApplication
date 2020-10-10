import { Component, DoCheck, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { IBorrowerDeclarationModel } from "../../interfaces/IBorrowerDeclarationModel";
import { IDeclarationModel } from "../../interfaces/IDeclarationModel";
import { IBorrowerDemographicModel } from "../../interfaces/IBorrowerDemographicModel";
import { NgWizardConfig, NgWizardService, THEME } from "ng-wizard";
import { ILoanApplicationModel } from "../../interfaces/ILoanApplicationModel";
import { DataService } from "../../services/data.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-declaration",
  templateUrl: "./declaration.component.html",
  styleUrls: ["./declaration.component.css"],
})
export class DeclarationComponent implements OnInit, DoCheck {
  config: NgWizardConfig = {
    selected: 0,
    theme: THEME.default,
    anchorSettings: {
      markDoneStep: false,
      enableAllAnchors: true,
    },
    toolbarSettings: {
      showNextButton: false,
      showPreviousButton: false,
      toolbarExtraButtons: [
        /*{
                    text: 'Save', class: 'btn btn-info', event: () => {
                        const formData = this.sanitizeFormData();
                        this._loanApplicationService.post('Add', formData).subscribe((response: any) => {
                            this.loanApplication = this.prepareFormData(response.result);
                        }, error => {
                            console.log(error);
                        });
                    }
                }*/
      ],
    },
  };

  data: IDeclarationModel = {
    borrowerDeclaration: {},
    borrowerDemographic: {},

    coBorrowerDeclaration: {},
    coBorrowerDemographic: {},
  };
  isApplyingWithCoBorrower = false;
  form: FormGroup;
  borrowerEthnics = [
    {
      id: 1,
      name: "Hispanic or Latino",
      checked: false,
    },
    {
      id: 2,
      name: "Mexican",
    },
    {
      id: 3,
      name: "Puerto Rican",
    },
    {
      id: 4,
      name: "Cuban",
    },
    {
      id: 5,
      name: "Other Hispanic or Latino - Enter Origin",
      hasInput: true,
      description:
        "For example: Argentinean, Colombian, Dominican, Nicaraguan, Salvadoran, Spaniard, and so on.",
    },
    {
      id: 6,
      name: "Not Hispanic or Latino",
    },
    {
      id: 7,
      name: "I do not wish to provide this information.",
    },
  ];
  borrowerRaces = [
    {
      id: 1,
      name: "American Indian or Alaska Native",
      checked: false,
      hasInput: true,
      description: "Enter name of enrolled or principal tribe:",
    },
    {
      id: 2,
      name: "Asian",
    },
    {
      id: 3,
      name: "Asian Indian",
    },
    {
      id: 4,
      name: "Chinese",
    },
    {
      id: 5,
      name: "Filipino",
    },
    {
      id: 6,
      name: "Japanese",
    },
    {
      id: 7,
      name: "Korean",
    },
    {
      id: 8,
      name: "Vietnamese",
    },
    {
      id: 9,
      name: "Other Asian - Enter Race:",
      hasInput: true,
      description:
        "For example: Hmong, Laotian, Thai, Pakistani, Cambodian, and so on.",
    },
    {
      id: 10,
      name: "Black or African American",
    },
    {
      id: 11,
      name: "Native Hawaiian or Other Pacific Islander",
    },
    {
      id: 12,
      name: "Native Hawaiian",
    },
    {
      id: 13,
      name: "Guamanian or Chamorro",
    },
    {
      id: 14,
      name: "Samoan",
    },
    {
      id: 15,
      name: "Other Pacific Islander - Enter Race:",
      hasInput: true,
      description: "For example: Fijian, Tongan, and so on.",
    },
    {
      id: 16,
      name: "White",
    },
    {
      id: 17,
      name: "I do not wish to provide this information.",
    },
  ];
  borrowerSexArr = [
    {
      id: 1,
      name: "Female",
      checked: false,
    },
    {
      id: 2,
      name: "Male",
    },
    {
      id: 3,
      name: "I do not wish to provide this information.",
    },
  ];

  coBorrowerEthnics = [
    {
      id: 1,
      name: "Hispanic or Latino",
      checked: false,
    },
    {
      id: 2,
      name: "Mexican",
    },
    {
      id: 3,
      name: "Puerto Rican",
    },
    {
      id: 4,
      name: "Cuban",
    },
    {
      id: 5,
      name: "Other Hispanic or Latino - Enter Origin",
      hasInput: true,
      description:
        "For example: Argentinean, Colombian, Dominican, Nicaraguan, Salvadoran, Spaniard, and so on.",
    },
    {
      id: 6,
      name: "Not Hispanic or Latino",
    },
    {
      id: 7,
      name: "I do not wish to provide this information.",
    },
  ];
  coBorrowerRaces = [
    {
      id: 1,
      name: "American Indian or Alaska Native",
      checked: false,
      hasInput: true,
      description: "Enter name of enrolled or principal tribe:",
    },
    {
      id: 2,
      name: "Asian",
    },
    {
      id: 3,
      name: "Asian Indian",
    },
    {
      id: 4,
      name: "Chinese",
    },
    {
      id: 5,
      name: "Filipino",
    },
    {
      id: 6,
      name: "Japanese",
    },
    {
      id: 7,
      name: "Korean",
    },
    {
      id: 8,
      name: "Vietnamese",
    },
    {
      id: 9,
      name: "Other Asian - Enter Race:",
      hasInput: true,
      description:
        "For example: Hmong, Laotian, Thai, Pakistani, Cambodian, and so on.",
    },
    {
      id: 10,
      name: "Black or African American",
    },
    {
      id: 11,
      name: "Native Hawaiian or Other Pacific Islander",
    },
    {
      id: 12,
      name: "Native Hawaiian",
    },
    {
      id: 13,
      name: "Guamanian or Chamorro",
    },
    {
      id: 14,
      name: "Samoan",
    },
    {
      id: 15,
      name: "Other Pacific Islander - Enter Race:",
      hasInput: true,
      description: "For example: Fijian, Tongan, and so on.",
    },
    {
      id: 16,
      name: "White",
    },
    {
      id: 17,
      name: "I do not wish to provide this information.",
    },
  ];
  coBorrowerSexArr = [
    {
      id: 1,
      name: "Female",
      checked: false,
    },
    {
      id: 2,
      name: "Male",
    },
    {
      id: 3,
      name: "I do not wish to provide this information.",
    },
  ];

  constructor(
    private _ngWizardService: NgWizardService,
    private _dataService: DataService,
    private _route: Router
  ) { }

  ngOnInit(): void {
    this.data = this._dataService.loanApplication.declaration;
    const loanApplication = this._dataService.loanApplication;
    this.isApplyingWithCoBorrower =
      loanApplication.personalInformation &&
      loanApplication.personalInformation.isApplyingWithCoBorrower;

    this.initForm();

    this._dataService.formData.subscribe((formData: ILoanApplicationModel) => {
      if (formData && formData.declaration) {
        this.form.patchValue(formData.declaration);
      }
    });
  }

  ngDoCheck(): void {
    this.data = this.form.value;
    this._dataService.updateData(this.form.value, "declaration");
  }

  initForm() {
    this.form = new FormGroup({
      id: new FormControl(this.data.id),
      borrowerDeclaration: this.initDeclarationForm(
        this.data.borrowerDeclaration
      ),
      borrowerDemographic: this.initDemographicForm(
        this.data.borrowerDemographic
      ),
    });

    if (this.data.borrowerDemographic) {
      this.data.borrowerDemographic.ethnicity.forEach(element => {
        this.borrowerEthnics.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });

      this.data.borrowerDemographic.race.forEach(element => {
        this.borrowerRaces.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });

      this.data.borrowerDemographic.sex.forEach(element => {
        this.borrowerSexArr.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });
    }


    if (this.data.coBorrowerDemographic) {
      this.data.coBorrowerDemographic.ethnicity.forEach(element => {
        this.coBorrowerEthnics.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });

      this.data.coBorrowerDemographic.race.forEach(element => {
        this.coBorrowerRaces.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });

      this.data.coBorrowerDemographic.sex.forEach(element => {
        this.coBorrowerSexArr.forEach(item => {
          if (element.id == item.id) {
            item.checked = true;
          }
        });
      });
    }



    if (this.isApplyingWithCoBorrower) {
      this.data.coBorrowerDeclaration = {};
      this.data.coBorrowerDemographic = {};
      this.form.addControl(
        "coBorrowerDeclaration",
        this.initDeclarationForm(this.data.coBorrowerDeclaration)
      );
      this.form.addControl(
        "coBorrowerDemographic",
        this.initDemographicForm(this.data.coBorrowerDemographic)
      );
    } else {
      this.form.removeControl("coBorrowerDeclaration");
      this.form.removeControl("coBorrowerDemographic");
    }
  }

  initDeclarationForm(
    borrowerDeclaration: IBorrowerDeclarationModel
  ): FormGroup {
    return new FormGroup({
      id: new FormControl(borrowerDeclaration.id),
      isOutstandingJudgmentsAgainstYou: new FormControl(
        borrowerDeclaration.isOutstandingJudgmentsAgainstYou
      ),
      isDeclaredBankrupt: new FormControl(
        borrowerDeclaration.isDeclaredBankrupt
      ),
      isPropertyForeClosedUponOrGivenTitle: new FormControl(
        borrowerDeclaration.isPropertyForeClosedUponOrGivenTitle
      ),
      isPartyToLawsuit: new FormControl(borrowerDeclaration.isPartyToLawsuit),
      isObligatedOnAnyLoanWhichResultedForeclosure: new FormControl(
        borrowerDeclaration.isObligatedOnAnyLoanWhichResultedForeclosure
      ),
      isPresentlyDelinquent: new FormControl(
        borrowerDeclaration.isPresentlyDelinquent
      ),
      isObligatedToPayAlimonyChildSupport: new FormControl(
        borrowerDeclaration.isObligatedToPayAlimonyChildSupport
      ),
      isAnyPartOfTheDownPayment: new FormControl(
        borrowerDeclaration.isAnyPartOfTheDownPayment
      ),
      isCoMakerOrEndorser: new FormControl(
        borrowerDeclaration.isCoMakerOrEndorser
      ),
      isUSCitizen: new FormControl(borrowerDeclaration.isUSCitizen),
      isPermanentResidentSlien: new FormControl(
        borrowerDeclaration.isPermanentResidentSlien
      ),
      isIntendToOccupyThePropertyAsYourPrimary: new FormControl(
        borrowerDeclaration.isIntendToOccupyThePropertyAsYourPrimary
      ),
      isOwnershipInterestInPropertyLastThreeYears: new FormControl(
        borrowerDeclaration.isOwnershipInterestInPropertyLastThreeYears
      ),
      declarationsSection: new FormControl(
        borrowerDeclaration.declarationsSection
      ),
    });
  }

  initDemographicForm(
    borrowerDemographic: IBorrowerDemographicModel
  ): FormGroup {
    return new FormGroup({
      id: new FormControl(borrowerDemographic.id),
      ethnicity: new FormControl(borrowerDemographic.ethnicity || []),
      race: new FormControl(borrowerDemographic.race || []),
      sex: new FormControl(borrowerDemographic.sex || []),
    });
  }

  updateEthnicFormControl(borrowerType) {
    const values = this[`${borrowerType}Ethnics`]
      .filter((e) => e.checked)
      .map((e: any) => ({
        id: e.id,
        otherValue: e.otherValue,
      }));
    this.form
      .get(`${borrowerType}Demographic`)
      .get("ethnicity")
      .setValue(values);
  }

  updateRaceFormControl(borrowerType) {
    const values = this[`${borrowerType}Races`]
      .filter((e) => e.checked)
      .map((e: any) => ({
        id: e.id,
        otherValue: e.otherValue,
      }));
    this.form.get(`${borrowerType}Demographic`).get("race").setValue(values);
  }

  updateSexFormControl(borrowerType) {
    const values = this[`${borrowerType}SexArr`]
      .filter((e) => e.checked)
      .map((e: any) => ({
        id: e.id,
      }));
    this.form.get(`${borrowerType}Demographic`).get("sex").setValue(values);
  }

  proceedToNext(event?: string) {
    debugger;
    if (event === "wizardStep") {
      this._ngWizardService.next();
    } else {
      if (this.form.valid) {
        this._route.navigate(["app/summary"]);
      } else {
        this.form.markAllAsTouched();
      }
    }
  }

  proceedToPrevious(event?: string) {
    if (event === "wizardStep") {
      this._ngWizardService.previous();
    } else {
      this._route.navigate(["app/econsent"]);
    }
  }
}
