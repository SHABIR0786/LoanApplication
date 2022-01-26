import { Component, Injector, OnInit, Renderer2 } from "@angular/core";
import { Router, NavigationStart, NavigationEnd } from "@angular/router";
import { AppComponentBase } from "@shared/app-component-base";
import { SignalRAspNetCoreHelper } from "@shared/helpers/SignalRAspNetCoreHelper";
import { LayoutStoreService } from "@shared/layout/layout-store.service";
import { Location, PopStateEvent } from "@angular/common";

import { filter } from "rxjs/operators";

@Component({
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent extends AppComponentBase implements OnInit {
  sidebarExpanded: boolean;

  constructor(
    injector: Injector,
    private renderer: Renderer2,
    private _layoutStore: LayoutStoreService,
    public router: Router
  ) {
    super(injector);
  }

  get IsLoanForm(): boolean {
    return (
      this.router.url.includes("/app/loan-detail") ||
      this.router.url.includes("/app/personal-information") ||
      this.router.url.includes("/app/expense") ||
      this.router.url.includes("/app/asset") ||
      this.router.url.includes("/app/employment-income") ||
      this.router.url.includes("/app/order-credit") ||
      this.router.url.includes("/app/additional-detail") ||
      this.router.url.includes("/app/declaration") ||
      this.router.url.includes("/app/summary") ||
      this.router.url.includes("/app/econsent")
    );
  }

  get IsRefinanceLoanOptions(): boolean {
    return (
      this.router.url.includes("/app/refinance-animated") ||
      this.router.url.includes("/app/refinance-loan-option-step1") ||
      this.router.url.includes("/app/refinance-loan-option-step2") ||
      this.router.url.includes("/app/refinance-loan-option-step3") ||
      this.router.url.includes("/app/refinance-loan-option-step4") ||
      this.router.url.includes("/app/refinance-loan-option-step5") ||
      this.router.url.includes("/app/refinance-loan-option-step6") ||
      this.router.url.includes("/app/refinance-loan-option-step7") ||
      this.router.url.includes("/app/refinance-loan-option-step8") ||
      this.router.url.includes("/app/refinance-loan-option-step9") ||
      this.router.url.includes("/app/refinance-loan-option-step10") ||
      this.router.url.includes("/app/refinance-loan-option-step11") ||
      this.router.url.includes("/app/refinance-loan-option-step12") ||
      this.router.url.includes("/app/refinance-loan-option-step13") ||
      this.router.url.includes("/app/refinance-loan-option-step14") ||
      this.router.url.includes("/app/refinance-loan-option-step15") ||
      this.router.url.includes("/app/refinance-loan-option-step16") ||
      this.router.url.includes("/app/refinance-loan-option-step17") ||
      this.router.url.includes("/app/refinance-loan-option-step18") ||
      this.router.url.includes("/app/animated") ||
      this.router.url.includes("/app/refinance-step1") ||
      this.router.url.includes("/app/refinance-step2") ||
      this.router.url.includes("/app/refinance-step3") ||
      this.router.url.includes("/app/refinance-step4") ||
      this.router.url.includes("/app/refinance-step5") ||
      this.router.url.includes("/app/refinance-step6") ||
      this.router.url.includes("/app/refinance-step7") ||
      this.router.url.includes("/app/refinance-step8") ||
      this.router.url.includes("/app/refinance-step9") ||
      this.router.url.includes("/app/refinance-step10") ||
      this.router.url.includes("/app/refinance-step11") ||
      this.router.url.includes("/app/refinance-step12") ||
      this.router.url.includes("/app/refinance-step13") ||
      this.router.url.includes("/app/refinance-step14") ||
      this.router.url.includes("/app/refinance-step15") ||
      this.router.url.includes("/app/refinance-step16") ||
      this.router.url.includes("/app/refinance-step17") ||
      this.router.url.includes("/app/refinance-step18") ||
      this.router.url.includes("/app/refinance-step19") ||
      this.router.url.includes("/app/buy-a-home-animated-step1") ||
      this.router.url.includes("/app/buy-a-home-animated-step2") ||
      this.router.url.includes("/app/buy-a-home-animated-step3") ||
      this.router.url.includes("/app/buy-a-home-animated-step4") ||
      this.router.url.includes("/app/buy-a-home-animated-step5") ||
      this.router.url.includes("/app/buy-a-home-animated-step6") ||
      this.router.url.includes("/app/buy-a-home-animated-step7") ||
      this.router.url.includes("/app/buy-a-home-animated-step8") ||
      this.router.url.includes("/app/buy-a-home-animated-step9") ||
      this.router.url.includes("/app/buy-a-home-animated-step10") ||
      this.router.url.includes("/app/buy-a-home-animated-step11") ||
      this.router.url.includes("/app/buy-a-home-animated-step12") ||
      this.router.url.includes("/app/buy-a-home-animated-step13") ||
      this.router.url.includes("/app/buy-a-home-animated-step14") ||
      this.router.url.includes("/app/buy-a-home-animated-step15") ||
      this.router.url.includes("/app/buy-a-home-animated-step16") ||
      this.router.url.includes("/app/buy-a-home-animated-step17") ||
      this.router.url.includes("/app/buy-a-home-animated-step18") ||
      this.router.url.includes("/app/buy-a-home-animated-step19") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step1") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step2") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step3") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step4") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step5") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step6") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step7") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step8") ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated-step9") ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step10"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step11"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step12"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step13"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step14"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step15"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step16"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step17"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step18"
      ) ||
      this.router.url.includes(
        "/app/buy-a-home-loan-options-animated-step19"
      ) ||
      this.router.url.includes("/app/buy-a-home-loan-options-animated")
    );
  }

  ngOnInit(): void {
    this.renderer.addClass(document.body, "sidebar-mini");

    SignalRAspNetCoreHelper.initSignalR();

    abp.event.on("abp.notifications.received", (userNotification) => {
      abp.notifications.showUiNotifyForUserNotification(userNotification);

      // Desktop notification
      Push.create("AbpZeroTemplate", {
        body: userNotification.notification.data.message,
        icon: abp.appPath + "assets/app-logo-small.png",
        timeout: 6000,
        onClick: function () {
          window.focus();
          this.close();
        },
      });
    });

    this._layoutStore.sidebarExpanded.subscribe((value) => {
      this.sidebarExpanded = value;
    });

    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        window.scrollTo({
          top: 0,
          behavior: "smooth",
        });
      });
  }

  toggleSidebar(): void {
    this._layoutStore.setSidebarExpanded(!this.sidebarExpanded);
  }
}
