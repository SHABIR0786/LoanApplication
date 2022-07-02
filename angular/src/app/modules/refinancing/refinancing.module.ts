import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { RefinancingRoutingModule } from "./refinancing-routing.module";
import { IndexComponent } from "./index.component";
import { ApplyNowRefinanceComponent } from "./apply-now-refinance/apply-now-refinance.component";
import { ApplyNowRefinanceYes2Component } from "./apply-now-refinance-yes2/apply-now-refinance-yes2.component";
import { ApplyNowRefinanceNo3Component } from "./apply-now-refinance-no3/apply-now-refinance-no3.component";
import { ApplyNowPropertyInfo4Component } from "./apply-now-property-info4/apply-now-property-info4.component";
import { ApplyNowPropertyInfo5Component } from "./apply-now-property-info5/apply-now-property-info5.component";
import { ApplyNowPropertyInfo6Component } from "./apply-now-property-info6/apply-now-property-info6.component";
import { ApplyNowPropertyInfo7Component } from "./apply-now-property-info7/apply-now-property-info7.component";
import { ApplyNowPropertyInfo7AComponent } from "./apply-now-property-info7-a/apply-now-property-info7-a.component";
import { ApplyNowRefinanceYes8Component } from "./apply-now-refinance-yes8/apply-now-refinance-yes8.component";
import { ApplyNowNonmilPropinfo12Component } from "./apply-now-nonmil-propinfo12/apply-now-nonmil-propinfo12.component";
import { ApplyNowMilPropinfo9Component } from "./apply-now-mil-propinfo9/apply-now-mil-propinfo9.component";
import { ApplyNowMilPropinfo9AComponent } from "./apply-now-mil-propinfo9-a/apply-now-mil-propinfo9-a.component";
import { ApplyNowRefinancePersonal10Component } from "./apply-now-refinance-personal10/apply-now-refinance-personal10.component";
import { ApplyNowRefinanceMilinfo11Component } from "./apply-now-refinance-milinfo11/apply-now-refinance-milinfo11.component";
import { ApplyNowPropInfoRegister13Component } from "./apply-now-prop-info-register13/apply-now-prop-info-register13.component";
import { ApplyNowPropInfoRefer14Component } from "./apply-now-prop-info-refer14/apply-now-prop-info-refer14.component";
import { ApplyNowPropInfoOwn15Component } from "./apply-now-prop-info-own15/apply-now-prop-info-own15.component";
//import { ApplyNowPersonalInfoCoborrowerComponent } from './apply-now-personal-info-coborrower/apply-now-personal-info-coborrower.component';
import { ApplyNowPersonalInfoCoborrower16Component } from "./apply-now-personal-info-coborrower16/apply-now-personal-info-coborrower16.component";
import { ApplyNowPersonalInfoMarital17Component } from "./apply-now-personal-info-marital17/apply-now-personal-info-marital17.component";
import { ApplyNowPersonalInfoDependents18Component } from "./apply-now-personal-info-dependents18/apply-now-personal-info-dependents18.component";
import { ApplyNowCurrentLiving19Component } from "./apply-now-current-living19/apply-now-current-living19.component";
import { ApplyNowMonthlyExpense20Component } from "./apply-now-monthly-expense20/apply-now-monthly-expense20.component";
import { ApplyNowInfoReview21Component } from "./apply-now-info-review21/apply-now-info-review21.component";
import { ApplyNowPersonalIncome22Component } from "./apply-now-personal-income22/apply-now-personal-income22.component";
import { ApplyNowIncomeEmployment23Component } from "./apply-now-income-employment23/apply-now-income-employment23.component";
import { ApplyNowCurrentEmployer24Component } from "./apply-now-current-employer24/apply-now-current-employer24.component";
import { ApplyNowIncomeCompensation25Component } from "./apply-now-income-compensation25/apply-now-income-compensation25.component";
import { ApplyNowIncomeCompensation26Component } from "./apply-now-income-compensation26/apply-now-income-compensation26.component";
import { ApplyNowIncomeCoborrower27Component } from "./apply-now-income-coborrower27/apply-now-income-coborrower27.component";
import { ApplyNowIncomeCoborrower28Component } from "./apply-now-income-coborrower28/apply-now-income-coborrower28.component";
import { ApplyNowCoborrowerSource29Component } from "./apply-now-coborrower-source29/apply-now-coborrower-source29.component";
import { ApplyNowCoborrowerSource30Component } from "./apply-now-coborrower-source30/apply-now-coborrower-source30.component";
import { ApplyNowCoborrowerOtherSource31Component } from "./apply-now-coborrower-other-source31/apply-now-coborrower-other-source31.component";
import { ApplyNowIncomeReview32Component } from "./apply-now-income-review32/apply-now-income-review32.component";
import { ApplyNowAssets33Component } from "./apply-now-assets33/apply-now-assets33.component";
import { ApplyNowOtherAssets34Component } from "./apply-now-other-assets34/apply-now-other-assets34.component";
import { ApplyNowPurchaseGov35Component } from "./apply-now-purchase-gov35/apply-now-purchase-gov35.component";
import { ApplyNowCreditScore36Component } from "./apply-now-credit-score36/apply-now-credit-score36.component";
import { ApplyNowThanx37Component } from "./apply-now-thanx37/apply-now-thanx37.component";
import { WelcomeComponent } from "./welcome/welcome.component";
import { PropertyInfoComponent } from "./property-info/property-info.component";
import { PersonalInfoComponent } from "./personal-info/personal-info.component";
import { IncomeInfoComponent } from "./income-info/income-info.component";
import { AssetsInfoComponent } from "./assets-info/assets-info.component";
import { GovInfoComponent } from "./gov-info/gov-info.component";
import { CreditScoreComponent } from "./credit-score/credit-score.component";
import { ThanksComponent } from "./thanks/thanks.component";
import { OfflineService } from "./../../services/offline.service";
import { FormsModule } from "@angular/forms";
import { ApiService } from "@app/services/api.service";
import { LoginComponent } from "./../purchase/login/login.component";
@NgModule({
  declarations: [
    IndexComponent,
    ApplyNowRefinanceComponent,
    ApplyNowRefinanceYes2Component,
    ApplyNowRefinanceNo3Component,
    ApplyNowPropertyInfo4Component,
    ApplyNowPropertyInfo5Component,
    ApplyNowPropertyInfo6Component,
    ApplyNowPropertyInfo7Component,
    ApplyNowPropertyInfo7AComponent,
    ApplyNowRefinanceYes8Component,
    ApplyNowNonmilPropinfo12Component,
    ApplyNowMilPropinfo9Component,
    ApplyNowMilPropinfo9AComponent,
    ApplyNowRefinancePersonal10Component,
    ApplyNowRefinanceMilinfo11Component,
    ApplyNowPropInfoRegister13Component,
    ApplyNowPropInfoRefer14Component,
    ApplyNowPropInfoOwn15Component,
    ApplyNowPersonalInfoCoborrower16Component,
    ApplyNowPersonalInfoMarital17Component,
    ApplyNowPersonalInfoDependents18Component,
    ApplyNowCurrentLiving19Component,
    ApplyNowMonthlyExpense20Component,
    ApplyNowInfoReview21Component,
    ApplyNowPersonalIncome22Component,
    ApplyNowIncomeEmployment23Component,
    ApplyNowCurrentEmployer24Component,
    ApplyNowIncomeCompensation25Component,
    ApplyNowIncomeCompensation26Component,
    ApplyNowIncomeCoborrower27Component,
    ApplyNowIncomeCoborrower28Component,
    ApplyNowCoborrowerSource29Component,
    ApplyNowCoborrowerSource30Component,
    ApplyNowCoborrowerOtherSource31Component,
    ApplyNowIncomeReview32Component,
    ApplyNowAssets33Component,
    ApplyNowOtherAssets34Component,
    ApplyNowPurchaseGov35Component,
    ApplyNowCreditScore36Component,
    ApplyNowThanx37Component,
    WelcomeComponent,
    PropertyInfoComponent,
    PersonalInfoComponent,
    IncomeInfoComponent,
    AssetsInfoComponent,
    GovInfoComponent,
    CreditScoreComponent,
    ThanksComponent,
  ],
  providers: [OfflineService, ApiService],
  imports: [CommonModule, RefinancingRoutingModule, FormsModule],
})
export class RefinancingModule {}
