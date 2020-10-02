import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {FormGroup} from '@angular/forms';

@Injectable()
export class DataService {

    validationSource = new BehaviorSubject<any[]>([]);
    validations = this.validationSource.asObservable();

    constructor() {
    }

    updateValidations(formGroup: FormGroup) {
        if (formGroup) {
            const errors = Object.keys(formGroup.controls).map(key => ({
                controlName: key,
                error: formGroup.controls[key].errors !== null
            })).filter(error => error.error);
            this.validationSource.next(errors);
        }
    }
}
