import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-owners-dash-board',
  templateUrl: './owners-dash-board.component.html',
  styleUrls: ['./owners-dash-board.component.css']
})
export class OwnersDashBoardComponent implements OnInit {
  showFiller: boolean = false;
  constructor(private TitleService : Title) { }

  ngOnInit(): void {
    this.TitleService.setTitle("OwnerDashboard");
  }

}
