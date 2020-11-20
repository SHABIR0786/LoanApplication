export interface ITestimonial {
  comments?: string;
  names?: string;
}

export interface ITipsForGettingAHomeMortgage {
  picture?: string;
  heading?: string;
}

export interface IFeaturedMortgage {
  image2?: string;
  topCaptiom3?: string;
  heading3?: string;
}

export interface IMainCarousel {
  slider?: string;
  header?: string;
  subHeader?: string;
}

export interface IHomePage {
  // Top Carousel

  mainCarousels?: IMainCarousel[];
  // Featured Mortgage Options Section 1

  image?: string;
  topCaptiom1?: string;
  heading1?: string;
  bottomCaption1?: string;
  // Featured Mortgage Options Section 2

  image1?: string;
  topCaptiom2?: string;
  heading2?: string;
  bottomCaption2?: string;
  // Featured Mortgage Options Section 2 Sub Section 1

  featuredMortgages?: IFeaturedMortgage[];
  // Your Independent Mortgage Broker In California Section

  video?: string;
  // Tips For Getting A Home Mortgage In California Section 1

  mainHeading?: string;
  subMainHeading?: string;
  tipsForGettingAHomeMortgages?: ITipsForGettingAHomeMortgage[];
  // Tips For Getting A Home Mortgage In California Section 2

  image4?: string;
  paragraph?: string;

  // Our Customer Says
  testimonials?: ITestimonial[];
}
