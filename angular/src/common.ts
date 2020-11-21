export interface PageResult<T> {
  totalCount: number;
  items: T[];
}

export interface Result<T> {
  result: PageResult<T>;
  targetUrl: string;
  success: boolean;
  urror: string;
  unAuthorizedRequest: boolean;
}

export interface SiteSettings {
  id: number;
  pageIdentifier: "app/home" | "";
  pageName: string;
  pageSetting: "";
}

export interface CommonHomeCard {
  FilePath: string;
  File?: string;
  Header: string;
  SubHeader: string;
  Description: string;
}

export interface Checklist {
  MainHeader: string;
  Checklist1: string;
  Checklist2: string;
  Checklist3: string;
  Checklist4: string;
}

export interface Testimonial {
  Comment: string;
  Author: string;
}

export interface HomeSettings {
  MainCarousels: CommonHomeCard[];
  FirstBlog: CommonHomeCard;
  SecondBlog: CommonHomeCard;
  ThirdBlog: CommonHomeCard;
  ForthBlog: CommonHomeCard;
  VideoSection: CommonHomeCard;
  KnowAboutHeader: string;
  Checklist: Checklist;
  Slogan: string;
  SloganChecklist: string;
  Testimonials: Testimonial[];
}
