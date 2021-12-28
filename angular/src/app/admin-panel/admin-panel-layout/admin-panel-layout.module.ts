import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminPanelLayoutComponent } from "./admin-panel-layout.component";
import { AdimPanelPageComponent } from "../adim-panel-page/adim-panel-page.component";
import { Router } from "@angular/router";

@NgModule({
  declarations: [AdminPanelLayoutComponent, AdimPanelPageComponent],
  imports: [CommonModule],
})
export class AdminPanelLayoutModule {}
