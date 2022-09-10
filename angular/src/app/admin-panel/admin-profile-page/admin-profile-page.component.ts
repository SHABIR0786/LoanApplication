import { HttpParams } from "@angular/common/http";
import {
  Component,
  EventEmitter,
  Injector,
  OnInit,
  Output,
} from "@angular/core";
import { Router } from "@angular/router";
import { AppComponentBase } from "@shared/app-component-base";
import { ChangePasswordDto } from "@shared/service-proxies/service-proxies";
import { AdminUserServices } from "../../../shared/service/adminUser.service";
import { finalize } from "rxjs/operators";
@Component({
  selector: "app-admin-profile-page",
  templateUrl: "./admin-profile-page.component.html",
  styleUrls: ["./admin-profile-page.component.css"],
})
export class AdminProfilePageComponent extends AppComponentBase {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  constructor(
    injector: Injector,
    private AdminUserServices: AdminUserServices,
    private router: Router
  ) {
    super(injector);
  }
  adminUsername: string;
  adminEmail: string;
  //oldPassword:string;
  password: string;
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
        this.password = Response.result.password;
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
        this.notify.info(this.l("Username Change Successfully"));
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
        this.notify.info(this.l("Email Change Successfully"));
        this.getAdminUserDetails();
      }
    );
  }
  changePassword(password: any) {
    const params = new HttpParams({
      fromObject: {
        id: "1",
        password: password,
      },
    });
    this.AdminUserServices.updateChangePassword(params).subscribe(
      (Response: any) => {
        this.notify.error(this.l(Response.result));
        this.getAdminUserDetails();
        console.log(Response);
      }
    );
  }
}
