import { Component, Injector, OnInit, Renderer2 } from "@angular/core";
import { Router } from "@angular/router";
import { AppComponentBase } from "@shared/app-component-base";
import { SignalRAspNetCoreHelper } from "@shared/helpers/SignalRAspNetCoreHelper";
import { LayoutStoreService } from "@shared/layout/layout-store.service";

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
      this.router.url === "/app/loan-detail" ||
      this.router.url === "/app/personal-information" ||
      this.router.url === "/app/expense" ||
      this.router.url === "/app/asset" ||
      this.router.url === "/app/employment-income" ||
      this.router.url === "/app/order-credit" ||
      this.router.url === "/app/additional-detail" ||
      this.router.url === "/app/declaration" ||
      this.router.url === "/app/summary" ||
      this.router.url === "/app/econsent"
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
  }

  toggleSidebar(): void {
    this._layoutStore.setSidebarExpanded(!this.sidebarExpanded);
  }
}
