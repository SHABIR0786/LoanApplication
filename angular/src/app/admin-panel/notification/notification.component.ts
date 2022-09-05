import { Component, OnInit } from "@angular/core";
import { NotificationService } from "../../services/notification.service";
@Component({
  selector: "app-notification",
  templateUrl: "./notification.component.html",
  styleUrls: ["./notification.component.css"],
})
export class NotificationComponent implements OnInit {
  notification: any;
  notificationCount: number;
  constructor(private notificationservice: NotificationService) {}

  ngOnInit(): void {
    this.getAllNotification();
  }
  countNotification() {
    this.notificationCount = this.notification.filter(
      (a) => a.isSeen == 0
    ).length;
    console.log(this.notificationCount);
  }
  getAllNotification() {
    let obj = {
      params: {},
    };
    this.notificationservice.getAllNotification(obj).subscribe((res: any) => {
      console.log(res);
      this.notification = res.result;
      this.countNotification();
    });
  }
}
