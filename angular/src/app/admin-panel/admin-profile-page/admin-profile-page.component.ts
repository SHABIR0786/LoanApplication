import { HttpParams } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { AdminUserServices } from "../../../shared/service/adminUser.service";

@Component({
  selector: "app-admin-profile-page",
  templateUrl: "./admin-profile-page.component.html",
  styleUrls: ["./admin-profile-page.component.css"],
})
export class AdminProfilePageComponent implements OnInit {
  constructor(private AdminUserServices: AdminUserServices) {}
  adminUsername: string;
  adminEmail: string;

  ngOnInit(): void {
    this.getAdminUserDetails();
  }

  getAdminUserDetails() {
    let obj = {
      params: {
        id: 1,
      },
    };
    this.AdminUserServices.getAdminDetailsbyId(obj).subscribe(
      (Response: any) => {
        this.adminUsername = Response.result.userName;
        this.adminEmail = Response.result.email;
      }
    );
  }

  updateUsername(adminUserName: string) {
    const params = new HttpParams({
      fromObject: {
        id: "1",
        username: adminUserName,
      },
    });
    this.AdminUserServices.updateAdminUserName(params).subscribe(
      (Response: any) => {
        this.getAdminUserDetails();
      }
    );
  }

  updateEmailAddress(email: string) {
    const params = new HttpParams({
      fromObject: {
        id: "1",
        email: email,
      },
    });
    this.AdminUserServices.updateAdminEmail(params).subscribe(
      (Response: any) => {
        this.getAdminUserDetails();
      }
    );
  }
}
