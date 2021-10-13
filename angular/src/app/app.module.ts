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
import { AmortisationComponent } from "./calculators/amortisation/amortisation.component";
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
    AmortisationComponent,
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
