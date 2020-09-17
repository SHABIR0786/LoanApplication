import {Component, OnInit} from '@angular/core';
import { BorrowerEmploymentInformation, BorrowerEmploymentInformationServiceProxy, BorrowerInformationServiceProxy, CreateOrUpdateBorrowerEmploymentInformationDto, CreateOrUpdateBorrowerInformationDto, CreateUserDto } from '@shared/service-proxies/service-proxies';
import {NgWizardConfig, NgWizardService, StepChangedArgs, THEME} from 'ng-wizard';

@Component({
    selector: 'app-loan-application',
    templateUrl: './loan-application.component.html',
    styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent implements OnInit {
    [x: string]: any;

    borrowerInformation = new CreateOrUpdateBorrowerInformationDto();
    loanApplication: any = {
        mortgageType: {},
        propertyInfo: {},
        borrowerInformation : new CreateOrUpdateBorrowerInformationDto(),
        coBorrowerInformation : new CreateOrUpdateBorrowerInformationDto(),
        borrowerEmploymentinfromation : new CreateOrUpdateBorrowerEmploymentInformationDto(),
        coBorrowerEmploymentinfromation : new CreateOrUpdateBorrowerEmploymentInformationDto(),
    };

    config: NgWizardConfig = {
        selected: 0,
        theme: THEME.default,
        toolbarSettings: {
            toolbarExtraButtons: [
                {
                    text: 'Save', class: 'btn btn-info', event: () => {
                        console.log(this.loanApplication);
                    }
                }
            ]
        }
    };

    constructor(private ngWizardService: NgWizardService,
        private _borrowerInformationService: BorrowerInformationServiceProxy,
        private _borrowerEmploymentInformationService: BorrowerEmploymentInformationServiceProxy,
        ) {
    }

    ngOnInit(): void {
    }

    showPreviousStep(event?: Event) {
        this.ngWizardService.previous();
    }

    showNextStep(event?: Event) {
        this.ngWizardService.next();
    }

    resetWizard(event?: Event) {
        this.ngWizardService.reset();
    }

    setTheme(theme: THEME) {
        this.ngWizardService.theme(theme);
    }

    stepChanged(args: StepChangedArgs) {
        console.log(args.step);
    }

    finish(){
        this.loanApplication.borrowerInformation.tenantId = this.appSession.tenantId;
        this.loanApplication.coBorrowerInformation.tenantId = this.appSession.tenantId;
         this._borrowerInformationService.createOrUpdate(this.loanApplication.borrowerInformation)
         .subscribe((result)=>{
            if(result){

            }
         });

         this._borrowerInformationService.createOrUpdate(this.loanApplication.coBorrowerInformation)
         .subscribe((result)=>{
            if(result){
                
            }
         });

         this.loanApplication.borrowerEmploymentinfromation.tenantId = this.appSession.tenantId;
         this.loanApplication.coBorrowerEmploymentinfromation.tenantId = this.appSession.tenantId;


         this._borrowerEmploymentInformationService.createOrUpdate(this.loanApplication.borrowerEmploymentinfromation)
         .subscribe((result)=>{
            if(result){
                
            }
         });

         this._borrowerEmploymentInformationService.createOrUpdate(this.loanApplication.coBorrowerEmploymentinfromation)
         .subscribe((result)=>{
            if(result){
                
            }
         });
    }
}
