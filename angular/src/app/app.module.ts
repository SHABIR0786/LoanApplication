import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientJsonpModule, HttpClientModule} from '@angular/common/http';
import {ModalModule} from 'ngx-bootstrap/modal';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {CollapseModule} from 'ngx-bootstrap/collapse';
import {TabsModule} from 'ngx-bootstrap/tabs';
import {NgxPaginationModule} from 'ngx-pagination';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ServiceProxyModule} from '@shared/service-proxies/service-proxy.module';
import {SharedModule} from '@shared/shared.module';
import {HomeComponent} from '@app/home/home.component';
import {AboutComponent} from '@app/about/about.component';
// tenants
import {TenantsComponent} from '@app/tenants/tenants.component';
import {CreateTenantDialogComponent} from './tenants/create-tenant/create-tenant-dialog.component';
import {EditTenantDialogComponent} from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import {RolesComponent} from '@app/roles/roles.component';
import {CreateRoleDialogComponent} from './roles/create-role/create-role-dialog.component';
import {EditRoleDialogComponent} from './roles/edit-role/edit-role-dialog.component';
// users
import {UsersComponent} from '@app/users/users.component';
import {CreateUserDialogComponent} from '@app/users/create-user/create-user-dialog.component';
import {EditUserDialogComponent} from '@app/users/edit-user/edit-user-dialog.component';
import {ChangePasswordComponent} from './users/change-password/change-password.component';
import {ResetPasswordDialogComponent} from './users/reset-password/reset-password.component';
// layout
import {HeaderComponent} from './layout/header.component';
import {HeaderLeftNavbarComponent} from './layout/header-left-navbar.component';
import {HeaderLanguageMenuComponent} from './layout/header-language-menu.component';
import {HeaderUserMenuComponent} from './layout/header-user-menu.component';
import {FooterComponent} from './layout/footer.component';
import {SidebarComponent} from './layout/sidebar.component';
import {SidebarLogoComponent} from './layout/sidebar-logo.component';
import {SidebarUserPanelComponent} from './layout/sidebar-user-panel.component';
import {SidebarMenuComponent} from './layout/sidebar-menu.component';
import {LoanApplicationComponent} from './loan-application/loan-application.component';
// Wizard module
import {NgWizardConfig, NgWizardModule, THEME} from 'ng-wizard';
import {LoanDetailsComponent} from './loan-application/loan-details/loan-details.component';
import {ValidationSummaryComponent} from './validation-summary/validation-summary.component';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import {PersonalInformationComponent} from './loan-application/personal-information/personal-information.component';
import {ExpensesComponent} from './loan-application/expenses/expenses.component';
import {BorrowerPersonalDetailComponent} from './loan-application/borrower-personal-detail/borrower-personal-detail.component';
import {DeclarationComponent} from './loan-application/declaration/declaration.component';
import {EmploymentIncomeComponent} from './loan-application/employment-income/employment-income.component';
import {AccordionModule} from 'ngx-bootstrap/accordion';
import {SummaryComponent} from './loan-application/summary/summary.component';
import {DataService} from './services/data.service';
import { EconsentComponent } from './loan-application/econsent/econsent.component';
import { AssetsComponent } from './loan-application/assets/assets.component';

const ngWizardConfig: NgWizardConfig = {
    theme: THEME.default
};

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
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
        AppRoutingModule,
        ServiceProxyModule,
        SharedModule,
        NgxPaginationModule,
        NgWizardModule.forRoot(ngWizardConfig),
        AccordionModule.forRoot(),
    ],
    providers: [
        DataService
    ],
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
export class AppModule {
}
