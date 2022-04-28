import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { FormArray, FormGroup } from "@angular/forms";
import { ILoanApplicationModel } from "../interfaces/ILoanApplicationModel";

@Injectable()
export class OfflineService {
  constructor() {}
  saveStep(step, data) {
    localStorage.setItem("offline", JSON.stringify(data));
    localStorage.setItem("step", step);
  }
  getStep() {
    return {
      step: localStorage.getItem("step"),
      data: localStorage.getItem("offline")
        ? JSON.parse(localStorage.getItem("offline"))
        : null,
    };
  }
}
