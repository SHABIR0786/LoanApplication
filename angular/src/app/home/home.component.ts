import { Component, Injector, ChangeDetectionStrategy } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
  templateUrl: "./home.component.html",
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./home.component.css"],
})
export class HomeComponent extends AppComponentBase {
  // buyingAHome: string = "Buying A home Guide";

  constructor(injector: Injector) {
    super(injector);
  }
}
