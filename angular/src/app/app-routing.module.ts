import { GetLoanAppResolve } from "./resolver/loan-app-get-resolve";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { AppRouteGuard } from "@shared/auth/auth-route-guard";
import { HomeComponent } from "./home/home.component";
import { AboutComponent } from "./about/about.component";
import { UsersComponent } from "./users/users.component";
import { TenantsComponent } from "./tenants/tenants.component";
import { RolesComponent } from "app/roles/roles.component";
import { ChangePasswordComponent } from "./users/change-password/change-password.component";
import { LoanApplicationComponent } from "./loan-application/loan-application.component";
import { LoanDetailsComponent } from "./loan-application/loan-details/loan-details.component";
import { PersonalInformationComponent } from "./loan-application/personal-information/personal-information.component";
import { ExpensesComponent } from "./loan-application/expenses/expenses.component";
import { AssetsComponent } from "./loan-application/assets/assets.component";
import { EmploymentIncomeComponent } from "./loan-application/employment-income/employment-income.component";
import { SummaryComponent } from "./loan-application/summary/summary.component";
import { DeclarationComponent } from "./loan-application/declaration/declaration.component";
import { EconsentComponent } from "./loan-application/econsent/econsent.component";
import { OrderCreditComponent } from "./loan-application/order-credit/order-credit.component";
import { AdditionalDetailsComponent } from "./loan-application/additional-details/additional-details.component";
import { LoanListComponent } from "./loan-application/loan-list/loan-list.component";
import { AdminPanelComponent } from "./admin-panel/admin-panel.component";
// New routes added by shabir
import { HomeAffordabilityCalculatorComponent } from "./calculators/home-affordability-calculator/home-affordability-calculator.component";
import { MortgageCalculatorComponent } from "./calculators/mortgage-calculator/mortgage-calculator.component";
import { RefinanceCalculatorComponent } from "./calculators/refinance-calculator/refinance-calculator.component";
import { AmortizationComponent } from "./calculators/amortization/amortization.component";
import { AffordabilityComponent } from "./calculators/affordability/affordability.component";
import { ViewAllCalculatorsComponent } from "./calculators/view-all-calculators/view-all-calculators.component";
import { BuyingHomeGuideComponent } from "./buying-home-guide/buying-home-guide.component";
import { FirstTimeHomeBuyerComponent } from "./first-time-home-buyer/first-time-home-buyer.component";
import { BuyingSecondHomeComponent } from "./buying-second-home/buying-second-home.component";
import { BuyingVacationHomeComponent } from "./buying-vacation-home/buying-vacation-home.component";
import { HomeBuyingFreeConsultationComponent } from "./home-buying-free-consultation/home-buying-free-consultation.component";
import { MovingAndBuyingHomeComponent } from "./moving-and-buying-home/moving-and-buying-home.component";
import { PreApprovalComponent } from "./pre-approval/pre-approval.component";
import { RealStateInvestorComponent } from "./real-state-investor/real-state-investor.component";
import { LowerYourPaymentComponent } from "./refinance/lower-your-payment/lower-your-payment.component";
import { GetCashFromYourHomeComponent } from "./refinance/get-cash-from-your-home/get-cash-from-your-home.component";
import { ConsolidateYourDebitComponent } from "./refinance/consolidate-your-debit/consolidate-your-debit.component";
import { KeepYourPaymentFromRaisingComponent } from "./refinance/keep-your-payment-from-raising/keep-your-payment-from-raising.component";
import { PayOffYourMortgageFasterComponent } from "./refinance/pay-off-your-mortgage-faster/pay-off-your-mortgage-faster.component";
import { RefinanceFreeConsultationComponent } from "./refinance/refinance-free-consultation/refinance-free-consultation.component";
import { RefinanceInvestmentPropertyComponent } from "./refinance/refinance-investment-property/refinance-investment-property.component";
import { RefinanceWithHARPComponent } from "./refinance/refinance-with-harp/refinance-with-harp.component";
// Loan Options
import { LoanOptionsComponent } from "./loan-options/loan-options.component";
import { AdjustableRateMortgageComponent } from "./loan-options/adjustable-rate-mortgage/adjustable-rate-mortgage.component";
import { FhaLoansComponent } from "./loan-options/fha-loans/fha-loans.component";
import { FifteenYearFixedMortgageComponent } from "./loan-options/fifteen-year-fixed-mortgage/fifteen-year-fixed-mortgage.component";
import { HarpRefinanceComponent } from "./loan-options/harp-refinance/harp-refinance.component";
import { JumboLoanComponent } from "./loan-options/jumbo-loan/jumbo-loan.component";
import { ThirtyYearFixedMortgageComponent } from "./loan-options/thirty-year-fixed-mortgage/thirty-year-fixed-mortgage.component";
import { BlogComponent } from "./blog/blog.component";
import { AnimatedComponent } from "./refinance/animated/animated.component";
import { Step1Component } from "./refinance/step1/step1.component";
import { Step2Component } from "./refinance/step2/step2.component";
import { Step3Component } from "./refinance/step3/step3.component";
import { Step4Component } from "./refinance/step4/step4.component";
import { Step5Component } from "./refinance/step5/step5.component";
import { Step6Component } from "./refinance/step6/step6.component";
import { Step7Component } from "./refinance/step7/step7.component";
import { Step8Component } from "./refinance/step8/step8.component";
import { Step9Component } from "./refinance/step9/step9.component";
import { Step10Component } from "./refinance/step10/step10.component";
import { Step11Component } from "./refinance/step11/step11.component";
import { Step12Component } from "./refinance/step12/step12.component";
import { Step13Component } from "./refinance/step13/step13.component";
import { Step14Component } from "./refinance/step14/step14.component";
import { Step15Component } from "./refinance/step15/step15.component";
import { Step16Component } from "./refinance/step16/step16.component";
import { Step17Component } from "./refinance/step17/step17.component";
import { Step18Component } from "./refinance/step18/step18.component";
import { Step19Component } from "./refinance/step19/step19.component";
import { AboutUsComponent } from "./about-us/about-us.component";
import { RequestAMortgageComponent } from "./about-us/request-a-mortgage/request-a-mortgage.component";
import { ContactUsComponent } from "./about-us/contact-us/contact-us.component";
import { LicenseInfoComponent } from "./about-us/license-info/license-info.component";
import { MortgageGlossaryComponent } from "./about-us/mortgage-glossary/mortgage-glossary.component";
import { CurrentHomeLoanRatesComponent } from "./current-home-loan-rates/current-home-loan-rates.component";
import { EmailAndTextUpdatesComponent } from "./email-and-text-updates/email-and-text-updates.component";
import { FinalizingMortgagePreApprovalComponent } from "./buying-home-guide/finalizing-mortgage-pre-approval/finalizing-mortgage-pre-approval.component";
import { DecidingMortgageComponent } from "./buying-home-guide/deciding-mortgage/deciding-mortgage.component";
import { SelectionRealEstateAgentComponent } from "./buying-home-guide/selection-real-estate-agent/selection-real-estate-agent.component";
import { HouseHuntingComponent } from "./buying-home-guide/house-hunting/house-hunting.component";
import { MakingACompetitiveOfferComponent } from "./buying-home-guide/making-a-competitive-offer/making-a-competitive-offer.component";
import { UnderwritingProcessComponent } from "./buying-home-guide/underwriting-process/underwriting-process.component";
import { PreparingToCloseComponent } from "./buying-home-guide/preparing-to-close/preparing-to-close.component";
import { WalkThroughAndClosingDayComponent } from "./buying-home-guide/walk-through-and-closing-day/walk-through-and-closing-day.component";
import { MakingYourFirstMortgagePaymentComponent } from "./buying-home-guide/making-your-first-mortgage-payment/making-your-first-mortgage-payment.component";
import { ManagingYourMortgageComponent } from "./buying-home-guide/managing-your-mortgage/managing-your-mortgage.component";
import { VaLoanComponent } from "./loan-options/va-loan/va-loan.component";
import { AmortizationResultComponent } from "./calculators/amortization/amortization-result/amortization-result.component";
import { RefinanceLoanOptionsStep1Component } from "./Refinance_loan_option_animated/step1/step1.component";
import { RefinanceLoanOptionsStep2Component } from "./Refinance_loan_option_animated/step2/step2.component";
import { RefinanceLoanOptionsStep3Component } from "./Refinance_loan_option_animated/step3/step3.component";
import { RefinanceLoanOptionsStep4Component } from "./Refinance_loan_option_animated/step4/step4.component";
import { RefinanceLoanOptionsStep5Component } from "./Refinance_loan_option_animated/step5/step5.component";
import { AnimatedOneComponent } from "./Refinance_loan_option_animated/animated/animated.component";
import { RefinanceLoanOptionsStep6Component } from "./Refinance_loan_option_animated/step6/step6.component";
import { RefinanceLoanOptionsStep7Component } from "./Refinance_loan_option_animated/step7/step7.component";
import { RefinanceLoanOptionsStep8Component } from "./Refinance_loan_option_animated/step8/step8.component";
import { RefinanceLoanOptionsStep9Component } from "./Refinance_loan_option_animated/step9/step9.component";
import { RefinanceLoanOptionsStep10Component } from "./Refinance_loan_option_animated/step10/step10.component";
import { RefinanceLoanOptionsStep11Component } from "./Refinance_loan_option_animated/step11/step11.component";
import { RefinanceLoanOptionsStep12Component } from "./Refinance_loan_option_animated/step12/step12.component";
import { RefinanceLoanOptionsStep13Component } from "./Refinance_loan_option_animated/step13/step13.component";
import { RefinanceLoanOptionsStep14Component } from "./Refinance_loan_option_animated/step14/step14.component";
import { RefinanceLoanOptionsStep15Component } from "./Refinance_loan_option_animated/step15/step15.component";
import { RefinanceLoanOptionsStep16Component } from "./Refinance_loan_option_animated/step16/step16.component";
import { RefinanceLoanOptionsStep17Component } from "./Refinance_loan_option_animated/step17/step17.component";
import { RefinanceLoanOptionsStep18Component } from "./Refinance_loan_option_animated/step18/step18.component";
import { BuyAHomeComponent } from './buy-a-home/buy-a-home.component';
import { AnimatedStep1Component } from './buy-a-home/animated-step1/animated-step1.component';
import { AnimatedStep2Component } from './buy-a-home/animated-step2/animated-step2.component';
import { AnimatedStep3Component } from './buy-a-home/animated-step3/animated-step3.component';
import { AnimatedStep4Component } from './buy-a-home/animated-step4/animated-step4.component';
import { AnimatedStep5Component } from './buy-a-home/animated-step5/animated-step5.component';
import { AnimatedStep6Component } from './buy-a-home/animated-step6/animated-step6.component';
import { AnimatedStep7Component } from './buy-a-home/animated-step7/animated-step7.component';
import { AnimatedStep8Component } from './buy-a-home/animated-step8/animated-step8.component';
import { AnimatedStep9Component } from './buy-a-home/animated-step9/animated-step9.component';
import { AnimatedStep10Component } from './buy-a-home/animated-step10/animated-step10.component';
import { AnimatedStep11Component } from './buy-a-home/animated-step11/animated-step11.component';
import { AnimatedStep12Component } from './buy-a-home/animated-step12/animated-step12.component';
import { AnimatedStep13Component } from './buy-a-home/animated-step13/animated-step13.component';
import { AnimatedStep14Component } from './buy-a-home/animated-step14/animated-step14.component';
import { AnimatedStep15Component } from './buy-a-home/animated-step15/animated-step15.component';
import { AnimatedStep16Component } from './buy-a-home/animated-step16/animated-step16.component';
import { AnimatedStep17Component } from './buy-a-home/animated-step17/animated-step17.component';
import { AnimatedStep18Component } from './buy-a-home/animated-step18/animated-step18.component';
import { AnimatedStep19Component } from './buy-a-home/animated-step19/animated-step19.component';



@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: "",
        component: AppComponent,
        children: [
          {
            path: "home",
            component: HomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "users",
            component: UsersComponent,
            data: { permission: "Pages.Users" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "roles",
            component: RolesComponent,
            data: { permission: "Pages.Roles" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "tenants",
            component: TenantsComponent,
            data: { permission: "Pages.Tenants" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "loan-list",
            component: LoanListComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "apply-loan",
            component: LoanApplicationComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
          },
          {
            path: "loan-detail",
            component: LoanDetailsComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "personal-information",
            component: PersonalInformationComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "expense",
            component: ExpensesComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "asset",
            component: AssetsComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "employment-income",
            component: EmploymentIncomeComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "order-credit",
            component: OrderCreditComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "additional-detail",
            component: AdditionalDetailsComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "econsent",
            component: EconsentComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "declaration",
            component: DeclarationComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          {
            path: "summary",
            component: SummaryComponent,
            data: { permission: "" },
            canActivate: [AppRouteGuard],
            resolve: {
              loanApp: GetLoanAppResolve,
            },
          },
          { path: "about", component: AboutComponent },
          { path: "update-password", component: ChangePasswordComponent },
          {
            path: "admin-panel",
            component: AdminPanelComponent,
          },
          {
            path: "home-affordability-calculator",
            component: HomeAffordabilityCalculatorComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "mortgage-calculator",
            component: MortgageCalculatorComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-calculator",
            component: RefinanceCalculatorComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "amortization",
            component: AmortizationComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "affordability",
            component: AffordabilityComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "view-all-calculators",
            component: ViewAllCalculatorsComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buying-home-guide",
            component: BuyingHomeGuideComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buying-second-home",
            component: BuyingSecondHomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buying-vacation-home",
            component: BuyingVacationHomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "first-time-home-buyer",
            component: FirstTimeHomeBuyerComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "home-buying-free-consultation",
            component: HomeBuyingFreeConsultationComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "moving-and-buying-home",
            component: MovingAndBuyingHomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "pre-approval",
            component: PreApprovalComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "real-state-investor",
            component: RealStateInvestorComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "consolidate-your-debt",
            component: ConsolidateYourDebitComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "get-cash-from-home",
            component: GetCashFromYourHomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "keep-your-payment-raising",
            component: KeepYourPaymentFromRaisingComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "lower-your-payment",
            component: LowerYourPaymentComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "pay-off-your-mortgage-faster",
            component: PayOffYourMortgageFasterComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-free-consultation",
            component: RefinanceFreeConsultationComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-investment-property",
            component: RefinanceInvestmentPropertyComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-with-harp",
            component: RefinanceWithHARPComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "adjustable-rate-mortgage",
            component: AdjustableRateMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "fha-loans",
            component: FhaLoansComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "fifteen-year-fixed-mortgage",
            component: FifteenYearFixedMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "jumbo-loan",
            component: JumboLoanComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "thirty-year-fixed-mortgage",
            component: ThirtyYearFixedMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "loan-options",
            component: LoanOptionsComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "va-loan",
            component: VaLoanComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "blog",
            component: BlogComponent,
            canActivate: [AppRouteGuard],
          },

          {
            path: "about-us",
            component: AboutUsComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "request-a-mortgage",
            component: RequestAMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "contact-us",
            component: ContactUsComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "license-info",
            component: LicenseInfoComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "mortgage-glossary",
            component: MortgageGlossaryComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "current-home-loan-rates",
            component: CurrentHomeLoanRatesComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "email-and-text-updates",
            component: EmailAndTextUpdatesComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "finalizing-mortgage-pre-approval",
            component: FinalizingMortgagePreApprovalComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "deciding-mortgage",
            component: DecidingMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "selection-real-estate-agent",
            component: SelectionRealEstateAgentComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "house-hunting",
            component: HouseHuntingComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "making-a-competitive-offer",
            component: MakingACompetitiveOfferComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "underwriting-process",
            component: UnderwritingProcessComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "preparing-to-close",
            component: PreparingToCloseComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "walk-through-and-closing-day",
            component: WalkThroughAndClosingDayComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "making-your-first-mortgage-payment",
            component: MakingYourFirstMortgagePaymentComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "managing-your-mortgage",
            component: ManagingYourMortgageComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "amortization-result",
            component: AmortizationResultComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "animated",
            component: AnimatedComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step1",
            component: Step1Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step2",
            component: Step2Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step3",
            component: Step3Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step4",
            component: Step4Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step5",
            component: Step5Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step6",
            component: Step6Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step7",
            component: Step7Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step8",
            component: Step8Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step9",
            component: Step9Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step10",
            component: Step10Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step11",
            component: Step11Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step12",
            component: Step12Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step13",
            component: Step13Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step14",
            component: Step14Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step15",
            component: Step15Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step16",
            component: Step16Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step17",
            component: Step17Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step18",
            component: Step18Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Step19",
            component: Step19Component,
            canActivate: [AppRouteGuard],
          },
          // Refinance Loan Options Steps
          {
            path: "refinance-animated",
            component: AnimatedOneComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step1",
            component: RefinanceLoanOptionsStep1Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step2",
            component: RefinanceLoanOptionsStep2Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step3",
            component: RefinanceLoanOptionsStep3Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step4",
            component: RefinanceLoanOptionsStep4Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step5",
            component: RefinanceLoanOptionsStep5Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step6",
            component: RefinanceLoanOptionsStep6Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step7",
            component: RefinanceLoanOptionsStep7Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step8",
            component: RefinanceLoanOptionsStep8Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step9",
            component: RefinanceLoanOptionsStep9Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step10",
            component: RefinanceLoanOptionsStep10Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step11",
            component: RefinanceLoanOptionsStep11Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step12",
            component: RefinanceLoanOptionsStep12Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step13",
            component: RefinanceLoanOptionsStep13Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step14",
            component: RefinanceLoanOptionsStep14Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step15",
            component: RefinanceLoanOptionsStep15Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step16",
            component: RefinanceLoanOptionsStep16Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step17",
            component: RefinanceLoanOptionsStep17Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "refinance-loan-option-step18",
            component: RefinanceLoanOptionsStep18Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated",
            component: BuyAHomeComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step1",
            component: AnimatedStep1Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step2",
            component: AnimatedStep2Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step3",
            component: AnimatedStep3Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step4",
            component: AnimatedStep4Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step5",
            component: AnimatedStep5Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step6",
            component: AnimatedStep6Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step7",
            component: AnimatedStep7Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step8",
            component: AnimatedStep8Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step9",
            component: AnimatedStep9Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step10",
            component: AnimatedStep10Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step11",
            component: AnimatedStep11Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step12",
            component: AnimatedStep12Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step13",
            component: AnimatedStep13Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step14",
            component: AnimatedStep14Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step15",
            component: AnimatedStep15Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step16",
            component: AnimatedStep16Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step17",
            component: AnimatedStep17Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step18",
            component: AnimatedStep18Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "Buy a Home - Animated-step19",
            component: AnimatedStep19Component,
            canActivate: [AppRouteGuard],
          },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
