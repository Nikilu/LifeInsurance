import { Component, OnInit } from "@angular/core";
import { OccupationService } from "src/app/core/services/occupation/occupation.service";

@Component({
  selector: "app-occupation-list",
  templateUrl: "./occupation-list.component.html",
  styleUrls: ["./occupation-list.component.scss"],
})
export class OccupationListComponent implements OnInit {
  public occupationList: any;
  constructor(public occupationService: OccupationService) {}

  ngOnInit() {
    this.loadOccupationList();
  }

  public async loadOccupationList() {
    await this.occupationService.getOccupationList().then((respose) => {
      this.occupationList = respose;
    });
  }
}
