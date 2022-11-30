import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Enums } from "shared/constant/enums";
import { AdminUserServices } from "../../../shared/service/adminUser.service";
import { UtilsService } from "abp-ng2-module";
import { AppConsts } from "@shared/AppConsts";
import { NotificationService } from "@app/services/notification.service";
import { SessionServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-admin-side-menu",
  templateUrl: "./admin-side-menu.component.html",
  styleUrls: ["./admin-side-menu.component.css"],
})
export class AdminSideMenuComponent implements OnInit {
  sessionStorage: any;
  cookies: any;

  constructor(
    private sessionService: SessionServiceProxy,
    private AdminUserServices: AdminUserServices,
    private _router: Router,
    private _utilsService: UtilsService
  ) {}
  toggleSidebar: boolean;
  userName: string;
  GlobalName = Enums;
  pageName = Enums.AdminDashboard;
  // isActivePage:boolean=true
  ngOnInit(): void {
    this.getUserDetails();
    console.log(this.pageName);
    // this.getAdminUserDetails();
    this.toggleSidebar = false;
    $(document).ready(function () {
      $(".droprdown_class_a").click(function () {
        $(this).toggleClass("active_class");
        $(this).children().toggleClass("caret_active");
        $(this).next().toggleClass("d-none");
      });
      $(".nav_bars_show_active").click(function () {
        $(".buttons_nav").toggleClass("buttons_nav_active");
      });
    });
  }
  getUserDetails() {
    this.sessionService.getCurrentLoginInformations().subscribe((res) => {
      this.userName = res.user.name;
    });
  }
  toggleSidebarFunc() {
    this.toggleSidebar = !this.toggleSidebar;
  }

  getAdminUserDetails() {
    let obj = {
      params: {
        id: 1,
      },
    };
    this.AdminUserServices.getAdminDetailsbyId(obj).subscribe(
      (Response: any) => {
        this.userName = Response.result.userName;
      }
    );
  }
  navigateToloanApplicationsList() {
    //this.pageName = Enums.AdminProfile;
    this._router.navigate(["app/admin/loan-application-list"]);
  }
  navigateToProfile() {
    //this.pageName = Enums.AdminProfile;
    this._router.navigate(["app/admin/profile"]);
  }

  navigateToDashboard() {
    //this.pageName = Enums.AdminDashboard;
    this._router.navigate(["app/admin/home"]);
  }

  navigateToNotification() {
    this._router.navigate(["app/admin/notification"]);
  }

  navigateToLoanProgress() {
    this._router.navigate(["app/admin/home"]);
  }
  navigateToLoanProcess() {
    this._router.navigate(["app/admin/main-loan-process"]);
  }
  logOut(reload?: boolean) {
    // this._utilsService.deleteCookie("Abp.AuthToken", "enc_auth_token");
    abp.auth.clearToken();
    abp.utils.setCookieValue(
      AppConsts.authorization.encryptedAuthTokenName,
      undefined,
      undefined,
      abp.appPath
    );
    if (reload !== false) {
      location.href = AppConsts.appBaseUrl;
    }
  }
}
