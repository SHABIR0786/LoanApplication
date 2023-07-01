export const ApiRoute = {
  loanstatus: "AdminLoanStatus/GetById",
  loanDetailsById: "AdminLoanDetail/GetById",
  loanProgramDetails: "AdminLoanProgram/GetById",
  adminUserDetailsById: "AdminUser/GetById",
  updateAdminUserName: "AdminUser/ChangeUsername?",
  updateAdminEmailAddress: "AdminUser/ChangeEmail?",
  documentupload: "AdminLoanApplicationDocument/Upload",
  adminDisclouser: "AdminDisclosures/GetById",
  loanSummary: "services/app/LoanDetailServices/Get",
  updateChangePassword: "AdminUser/ChangePassword?",
  loanApplication: "services/app/Loan/GetAllCustom?",
  adminnotification: "AdminUserNotification/GetAll",
  GetCurrentLoginInformations:
    "services/app/Session/GetCurrentLoginInformations",
  getCitizenshipType: "services/app/CitizenshipTypeService/GetCitizenshipTypes",
  createMortgageLoanApplication:
    "services/app/Mortgage/CreateMortgageLoanApplication",

  createMortgageApplicationAssetandLiability:
    "services/app/MortgageApplicationFinancialAsset/CreateMortgageApplicationAssetandLiability",
  getMortgageApplicationAssetandLiability:
    "services/app/MortgageApplicationFinancialAsset/GetAll",
  getCountry: "services/app/CountryService/GetCountries",
  getStates: "services/app/StateService/GetStates",
  getCities: "services/app/CityService/GetCities",
  createFinancialRealEstate:
    "services/app/MortgagePropertyFinancialInformationService/CreateMortgagePropertyFinancialInformation",
  createFinancialInfo:
    "services/app/MortgageApplicationLoanPropertyService/CreateMortgageApplicationLoanProperty",
  createDeclarations: "services/app/Mortgage/MortgageApplicationQuestions",
  createApplicationAgreement:
    "services/app/Mortgage/CreateMortgageApplicationAgreement",
  createMilitaryService:
    "services/app/MortgageApplicationLoanPropertyService/CreateMilitaryService",
  createDemoGraphicInfo:
    "services/app/MortgageApplicationDemographicInformationService/CreateDemographicInformation",
  createLoanOriginatorInfo:
    "services/app/MortgageApplicationLoanPropertyService/CreateOriginatorInformation",
};
