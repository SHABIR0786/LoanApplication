import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminPanelLayoutComponent } from '@app/admin-panel/admin-panel-layout/admin-panel-layout.component';
import { AdminProfilePageComponent } from '@app/admin-panel/admin-profile-page/admin-profile-page.component';
import { AdminSideMenuComponent } from '@app/admin-panel/admin-side-menu/admin-side-menu.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AdminPanelComponent } from '@app/admin-panel/admin-panel.component';
import { NotificationDialogComponent } from './notification-dialog/notification-dialog.component';
import { BsDropdownConfig, BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@NgModule({
  declarations: [
    AdminPanelLayoutComponent,
    AdminProfilePageComponent,
    AdminSideMenuComponent,
    AdminPanelComponent,
    NotificationDialogComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
   
  ],
  providers: []
})
export class AdminModule { }
