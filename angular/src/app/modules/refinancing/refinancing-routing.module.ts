import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ApplyNowPropertyInfo4Component } from "./apply-now-property-info4/apply-now-property-info4.component";
import { ApplyNowPropertyInfo5Component } from "./apply-now-property-info5/apply-now-property-info5.component";
import { ApplyNowPropertyInfo6Component } from "./apply-now-property-info6/apply-now-property-info6.component";
import { ApplyNowPropertyInfo7Component } from "./apply-now-property-info7/apply-now-property-info7.component";
import { ApplyNowRefinanceYes2Component } from "./apply-now-refinance-yes2/apply-now-refinance-yes2.component";
import { AssetsInfoComponent } from "./assets-info/assets-info.component";
import { CreditScoreComponent } from "./credit-score/credit-score.component";
import { GovInfoComponent } from "./gov-info/gov-info.component";
import { IncomeInfoComponent } from "./income-info/income-info.component";
import { IndexComponent } from "./index.component";
import { MilitaryInfoComponent } from "./military-info/military-info.component";
import { PersonalInfoComponent } from "./personal-info/personal-info.component";
import { PropertyInfoComponent } from "./property-info/property-info.component";
import { ThanksComponent } from "./thanks/thanks.component";
import { WelcomeComponent } from "./welcome/welcome.component";

const routes: Routes = [
  {
    path: "",
    component: IndexComponent,
    children: [
      {
        path: "",
        redirectTo: "welcome/1",
        pathMatch: "full",
      },
      {
        path: "welcome/:number",
        component: WelcomeComponent,
      },
      {
        path: "property-info/:number",
        component: PropertyInfoComponent,
      },
      {
        path: "military-info/:number",
        component: MilitaryInfoComponent,
      },
      {
        path: "personal-info/:number",
        component: PersonalInfoComponent,
      },
      {
        path: "income/:number",
        component: IncomeInfoComponent,
      },
      {
        path: "assets-info/:number",
        component: AssetsInfoComponent,
      },
      {
        path: "gov/:number",
        component: GovInfoComponent,
      },
      {
        path: "credit-score/:number",
        component: CreditScoreComponent,
      },
      {
        path: "thanks",
        component: ThanksComponent,
      },
      {
        path: "apply-now-property-info",
        component: ApplyNowPropertyInfo4Component,
      },
      {
        path: "apply-now-hoem-address",
        component: ApplyNowPropertyInfo5Component,
      },
      {
        path: "apply-now-property-info6",
        component: ApplyNowPropertyInfo6Component,
      },
      {
        path: "apply-now-property-info7",
        component: ApplyNowPropertyInfo7Component,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RefinancingRoutingModule {}
