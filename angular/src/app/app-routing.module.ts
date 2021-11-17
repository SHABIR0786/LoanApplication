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
import { LoneOptionAnimatedComponent } from "./Buy_a_Home_Loan _Options/lone-option-animated/lone-option-animated.component";
import { LoneOptionStep1Component } from "./Buy_a_Home_Loan _Options/lone-option-step1/lone-option-step1.component";
import { LoneOptionStep2Component } from "./Buy_a_Home_Loan _Options/lone-option-step2/lone-option-step2.component";
import { LoneOptionStep3Component } from "./Buy_a_Home_Loan _Options/lone-option-step3/lone-option-step3.component";
import { LoneOptionStep4Component } from "./Buy_a_Home_Loan _Options/lone-option-step4/lone-option-step4.component";
import { LoneOptionStep5Component } from "./Buy_a_Home_Loan _Options/lone-option-step5/lone-option-step5.component";
import { LoneOptionStep6Component } from "./Buy_a_Home_Loan _Options/lone-option-step6/lone-option-step6.component";
import { LoneOptionStep7Component } from "./Buy_a_Home_Loan _Options/lone-option-step7/lone-option-step7.component";
import { LoneOptionStep8Component } from "./Buy_a_Home_Loan _Options/lone-option-step8/lone-option-step8.component";
import { LoneOptionStep9Component } from "./Buy_a_Home_Loan _Options/lone-option-step9/lone-option-step9.component";
import { LoneOptionStep10Component } from "./Buy_a_Home_Loan _Options/lone-option-step10/lone-option-step10.component";
import { LoneOptionStep11Component } from "./Buy_a_Home_Loan _Options/lone-option-step11/lone-option-step11.component";
import { LoneOptionStep12Component } from "./Buy_a_Home_Loan _Options/lone-option-step12/lone-option-step12.component";
import { LoneOptionStep13Component } from "./Buy_a_Home_Loan _Options/lone-option-step13/lone-option-step13.component";
import { LoneOptionStep14Component } from "./Buy_a_Home_Loan _Options/lone-option-step14/lone-option-step14.component";

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
            path: "buy-a-home-loan-options-animated",
            component: LoneOptionAnimatedComponent,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step1",
            component: LoneOptionStep1Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step2",
            component: LoneOptionStep2Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step3",
            component: LoneOptionStep3Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step4",
            component: LoneOptionStep4Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step5",
            component: LoneOptionStep5Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step6",
            component: LoneOptionStep6Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step7",
            component: LoneOptionStep7Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step8",
            component: LoneOptionStep8Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step9",
            component: LoneOptionStep9Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step10",
            component: LoneOptionStep10Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step11",
            component: LoneOptionStep11Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step12",
            component: LoneOptionStep12Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step13",
            component: LoneOptionStep13Component,
            canActivate: [AppRouteGuard],
          },
          {
            path: "buy-a-home-loan-options-animated-step14",
            component: LoneOptionStep14Component,
            canActivate: [AppRouteGuard],
          },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
