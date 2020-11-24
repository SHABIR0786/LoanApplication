import {
  Component,
  Injector,
  ChangeDetectionStrategy,
  OnInit,
  DoCheck,
} from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { HomeSettings, Result, SiteSettings } from "common";
import { SiteSettingService } from "@app/services/siteSetting.service";

@Component({
  templateUrl: "./home.component.html",
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./home.component.css"],
})
export class HomeComponent extends AppComponentBase implements OnInit, DoCheck {
  constructor(
    injector: Injector,
    private siteSettingService: SiteSettingService
  ) {
    super(injector);
  }

  isDataLoaded: boolean = false;
  data: HomeSettings;
  sloganChecklist: string[];
  // FORM SECTION
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  phoneNumber?: number = null;
  mortgagePurposes = [];
  howDoYouWantToBorrows = [];

  // FORM SECTION
  loadMortgagePurposes() {
    this.mortgagePurposes = [
      { id: 1, name: "Found A Home/ Made An Offer" },
      { id: 2, name: "Still Looking For A Home" },
      { id: 3, name: "Refinance" },
      { id: 4, name: "Refinance With Cashout" },
    ];
  }

  loadHowDoYouWantToBorrows() {
    this.howDoYouWantToBorrows = [
      { id: 1, name: "found" },
      { id: 2, name: "still" },
      { id: 3, name: "refinance" },
      { id: 4, name: "With" },
    ];
  }

  ngDoCheck() {}

  ngOnInit() {
    this.siteSettingService
      .get("Index/id/1")
      .subscribe((response: Result<SiteSettings>) => {
        const homeSettings: HomeSettings = JSON.parse(
          response.result.pageSetting
        );
        this.data = homeSettings;
        this.data.FirstBlog.background = `url('${this.data.FirstBlog.FilePath}')`;
        this.data.SecondBlog.background = `url('${this.data.SecondBlog.FilePath}')`;
        this.sloganChecklist = this.data.SloganChecklist.split("\n");
        console.clear();
        console.log(this.data);

        this.isDataLoaded = true;
      });

    this.loadHowDoYouWantToBorrows();
  }
}
