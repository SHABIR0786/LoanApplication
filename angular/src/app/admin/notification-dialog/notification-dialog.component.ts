import { Component, OnInit } from "@angular/core";
import { NotificationService } from "@app/services/notification.service";

@Component({
  selector: "app-notification-dialog",
  templateUrl: "./notification-dialog.component.html",
  styleUrls: ["./notification-dialog.component.css"],
})
export class NotificationDialogComponent implements OnInit {
  notification: any[];
  constructor(private notificationservice: NotificationService) {}

  ngOnInit(): void {
    this.getAllNotification();
  }

  getAllNotification() {
    let obj = {
      params: {},
    };
    this.notificationservice.getAllNotification(obj).subscribe((res: any) => {
      console.log(res);
      this.notification = res.result;
      //this.countNotification();
    });
  }
}
