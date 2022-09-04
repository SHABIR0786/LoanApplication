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
};
