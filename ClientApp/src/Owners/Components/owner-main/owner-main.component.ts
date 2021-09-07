import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-owner-main',
  templateUrl: './owner-main.component.html',
  styleUrls: ['./owner-main.component.css']
})
export class OwnerMainComponent implements OnInit {
  @Input("apptitle") title: string = "";

  constructor() {
  }

  ngOnInit(): void {
  }

}
