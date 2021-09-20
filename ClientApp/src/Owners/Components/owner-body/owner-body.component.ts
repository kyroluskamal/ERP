import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-owner-body',
  templateUrl: './owner-body.component.html',
  styleUrls: ['./owner-body.component.css']
})
export class OwnerBodyComponent implements OnInit {
  @Input("apptitle") title: string = "";
  constructor() { }

  ngOnInit(): void {
  }

}
