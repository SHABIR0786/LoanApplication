export const ApiRoute = {
  loanstatus: "AdminLoanStatus/GetById",
  loanDetailsById: "AdminLoanDetail/GetById",
  loanProgramDetails: "AdminLoanProgram/GetById",
  adminUserDetailsById: "AdminUser/GetById",
  updateAdminUserName: "http://localhost:21021/api/AdminUser/ChangeUsername?",
  updateAdminEmailAddress: "http://localhost:21021/api/AdminUser/ChangeEmail?",
  documentupload: "AdminLoanApplicationDocument/Upload",
  adminDisclouser: "AdminDisclosures/GetById",
  loanSummary: "services/app/LoanDetailServices/Get",
  updateChangePassword: "http://localhost:21021/api/AdminUser/ChangePassword?",
  loanApplication: "services/app/Loan/GetAllCustom?",
  adminnotification: "AdminUserNotification/GetAll",
  GetCurrentLoginInformations:
    "services/app/Session/GetCurrentLoginInformations",
    getCitizenshipType: "services/app/CitizenshipTypeService/GetCitizenshipTypes",
    createMortgageLoanApplication: "services/app/Mortgage/CreateMortgageLoanApplication",

  createMortgageApplicationAssetandLiability:"services/app/MortgageApplicationFinancialAsset/CreateMortgageApplicationAssetandLiability",
  getMortgageApplicationAssetandLiability:"services/app/MortgageApplicationFinancialAsset/GetAll",
  getCountry:"services/app/CountryService/GetCountries",
  getStates:"services/app/StateService/GetStates",
  getCities:"services/app/CityService/GetCities",
  createFinancialRealEstate:"services/app/MortgagePropertyFinancialInformationService/CreateMortgagePropertyFinancialInformation",
  createFinancialInfo:"services/app/MortgageApplicationLoanPropertyService/CreateMortgageApplicationLoanProperty"
};
