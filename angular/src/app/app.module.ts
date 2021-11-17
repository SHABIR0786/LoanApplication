import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientJsonpModule, HttpClientModule } from "@angular/common/http";
import { ModalModule } from "ngx-bootstrap/modal";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { TabsModule } from "ngx-bootstrap/tabs";
import { CarouselModule } from "ngx-bootstrap/carousel";
import { NgxPaginationModule } from "ngx-pagination";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ServiceProxyModule } from "@shared/service-proxies/service-proxy.module";
import { SharedModule } from "@shared/shared.module";
import { NgxMaskModule, IConfig } from "ngx-mask";
import { HomeComponent } from "@app/home/home.component";
import { HomeMainCarousel } from "@app/home/home-main-carousel/home-main-carousel";
import { HomeTestmionals } from "@app/home/home-testmionals/home-testmionals";
import { AboutComponent } from "@app/about/about.component";
// tenants
import { TenantsComponent } from "@app/tenants/tenants.component";
import { CreateTenantDialogComponent } from "./tenants/create-tenant/create-tenant-dialog.component";
import { EditTenantDialogComponent } from "./tenants/edit-tenant/edit-tenant-dialog.component";
// roles
import { RolesComponent } from "@app/roles/roles.component";
import { CreateRoleDialogComponent } from "./roles/create-role/create-role-dialog.component";
import { EditRoleDialogComponent } from "./roles/edit-role/edit-role-dialog.component";
// users
import { UsersComponent } from "@app/users/users.component";
import { CreateUserDialogComponent } from "@app/users/create-user/create-user-dialog.component";
import { EditUserDialogComponent } from "@app/users/edit-user/edit-user-dialog.component";
import { ChangePasswordComponent } from "./users/change-password/change-password.component";
import { ResetPasswordDialogComponent } from "./users/reset-password/reset-password.component";
// layout
import { HeaderComponent } from "./layout/header.component";
import { HeaderLeftNavbarComponent } from "./layout/header-left-navbar.component";
import { HeaderLanguageMenuComponent } from "./layout/header-language-menu.component";
import { HeaderUserMenuComponent } from "./layout/header-user-menu.component";
import { FooterComponent } from "./layout/footer.component";
import { SidebarComponent } from "./layout/sidebar.component";
import { SidebarLogoComponent } from "./layout/sidebar-logo.component";
import { SidebarUserPanelComponent } from "./layout/sidebar-user-panel.component";
import { SidebarMenuComponent } from "./layout/sidebar-menu.component";
import { LoanApplicationComponent } from "./loan-application/loan-application.component";
// Wizard module
import { NgWizardConfig, NgWizardModule, THEME } from "ng-wizard";
import { LoanDetailsComponent } from "./loan-application/loan-details/loan-details.component";
import { ValidationSummaryComponent } from "./validation-summary/validation-summary.component";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PersonalInformationComponent } from "./loan-application/personal-information/personal-information.component";
import { ExpensesComponent } from "./loan-application/expenses/expenses.component";
import { BorrowerPersonalDetailComponent } from "./loan-application/borrower-personal-detail/borrower-personal-detail.component";
import { DeclarationComponent } from "./loan-application/declaration/declaration.component";
import { EmploymentIncomeComponent } from "./loan-application/employment-income/employment-income.component";
import { AccordionModule } from "ngx-bootstrap/accordion";
import { SummaryComponent } from "./loan-application/summary/summary.component";
import { SummaryExpandDataComponent } from "./loan-application/summary/data-component/summary-expand-data.component";
import { DataService } from "./services/data.service";
import { EconsentComponent } from "./loan-application/econsent/econsent.component";
import { AssetsComponent } from "./loan-application/assets/assets.component";
import { OrderCreditComponent } from "./loan-application/order-credit/order-credit.component";
import { AdditionalDetailsComponent } from "./loan-application/additional-details/additional-details.component";
import { LoanListComponent } from "./loan-application/loan-list/loan-list.component";
import { AdminPanelComponent } from "./admin-panel/admin-panel.component";
import { LoanSideBar } from "./loan-application/side-bar/side-bar";
import { GetLoanAppResolve } from "./resolver/loan-app-get-resolve";
import { MortgageCalculatorComponent } from "./calculators/mortgage-calculator/mortgage-calculator.component";
import { HomeAffordabilityCalculatorComponent } from "./calculators/home-affordability-calculator/home-affordability-calculator.component";
import { RefinanceCalculatorComponent } from "./calculators/refinance-calculator/refinance-calculator.component";
import { AffordabilityComponent } from "./calculators/affordability/affordability.component";
import { ViewAllCalculatorsComponent } from "./calculators/view-all-calculators/view-all-calculators.component";
import { BuyingHomeGuideComponent } from "./buying-home-guide/buying-home-guide.component";
import { FirstTimeHomeBuyerComponent } from "./first-time-home-buyer/first-time-home-buyer.component";
import { BuyingSecondHomeComponent } from "./buying-second-home/buying-second-home.component";
import { PreApprovalComponent } from "./pre-approval/pre-approval.component";
import { BuyingVacationHomeComponent } from "./buying-vacation-home/buying-vacation-home.component";
import { RealStateInvestorComponent } from "./real-state-investor/real-state-investor.component";
import { MovingAndBuyingHomeComponent } from "./moving-and-buying-home/moving-and-buying-home.component";
import { HomeBuyingFreeConsultationComponent } from "./home-buying-free-consultation/home-buying-free-consultation.component";
import { LowerYourPaymentComponent } from "./refinance/lower-your-payment/lower-your-payment.component";
import { GetCashFromYourHomeComponent } from "./refinance/get-cash-from-your-home/get-cash-from-your-home.component";
import { ConsolidateYourDebitComponent } from "./refinance/consolidate-your-debit/consolidate-your-debit.component";
import { PayOffYourMortgageFasterComponent } from "./refinance/pay-off-your-mortgage-faster/pay-off-your-mortgage-faster.component";
import { RefinanceWithHARPComponent } from "./refinance/refinance-with-harp/refinance-with-harp.component";
import { KeepYourPaymentFromRaisingComponent } from "./refinance/keep-your-payment-from-raising/keep-your-payment-from-raising.component";
import { RefinanceInvestmentPropertyComponent } from "./refinance/refinance-investment-property/refinance-investment-property.component";
import { RefinanceFreeConsultationComponent } from "./refinance/refinance-free-consultation/refinance-free-consultation.component";
import { LoanOptionsComponent } from "./loan-options/loan-options.component";
import { ThirtyYearFixedMortgageComponent } from "./loan-options/thirty-year-fixed-mortgage/thirty-year-fixed-mortgage.component";
import { FifteenYearFixedMortgageComponent } from "./loan-options/fifteen-year-fixed-mortgage/fifteen-year-fixed-mortgage.component";
import { AdjustableRateMortgageComponent } from "./loan-options/adjustable-rate-mortgage/adjustable-rate-mortgage.component";
import { HarpRefinanceComponent } from "./loan-options/harp-refinance/harp-refinance.component";
import { FhaLoansComponent } from "./loan-options/fha-loans/fha-loans.component";
import { JumboLoanComponent } from "./loan-options/jumbo-loan/jumbo-loan.component";
import { BlogComponent } from "./blog/blog.component";
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
import { AmortizationComponent } from "./calculators/amortization/amortization.component";
import { VaLoanComponent } from "./loan-options/va-loan/va-loan.component";
import { AmortizationResultComponent } from "./calculators/amortization/amortization-result/amortization-result.component";
import { RentVsBuyCalculatorComponent } from "./calculators/rent-vs-buy-calculator/rent-vs-buy-calculator.component";
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
import { AnimatedFormHeaderComponent } from './layout/animated-form-header.component';
import { AnimatedFormFooterComponent } from './layout/animated-form-footer.component';

const ngWizardConfig: NgWizardConfig = {
  theme: THEME.default,
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeTestmionals,
    HomeMainCarousel,
    AboutComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent,
    LoanApplicationComponent,
    LoanDetailsComponent,
    ValidationSummaryComponent,
    PersonalInformationComponent,
    ExpensesComponent,
    BorrowerPersonalDetailComponent,
    DeclarationComponent,
    EmploymentIncomeComponent,
    SummaryComponent,
    EconsentComponent,
    AssetsComponent,
    OrderCreditComponent,
    AdditionalDetailsComponent,
    SummaryExpandDataComponent,
    LoanListComponent,
    AdminPanelComponent,
    LoanSideBar,
    MortgageCalculatorComponent,
    HomeAffordabilityCalculatorComponent,
    RefinanceCalculatorComponent,
    AffordabilityComponent,
    ViewAllCalculatorsComponent,
    BuyingHomeGuideComponent,
    FirstTimeHomeBuyerComponent,
    BuyingSecondHomeComponent,
    PreApprovalComponent,
    BuyingVacationHomeComponent,
    RealStateInvestorComponent,
    MovingAndBuyingHomeComponent,
    HomeBuyingFreeConsultationComponent,
    LowerYourPaymentComponent,
    GetCashFromYourHomeComponent,
    ConsolidateYourDebitComponent,
    PayOffYourMortgageFasterComponent,
    RefinanceWithHARPComponent,
    KeepYourPaymentFromRaisingComponent,
    RefinanceInvestmentPropertyComponent,
    RefinanceFreeConsultationComponent,
    LoanOptionsComponent,
    ThirtyYearFixedMortgageComponent,
    FifteenYearFixedMortgageComponent,
    AdjustableRateMortgageComponent,
    HarpRefinanceComponent,
    FhaLoansComponent,
    JumboLoanComponent,
    BlogComponent,

    Step2Component,

    AnimatedComponent,

    Step1Component,

    Step3Component,

    Step4Component,

    Step5Component,

    Step6Component,

    Step7Component,

    Step8Component,

    Step9Component,

    Step10Component,

    Step11Component,

    Step12Component,

    Step13Component,

    Step14Component,

    Step15Component,

    Step16Component,

    Step17Component,

    Step18Component,

    Step19Component,
    AboutUsComponent,
    RequestAMortgageComponent,
    ContactUsComponent,
    LicenseInfoComponent,
    MortgageGlossaryComponent,
    CurrentHomeLoanRatesComponent,
    EmailAndTextUpdatesComponent,
    FinalizingMortgagePreApprovalComponent,
    DecidingMortgageComponent,
    SelectionRealEstateAgentComponent,
    HouseHuntingComponent,
    MakingACompetitiveOfferComponent,
    UnderwritingProcessComponent,
    PreparingToCloseComponent,
    WalkThroughAndClosingDayComponent,
    MakingYourFirstMortgagePaymentComponent,
    ManagingYourMortgageComponent,
    AmortizationComponent,
    VaLoanComponent,
    AmortizationResultComponent,
    RentVsBuyCalculatorComponent,
    AnimatedOneComponent,
    RefinanceLoanOptionsStep1Component,
    RefinanceLoanOptionsStep2Component,
    RefinanceLoanOptionsStep3Component,
    RefinanceLoanOptionsStep4Component,
    RefinanceLoanOptionsStep5Component,
    RefinanceLoanOptionsStep6Component,
    RefinanceLoanOptionsStep7Component,
    RefinanceLoanOptionsStep8Component,
    RefinanceLoanOptionsStep9Component,
    RefinanceLoanOptionsStep10Component,
    RefinanceLoanOptionsStep12Component,
    RefinanceLoanOptionsStep13Component,
    RefinanceLoanOptionsStep14Component,
    RefinanceLoanOptionsStep15Component,
    RefinanceLoanOptionsStep16Component,
    RefinanceLoanOptionsStep17Component,
    RefinanceLoanOptionsStep18Component,
    AnimatedFormHeaderComponent,
    AnimatedFormFooterComponent
   
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    TooltipModule.forRoot(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    CarouselModule.forRoot(),
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    NgWizardModule.forRoot(ngWizardConfig),
    AccordionModule.forRoot(),
    NgxMaskModule.forRoot(),
  ],
  providers: [DataService, GetLoanAppResolve],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
  ],
})
export class AppModule {}
