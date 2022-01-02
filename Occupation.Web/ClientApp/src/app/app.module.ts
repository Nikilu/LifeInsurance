import { BrowserModule } from "@angular/platform-browser";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, Injector } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { OccupationListComponent } from "./components/occupation/occupation-list/occupation-list.component";
import {
  CustomAdapter,
  CustomDateParserFormatter,
  QuoteToolComponent,
} from "./components/quote/quote-tool/quote-tool.component";
import { LandingPageComponent } from "./components/home/landing-page/landing-page.component";
import { MatNativeDateModule } from "@angular/material/core";
import { ServiceModule } from "./core/services/service.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  NgbDateAdapter,
  NgbDateParserFormatter,
  NgbModule,
} from "@ng-bootstrap/ng-bootstrap";
import {
  FaIconLibrary,
  FontAwesomeModule,
} from "@fortawesome/angular-fontawesome";
import { faCalendar, faClock } from "@fortawesome/free-solid-svg-icons";
@NgModule({
  declarations: [
    AppComponent,
    OccupationListComponent,
    QuoteToolComponent,
    LandingPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    HttpClientModule,
    ServiceModule,
    NgbModule,
    FontAwesomeModule,
  ],
  providers: [
    { provide: NgbDateAdapter, useClass: CustomAdapter },
    { provide: NgbDateParserFormatter, useClass: CustomDateParserFormatter },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {
  public static injector: Injector;

  constructor(injector: Injector, library: FaIconLibrary) {
    AppModule.injector = injector;
    library.addIcons(faCalendar, faClock);
  }
}
