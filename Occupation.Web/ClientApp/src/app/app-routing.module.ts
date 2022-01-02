import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LandingPageComponent } from "./components/home/landing-page/landing-page.component";
import { OccupationListComponent } from "./components/occupation/occupation-list/occupation-list.component";
import { QuoteToolComponent } from "./components/quote/quote-tool/quote-tool.component";

export const routes: Routes = [
  {
    path: "",
    component: LandingPageComponent,
  },
  {
    path: "occupation-list",
    component: OccupationListComponent,
  },
  {
    path: "quote-tool",
    component: QuoteToolComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: "legacy" })],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
