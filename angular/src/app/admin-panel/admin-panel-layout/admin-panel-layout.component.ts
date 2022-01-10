import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-admin-panel-layout",
  templateUrl: "./admin-panel-layout.component.html",
  styleUrls: ["./admin-panel-layout.component.css"],
})
export class AdminPanelLayoutComponent implements OnInit {
  constructor() {}
  toggleSidebar: boolean;
  ngOnInit(): void {
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
}
