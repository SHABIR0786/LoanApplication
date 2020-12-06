import { Component, ChangeDetectionStrategy } from "@angular/core";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./header.component.css"],
})
export class HeaderComponent {}
