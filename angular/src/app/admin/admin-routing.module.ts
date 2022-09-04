import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminDashboardComponent } from '@app/admin-panel/admin-dashboard/admin-dashboard.component';
import { AdminPanelLayoutComponent } from '@app/admin-panel/admin-panel-layout/admin-panel-layout.component';
import { AdminProfilePageComponent } from '@app/admin-panel/admin-profile-page/admin-profile-page.component';
import { AdminSideMenuComponent } from '@app/admin-panel/admin-side-menu/admin-side-menu.component';
import { LoanApplicationListComponent } from '@app/admin-panel/loan-application-list/loan-application-list.component';
import { LoanProgressComponent } from '@app/admin-panel/loan-progress/loan-progress.component';
import { NotificationComponent } from '@app/admin-panel/notification/notification.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';


const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: "",
      component: AdminSideMenuComponent,
      children: [
        {
          path: "home",
          component: AdminDashboardComponent,
          canActivate: [AppRouteGuard],
        },
        {
          path: "profile",
          component: AdminProfilePageComponent,
          canActivate: [AppRouteGuard],
        },
         {
          path: "loan-process",
          component: LoanProgressComponent,
          canActivate: [AppRouteGuard],
        },
        {
          path: "notification",
          component: NotificationComponent,
          canActivate: [AppRouteGuard],
        },
        {
          path: "loan-application-list",
          component: LoanApplicationListComponent,
          canActivate: [AppRouteGuard],
        },
      ],
    },
  ]),],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
