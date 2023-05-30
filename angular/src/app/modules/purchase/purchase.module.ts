import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { PurchaseRoutingModule } from "./purchase-routing.module";
import { IndexComponent } from "./index.component";
import { ApplyNowComponent } from "./apply-now/apply-now.component";
import { SignedPurchaseComponent } from "./signed-purchase/signed-purchase.component";
import { PurchasingYesComponent } from "./purchasing-yes/purchasing-yes.component";
import { PurchaseYesComponent } from "./purchase-yes/purchase-yes.component";
import { PurchaseNoComponent } from "./purchase-no/purchase-no.component";
import { PurchaseYesMilComponent } from "./purchase-yes-mil/purchase-yes-mil.component";
import { PurchasePropYesComponent } from "./purchase-prop-yes/purchase-prop-yes.component";
import { PurchaseMilitaryInfoComponent } from "./purchase-military-info/purchase-military-info.component";
import { PurchaseMilitaryPersonalComponent } from "./purchase-military-personal/purchase-military-personal.component";
import { PurchaseNonMilComponent } from "./purchase-non-mil/purchase-non-mil.component";
import { PurchasePropInfo17Component } from "./purchase-prop-info17/purchase-prop-info17.component";
import { PurchasePersonalInfo18Component } from "./purchase-personal-info18/purchase-personal-info18.component";
import { PurchaseNon19Component } from "./purchase-non19/purchase-non19.component";
import { PurchaseOnmyOwn20Component } from "./purchase-onmy-own20/purchase-onmy-own20.component";
import { PurchaseSeparate21Component } from "./purchase-separate21/purchase-separate21.component";
import { PurchaseDependants22Component } from "./purchase-dependants22/purchase-dependants22.component";
import { PurchaseOwnRentOth23Component } from "./purchase-own-rent-oth23/purchase-own-rent-oth23.component";
import { PurchaseMonthlyExpenses24Component } from "./purchase-monthly-expenses24/purchase-monthly-expenses24.component";
import { PurchasePersonalInfoEdit25Component } from "./purchase-personal-info-edit25/purchase-personal-info-edit25.component";
import { PurchaseIncome26Component } from "./purchase-income26/purchase-income26.component";
import { PurchaseIncomeSource27Component } from "./purchase-income-source27/purchase-income-source27.component";
import { PurchaseAssets28Component } from "./purchase-assets28/purchase-assets28.component";
import { PurchaseGovernment29Component } from "./purchase-government29/purchase-government29.component";
import { PurchaseCreditScore30Component } from "./purchase-credit-score30/purchase-credit-score30.component";
import { WelcomeComponent } from "./welcome/welcome.component";
import { PropertyInfoComponent } from "./property-info/property-info.component";
import { IncomeInfoComponent } from "./income-info/income-info.component";
import { AssetsInfoComponent } from "./assets-info/assets-info.component";
import { GovernmentComponent } from "./government/government.component";
//import { ApplyNowRefinanceComponent } from './apply-now-refinance/apply-now-refinance.component';
import { OfflineService } from "./../../services/offline.service";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ApiService } from "@app/services/api.service";
import { PersonalInfoComponent } from "./personal-info/personal-info.component";
import { SharedModule } from "@shared/shared.module";
import { MatchPasswordDirective } from "@shared/directives/match-password.directive";
import { CreditScoreComponent } from "./credit-score/credit-score.component";
import { MilitaryInfoComponent } from "./military-info/military-info.component";
@NgModule({
  declarations: [
    IndexComponent,
    ApplyNowComponent,
    SignedPurchaseComponent,
    PurchasingYesComponent,
    PurchaseYesComponent,
    PurchaseNoComponent,
    PurchaseYesMilComponent,
    PurchasePropYesComponent,
    PurchaseMilitaryInfoComponent,
    PurchaseMilitaryPersonalComponent,
    PurchaseNonMilComponent,
    PurchasePropInfo17Component,
    PurchasePersonalInfo18Component,
    PurchaseNon19Component,
    PurchaseOnmyOwn20Component,
    PurchaseSeparate21Component,
    PurchaseDependants22Component,
    PurchaseOwnRentOth23Component,
    PurchaseMonthlyExpenses24Component,
    PurchasePersonalInfoEdit25Component,
    PurchaseIncome26Component,
    PurchaseIncomeSource27Component,
    PurchaseAssets28Component,
    PurchaseGovernment29Component,
    PurchaseCreditScore30Component,
    WelcomeComponent,
    PropertyInfoComponent,
    IncomeInfoComponent,
    AssetsInfoComponent,
    GovernmentComponent,
    PersonalInfoComponent,
    // MatchPasswordDirective,
    CreditScoreComponent,
    MilitaryInfoComponent,
  ],
  providers: [OfflineService, ApiService],
  imports: [
    CommonModule,
    PurchaseRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
  ],
})
export class PurchaseModule {}
