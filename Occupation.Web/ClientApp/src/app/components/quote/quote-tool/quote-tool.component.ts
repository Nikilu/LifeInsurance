import { Component, Injectable, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import {
  NgbDateAdapter,
  NgbDateParserFormatter,
  NgbDateStruct,
} from "@ng-bootstrap/ng-bootstrap";
import { OccupationService } from "src/app/core/services";
import { PremiumService } from "src/app/core/services/premium/premium.service";

/**
 * This Service handles how the date is represented in scripts i.e. ngModel.
 */
@Injectable()
export class CustomAdapter extends NgbDateAdapter<string> {
  readonly DELIMITER = "/";

  fromModel(value: string | null): NgbDateStruct | null {
    if (value) {
      const date = value.split(this.DELIMITER);
      return {
        day: parseInt(date[0], 10),
        month: parseInt(date[1], 10),
        year: parseInt(date[2], 10),
      };
    }
    return null;
  }

  toModel(date: NgbDateStruct | null): string | null {
    return date
      ? date.day + this.DELIMITER + date.month + this.DELIMITER + date.year
      : null;
  }
}

/**
 * This Service handles how the date is rendered and parsed from keyboard i.e. in the bound input field.
 */
@Injectable()
export class CustomDateParserFormatter extends NgbDateParserFormatter {
  readonly DELIMITER = "/";

  parse(value: string): NgbDateStruct | null {
    if (value) {
      const date = value.split(this.DELIMITER);
      return {
        day: parseInt(date[0], 10),
        month: parseInt(date[1], 10),
        year: parseInt(date[2], 10),
      };
    }
    return null;
  }

  format(date: NgbDateStruct | null): string {
    return date
      ? date.day + this.DELIMITER + date.month + this.DELIMITER + date.year
      : "";
  }
}

@Component({
  selector: "app-quote-tool",
  templateUrl: "./quote-tool.component.html",
  styleUrls: ["./quote-tool.component.scss"],
})
export class QuoteToolComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private occupationService: OccupationService,
    private premiumService: PremiumService
  ) {}

  onSubmit(form) {
    console.log(form.value);
  }

  public quoteToolForm: FormGroup;
  public quoteInfo?: any = {};
  public occupations?: any;
  public age: any;
  public deathPremium: number;

  submitted = false;
  public formErrors = {
    name: "",
    dateOfBirth: "",
    occupationId: "",
    coverAmount: "",
  };

  public validationMessages = {
    name: {
      required: "Please enter name",
      maxlength: "Maximum 50 characters allowed",
    },
    dateOfBirth: {
      required: "Please enter a Date of Birth",
    },
    occupationId: {
      required: "Please select an occupation",
    },
    coverAmount: {
      required: "Insured amount is required.",
      pattern: "The Insured amount must be greater than 0.00",
    },
  };

  async ngOnInit() {
    try {
      await this.setOccupations();
      this.buildForm();
    } catch (error) {
      throw error;
    } finally {
    }
  }

  private buildForm(): void {
    this.quoteToolForm = this.formBuilder.group({
      name: [
        this.quoteInfo ? this.quoteInfo.name : "",
        Validators.compose([Validators.required, Validators.maxLength(50)]),
      ],
      dateOfBirth: [
        this.quoteInfo ? this.quoteInfo.dateOfBirth : "",
        Validators.compose([Validators.required]),
      ],
      occupationId: [
        this.quoteInfo ? this.quoteInfo.occupationId : "",
        Validators.compose([Validators.required]),
      ],
      coverAmount: [
        this.quoteInfo ? this.quoteInfo.coverAmount : "",
        Validators.compose([
          Validators.required,
          Validators.pattern(/^\d{0,8}(\.\d{1,2})?$/),
        ]),
      ],
    });
    this.quoteToolForm.valueChanges.subscribe(() => this.onValueChanged());

    this.onValueChanged();
  }

  private async setOccupations() {
    try {
      if (!this.occupations) {
        this.occupations = await this.occupationService.getOccupationList();
      }
    } catch (error) {
      throw error;
    }
  }
  private onValueChanged() {
    this.onFormValueChanged(
      this.quoteToolForm,
      this.formErrors,
      this.validationMessages
    );
  }

  public onFormValueChanged(
    form: any,
    formErrors: any,
    validationMessages: any
  ): void {
    if (!form) {
      return;
    }
    // tslint:disable-next-line:forin
    for (const field in formErrors) {
      formErrors[field] = "";
      const control = form.get(field);
      if (control && control.dirty && !control.valid) {
        const messages = validationMessages[field];
        for (const key in control.errors) {
          if (formErrors[field] === "" || formErrors[field] === undefined) {
            formErrors[field] += messages[key] + " ";
          }
        }
      }
    }
  }

  public calculateAge() {
    if (this.quoteToolForm.value.dateOfBirth) {
      let dateOfBirth = this.convertToDate(
        this.quoteToolForm.value.dateOfBirth
      );

      this.setAge(dateOfBirth);
      console.log("calculateAge");
    }
  }

  public async calculatePremium() {
    try {
      this.updateQuoteInfo();
      this.deathPremium = await this.premiumService.calculateYearlyDeathPremium(
        this.quoteInfo
      );
    } catch (error) {
      this.deathPremium = 0;
    }
  }

  private updateQuoteInfo(): void {
    this.quoteInfo.occupationId = this.quoteToolForm.value.occupationId;
    this.quoteInfo.coverAmount = this.quoteToolForm.value.coverAmount;
    this.quoteInfo.dateOfBirth = this.convertToDate(
      this.quoteToolForm.value.dateOfBirth
    );
  }

  private convertToDate(dateString): Date {
    let d = dateString.split("/");
    let dat = new Date(d[2] + "/" + d[1] + "/" + d[0]);
    return dat;
  }

  private setAge(dob) {
    var timeDiff = Math.abs(Date.now() - new Date(dob).getTime());
    var age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
    if (age) this.age = age;
    else this.age = "";
  }
}

export const DateTimeValidator = (fc: FormControl) => {
  const date = new Date(fc.value);
  const isValid = !isNaN(date.valueOf());
  return isValid
    ? null
    : {
        isValid: {
          valid: false,
        },
      };
};
