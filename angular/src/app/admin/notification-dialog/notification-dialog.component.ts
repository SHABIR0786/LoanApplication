import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { NotificationService } from "@app/services/notification.service";
import { SignalRAspNetCoreHelper } from "@shared/helpers/SignalRAspNetCoreHelper";

@Component({
  selector: "app-notification-dialog",
  templateUrl: "./notification-dialog.component.html",
  styleUrls: ["./notification-dialog.component.css"],
})
export class NotificationDialogComponent implements OnInit {
  notification: any[];
  notificationCount: number;
  constructor(private notificationservice: NotificationService,private changeDetect
    :ChangeDetectorRef) {}

  ngOnInit(): void {
    this.getAllNotification();
    SignalRAspNetCoreHelper.initSignalR();
    abp.event.on("abp.notifications.received", (userNotification) => {
      debugger
      var noti = JSON.parse(userNotification.notification.data.properties.Message);
      var model = {
        "id":noti.Id,
        "userId":noti.UserId,
        "isSeen":noti.IsSeen,
        "content":noti.Content,
        "subject":noti.Subject,
        "date":noti.Date,
        "notificationTypeId":noti.NotificationTypeId,
     
      };
     this.notification.unshift(model);
     this.countNotification();
     this.changeDetect.detectChanges();
      
    });
  }

  getAllNotification() {
    let obj = {
      params: {},
    };
    this.notificationservice.getAllNotification(obj).subscribe((res: any) => {
      this.notification = res.result;
      this.countNotification();
    });
  }
  countNotification() {
    this.notificationCount = this.notification.filter(
      (a) => a.isSeen == 0
    ).length;
    console.log(this.notificationCount);
  }

  
}
