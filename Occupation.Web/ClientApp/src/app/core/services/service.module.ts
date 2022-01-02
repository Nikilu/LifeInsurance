import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ApiService } from "./api/api.service";
import { OccupationService } from "./occupation/occupation.service";
import { PremiumService } from "./premium/premium.service";

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [ApiService, OccupationService, PremiumService],
})
export class ServiceModule {}
