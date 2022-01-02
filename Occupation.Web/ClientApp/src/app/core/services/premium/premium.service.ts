import { Injectable } from "@angular/core";
import { AppConfig } from "src/app/app.config";
import { ApiService } from "../api/api.service";

@Injectable({
  providedIn: "root",
})
export class PremiumService {
  constructor(private http: ApiService) {}

  public calculateYearlyDeathPremium(
    premiumByOccupationInput: any
  ): Promise<number> {
    return this.http
      .post(AppConfig.endpoint.yearlyPremium, premiumByOccupationInput)
      .toPromise()
      .then((response) => response)
      .catch((error) => {
        throw error;
      });
  }
}
