import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminPanelLayoutComponent } from '@app/admin-panel/admin-panel-layout/admin-panel-layout.component';
import { AdminProfilePageComponent } from '@app/admin-panel/admin-profile-page/admin-profile-page.component';
import { AdminSideMenuComponent } from '@app/admin-panel/admin-side-menu/admin-side-menu.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AdminPanelComponent } from '@app/admin-panel/admin-panel.component';


@NgModule({
  declarations: [
    AdminPanelLayoutComponent,
    AdminProfilePageComponent,
    AdminSideMenuComponent,
    AdminPanelComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ModalModule.forChild(),
  ]
})
export class AdminModule { }
