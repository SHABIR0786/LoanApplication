import { Component, DoCheck, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { IHomePage } from "./types";

@Component({
  selector: "app-admin-panel",
  templateUrl: "./admin-panel.component.html",
  styleUrls: ["./admin-panel.component.css"],
})
export class AdminPanelComponent implements OnInit, DoCheck {
  pages = [];
  currentPage?: number = null;
  HomePageForm: FormGroup;
  homePage: IHomePage = {};

  ngOnInit(): void {
    this.pages = [
      {
        id: 1,
        name: "Home page",
        path: "app/home",
      },
    ];

    this.HomePageForm = new FormGroup({
      sliders: new FormControl(this.homePage.sliders),
      header: new FormControl(this.homePage.header),
      subHeader: new FormControl(this.homePage.subHeader),
      image: new FormControl(this.homePage.image),
      topCaptiom1: new FormControl(this.homePage.topCaptiom1),
      heading1: new FormControl(this.homePage.heading1),
      bottomCaption1: new FormControl(this.homePage.bottomCaption1),
      image1: new FormControl(this.homePage.image1),
      topCaptiom2: new FormControl(this.homePage.topCaptiom2),
      heading2: new FormControl(this.homePage.heading2),
      bottomCaption2: new FormControl(this.homePage.bottomCaption2),
      image2: new FormControl(this.homePage.image2),
      topCaptiom3: new FormControl(this.homePage.topCaptiom3),
      heading3: new FormControl(this.homePage.heading3),
      image3: new FormControl(this.homePage.image3),
      topCaptiom4: new FormControl(this.homePage.topCaptiom4),
      heading4: new FormControl(this.homePage.heading4),
      video: new FormControl(this.homePage.video),
      mainHeading: new FormControl(this.homePage.mainHeading),
      subMainHeading: new FormControl(this.homePage.subMainHeading),
      subHeading1: new FormControl(this.homePage.subHeading1),
      subHeading2: new FormControl(this.homePage.subHeading2),
      subHeading3: new FormControl(this.homePage.subHeading3),
      subHeading4: new FormControl(this.homePage.subHeading4),
      image4: new FormControl(this.homePage.image4),
      paragraph: new FormControl(this.homePage.paragraph),
      comments: new FormControl(this.homePage.comments),
      names: new FormControl(this.homePage.names),
    });
  }

  setPageId(currentPage: number) {
    this.currentPage = currentPage;
  }

  ngDoCheck() {
    console.log(this.HomePageForm);
  }
}
