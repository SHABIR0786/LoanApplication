import {Component, OnInit} from '@angular/core';
import {NgWizardConfig, NgWizardService, StepChangedArgs, THEME} from 'ng-wizard';

@Component({
    selector: 'app-loan-application',
    templateUrl: './loan-application.component.html',
    styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent implements OnInit {

    loanApplication: any = {
        mortgageType: {},
        propertyInfo: {}
    };

    config: NgWizardConfig = {
        selected: 0,
        theme: THEME.default,
        toolbarSettings: {
            toolbarExtraButtons: [
                {
                    text: 'Finish', class: 'btn btn-info', event: () => {
                        console.log(this.loanApplication);
                    }
                }
            ]
        }
    };

    constructor(private ngWizardService: NgWizardService) {
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
}
