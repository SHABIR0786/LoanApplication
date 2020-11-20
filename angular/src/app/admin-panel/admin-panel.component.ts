import { Component, DoCheck, OnInit } from "@angular/core";
import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { from } from "rxjs";
import {
  IFeaturedMortgage,
  IHomePage,
  IMainCarousel,
  ITestimonial,
  ITipsForGettingAHomeMortgage,
} from "./types";

@Component({
  selector: "app-admin-panel",
  templateUrl: "./admin-panel.component.html",
  styleUrls: ["./admin-panel.component.css"],
})
export class AdminPanelComponent implements OnInit, DoCheck {
  pages = [];
  currentPage?: number = null;
  HomePageForm: FormGroup;
  homePage: IHomePage = {
    mainCarousels: [{}],
    featuredMortgages: [{}, {}],
    tipsForGettingAHomeMortgages: [{}, {}, {}, {}],
    testimonials: [{}],
  };

  get testimonials(): FormArray {
    return this.HomePageForm.get("testimonials") as FormArray;
  }

  get tipsForGettingAHomeMortgages(): FormArray {
    return this.HomePageForm.get("tipsForGettingAHomeMortgages") as FormArray;
  }

  get featuredMortgages(): FormArray {
    return this.HomePageForm.get("featuredMortgages") as FormArray;
  }

  get mainCarousels(): FormArray {
    return this.HomePageForm.get("mainCarousels") as FormArray;
  }

  ngOnInit(): void {
    this.pages = [
      {
        id: 1,
        name: "Home Page",
        path: "app/home",
      },
    ];

    this.HomePageForm = new FormGroup({
      testimonials: new FormArray(
        this.homePage.testimonials.map((d) => this.initTestimonials(d))
      ),

      tipsForGettingAHomeMortgages: new FormArray(
        this.homePage.tipsForGettingAHomeMortgages.map((d) =>
          this.initTipsForGettingAHomeMortgages(d)
        )
      ),
      featuredMortgages: new FormArray(
        this.homePage.featuredMortgages.map((d) => this.initFeaturedMortgage(d))
      ),
      mainCarousels: new FormArray(
        this.homePage.mainCarousels.map((d) => this.initMainCarousel(d))
      ),
      image: new FormControl(this.homePage.image),
      topCaptiom1: new FormControl(this.homePage.topCaptiom1),
      heading1: new FormControl(this.homePage.heading1),
      bottomCaption1: new FormControl(this.homePage.bottomCaption1),
      image1: new FormControl(this.homePage.image1),
      topCaptiom2: new FormControl(this.homePage.topCaptiom2),
      heading2: new FormControl(this.homePage.heading2),
      bottomCaption2: new FormControl(this.homePage.bottomCaption2),
      video: new FormControl(this.homePage.video),
      mainHeading: new FormControl(this.homePage.mainHeading),
      subMainHeading: new FormControl(this.homePage.subMainHeading),
      image4: new FormControl(this.homePage.image4),
      paragraph: new FormControl(this.homePage.paragraph),
    });
  }

  initTestimonials(data: ITestimonial = {}) {
    const form = new FormGroup({
      comments: new FormControl(data.comments),
      names: new FormControl(data.names),
    });

    return form;
  }

  initTipsForGettingAHomeMortgages(data: ITipsForGettingAHomeMortgage = {}) {
    const form = new FormGroup({
      heading: new FormControl(data.heading),
      picture: new FormControl(data.picture),
    });

    return form;
  }

  initMainCarousel(data: IMainCarousel = {}) {
    const form = new FormGroup({
      header: new FormControl(data.header),
      slider: new FormControl(data.slider),
      subHeader: new FormControl(data.subHeader),
    });

    return form;
  }

  initFeaturedMortgage(data: IFeaturedMortgage = {}) {
    const form = new FormGroup({
      image2: new FormControl(data.image2),
      topCaptiom3: new FormControl(data.topCaptiom3),
      heading3: new FormControl(data.heading3),
    });

    return form;
  }

  addMainCarousel() {
    this.mainCarousels.push(this.initMainCarousel());
  }

  addTestimonial() {
    this.testimonials.push(this.initTestimonials());
  }

  setPageId(currentPage: number) {
    this.currentPage = currentPage;
  }

  onSubmit() {}

  ngDoCheck() {
    console.log(this.HomePageForm);
    console.log(this.homePage);
    this.homePage.mainCarousels = this.HomePageForm.value.mainCarousels;
    this.homePage.testimonials = this.HomePageForm.value.testimonials;
    this.homePage.featuredMortgages = this.HomePageForm.value.featuredMortgages;
    this.homePage.tipsForGettingAHomeMortgages = this.HomePageForm.value.tipsForGettingAHomeMortgages;
  }

  ConvertToInt(val: any) {
    return parseInt(val);
  }
}
