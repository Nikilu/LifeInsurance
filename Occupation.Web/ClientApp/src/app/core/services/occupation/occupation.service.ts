import { Injectable } from "@angular/core";
import { AppConfig } from "../../../app.config";
import { ApiService } from "../api/api.service";

@Injectable({
  providedIn: "root",
})
export class OccupationService {
  constructor(private http: ApiService) {}

  public async getOccupationList() {
    return this.http
      .get(AppConfig.endpoint.occupations)
      .toPromise()
      .then((response) => response)
      .catch((error) => {
        throw error;
      });
  }
}
