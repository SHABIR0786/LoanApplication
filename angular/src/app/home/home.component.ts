import {
  Component,
  Injector,
  ChangeDetectionStrategy,
  OnInit,
  DoCheck,
} from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
  templateUrl: "./home.component.html",
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./home.component.css"],
})
export class HomeComponent extends AppComponentBase implements OnInit, DoCheck {
  constructor(injector: Injector) {
    super(injector);
  }

  // FEATURED MORTGAGE COL-4 SECTION

  featuredMortgageImage: Object = {
    background: "url('assets/img/house-1.png') 0% 0% no-repeat",
    "background-size": "100% 100%",
  };
  getANoHassleLoan: string = "GET A NO-HASSLE LOAN FOR UP TO $697,650";
  fastClosing: string = "Fast Closing FHA Loans";
  takeAdvantage: string = "Take Advantage of our FHA Elite Rates starting at…";

  // FEATURED MORTGAGE COL-8 SECTION

  featuredMortgageImage1: object = {
    background: "url('assets/img/living-room.png') 0% 0% no-repeat",
    "background-size": "100% 48.2%",
    "background-origin": "content-box",
  };
  conventionalJomboRate: string = "Conventional Jombo Rate";
  saveCash: string = "Save cash with a low-rate conventional loan up to…";
  getANoHassleLoan1: string = "GET A NO-HASSLE LOAN FOR UP TO $697,650";

  featuredMortgageImages = [];

  // TIPS SECTION
  tips: string = "Tips For Getting A Home Mortgage In California";
  howToApplyLoan: string = "How To Apply For Your Loan";
  tipsSectionImage: string = "assets/img/finance.png";
  workWithLoanBrokers: string[] = [];
  calculateLoanRates = [];

  // YOUR INDEPENDENT SECTION
  youIndenentVideo: string = "assets/img/Image 16.png";

  // FORM SECTION
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  phoneNumber?: number = null;
  mortgagePurposes = [];
  howDoYouWantToBorrows = [];

  // FEATURED MORTGAGE COL-8 SECTION
  loadFeaturedMortgageImages() {
    this.featuredMortgageImages = [
      {
        image: "assets/img/money.png",
        caption: "Tap Into Your Equity",
        para: "We offer unique programs that let you refinance up…",
      },
      {
        image: "assets/img/new-home.png",
        caption: "Purchase Your Dream Home",
        para: "Your dream home may no longer be a dream…",
      },
    ];
  }

  // TIPS SECTION
  loadCalculateLoanRates() {
    this.calculateLoanRates = [
      { image: "assets/img/calculator.svg", name: "Calculate Loan Rate" },
      { image: "assets/img/support.svg", name: "Speak With An Expert" },
      { image: "assets/img/agenda.svg", name: "Benefit Of Preapproval" },
      { image: "assets/img/mortgage.svg", name: "Get A Free Quote" },
    ];
  }

  loadWorkWithLoanBrokers() {
    this.workWithLoanBrokers = [
      "Our easy-to-use online tools streamline the mortgage process.",
      "Get mortgage estimates, instant rate quotes, and access to our online calculators.",
      "Loan applications can be done entirely online (or via fax) on our secure portal.",
      "Receive updates about your application – as well as helpful mortgage news – on your phone, tablet or laptop",
    ];
  }

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
    this.loadMortgagePurposes();
    this.loadHowDoYouWantToBorrows();
    this.loadWorkWithLoanBrokers();
    this.loadCalculateLoanRates();
    this.loadFeaturedMortgageImages();
  }
}
