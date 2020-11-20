import { Component, DoCheck, OnInit } from "@angular/core";
import { FormArray, FormBuilder, FormControl, FormGroup } from "@angular/forms";
import {
  IFeaturedMortgage,
  IMainCarousel,
  ITestimonial,
  ITipsForGettingAHomeMortgage,
} from "./types";
import { SiteSettingService } from "../services/siteSetting.service";
import {
  CommonHomeCard,
  HomeSettings,
  Result,
  SiteSettings,
  Testimonial,
} from "../../common";

@Component({
  selector: "app-admin-panel",
  templateUrl: "./admin-panel.component.html",
  styleUrls: ["./admin-panel.component.css"],
})
export class AdminPanelComponent implements OnInit, DoCheck {
  pages: SiteSettings[] = [];
  currentPage?: number = null;
  HomePageForm: FormGroup;

  get MainCarousels(): FormArray {
    return this.HomePageForm.get("MainCarousels") as FormArray;
  }

  get Testimonials(): FormArray {
    return this.HomePageForm.get("Testimonials") as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private siteSettingService: SiteSettingService
  ) {
    this.HomePageForm = new FormGroup({
      MainCarousels: this.fb.array(
        new Array(1).fill(
          this.initMainCarousel({
            Description: "",
            FilePath: "",
            Header: "",
            SubHeader: "",
          })
        )
      ),
      FirstBlog: this.fb.group({
        FilePath: [""],
        Header: [""],
        SubHeader: [""],
        Description: [""],
      }),
      SecondBlog: this.fb.group({
        FilePath: [""],
        Header: [""],
        SubHeader: [""],
        Description: [""],
      }),
      ThirdBlog: this.fb.group({
        FilePath: [""],
        Header: [""],
        SubHeader: [""],
        Description: [""],
      }),
      ForthBlog: this.fb.group({
        FilePath: [""],
        Header: [""],
        SubHeader: [""],
        Description: [""],
      }),
      VideoSection: this.fb.group({
        FilePath: [""],
        Header: [""],
        SubHeader: [""],
        Description: [""],
      }),
      KnowAboutHeader: this.fb.control(""),
      Checklist: this.fb.group({
        MainHeader: [""],
        Checklist1: [""],
        Checklist2: [""],
        Checklist3: [""],
        Checklist4: [""],
      }),
      Slogan: this.fb.control(""),
      SloganChecklist: this.fb.control(""),
      Testimonials: this.fb.array(
        new Array(1).fill(
          this.initTestimonials({
            Author: "",
            Comment: "",
          })
        )
      ),
    });
  }

  ngOnInit(): void {
    this.siteSettingService
      .post("all", {
        maxResultCount: 10,
        skipCount: 0,
      })
      .subscribe((response: Result<SiteSettings>) => {
        this.pages = response.result.items;
        console.log(this.pages);
      });
  }

  initTestimonials(data: Testimonial) {
    const form = this.fb.group({
      Comment: [data.Comment],
      Author: [data.Author],
    });

    return form;
  }

  initMainCarousel(data: CommonHomeCard) {
    const form = this.fb.group({
      FilePath: [data.FilePath],
      Header: [data.Header],
      SubHeader: [data.SubHeader],
    });

    return form;
  }

  addMainCarousel() {
    this.MainCarousels.push(
      this.initMainCarousel({
        Description: "",
        FilePath: "",
        Header: "",
        SubHeader: "",
      })
    );
  }

  addTestimonial() {
    this.Testimonials.push(
      this.initTestimonials({
        Author: "",
        Comment: "",
      })
    );
  }

  setPageId(currentPage: number) {
    this.currentPage = currentPage;
    const page = this.pages.find((i) => i.id === currentPage);

    switch (page.pageIdentifier) {
      case "app/home":
        const data: HomeSettings = JSON.parse(page.pageSetting);
        this.HomePageForm = new FormGroup({
          MainCarousels: this.fb.array(
            data.MainCarousels.map((i) => this.initMainCarousel(i))
          ),
          FirstBlog: this.fb.group({
            // FilePath: [data.FirstBlog.FilePath],
            FilePath: [""],
            Header: [data.FirstBlog.Header],
            SubHeader: [data.FirstBlog.SubHeader],
            Description: [data.FirstBlog.Description],
          }),
          SecondBlog: this.fb.group({
            //FilePath: [data.FirstBlog.FilePath],
            FilePath: [""],
            Header: [data.FirstBlog.Header],
            SubHeader: [data.FirstBlog.SubHeader],
            Description: [data.FirstBlog.Description],
          }),
          ThirdBlog: this.fb.group({
            //FilePath: [data.FirstBlog.FilePath],
            FilePath: [data.FirstBlog.FilePath],
            Header: [data.FirstBlog.Header],
            SubHeader: [data.FirstBlog.SubHeader],
            Description: [data.FirstBlog.Description],
          }),
          ForthBlog: this.fb.group({
            //FilePath: [data.ForthBlog.FilePath],
            FilePath: [data.FirstBlog.FilePath],
            Header: [data.ForthBlog.Header],
            SubHeader: [data.ForthBlog.SubHeader],
            Description: [data.ForthBlog.Description],
          }),
          VideoSection: this.fb.group({
            //FilePath: [data.VideoSection.FilePath],
            FilePath: [data.FirstBlog.FilePath],
            Header: [data.VideoSection.Header],
            SubHeader: [data.VideoSection.SubHeader],
            Description: [data.VideoSection.Description],
          }),
          KnowAboutHeader: this.fb.control(""),
          Checklist: this.fb.group({
            MainHeader: [data.Checklist.MainHeader],
            Checklist1: [data.Checklist.Checklist1],
            Checklist2: [data.Checklist.Checklist2],
            Checklist3: [data.Checklist.Checklist3],
            Checklist4: [data.Checklist.Checklist4],
          }),
          Slogan: this.fb.control(data.Slogan),
          SloganChecklist: this.fb.control(data.SloganChecklist),
          Testimonials: this.fb.array(
            data.Testimonials.map((i) => this.initTestimonials(i))
          ),
        });
        break;

      default:
        break;
    }
  }

  onSubmit() {}

  ngDoCheck() {}

  ConvertToInt(val: any) {
    return parseInt(val);
  }
}
