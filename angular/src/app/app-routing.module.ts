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
import { AmortisationComponent } from "./calculators/amortisation/amortisation.component";
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
            path: "amortisation",
            component: AmortisationComponent,
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
            path: "blog",
            component: BlogComponent,
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
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
