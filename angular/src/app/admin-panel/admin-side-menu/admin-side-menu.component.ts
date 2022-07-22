import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Enums } from "shared/constant/enums";
import { AdminUserServices } from "../../../shared/service/adminUser.service";
import { UtilsService } from "abp-ng2-module";

@Component({
  selector: "app-admin-side-menu",
  templateUrl: "./admin-side-menu.component.html",
  styleUrls: ["./admin-side-menu.component.css"],
})
export class AdminSideMenuComponent implements OnInit {
  sessionStorage: any;
  cookies: any;
  constructor(
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
    console.log(this.pageName);
    this.getAdminUserDetails();
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

  navigateToProfile() {
    this.pageName = Enums.AdminProfile;
  }

  navigateToDashboard() {
    this.pageName = Enums.AdminDashboard;
  }

  logOut() {
    debugger;
    this._utilsService.deleteCookie("Abp.AuthToken", "enc_auth_token");
  }
}
