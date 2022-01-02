import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent {
  title = "Life Insurance Quote Tool";
  links = [
    { title: "Home", fragment: "" },
    { title: "Quote Tool", fragment: "quote-tool" },
    { title: "Occupation List", fragment: "occupation-list" },
  ];

  constructor(public route: ActivatedRoute) {}
}
