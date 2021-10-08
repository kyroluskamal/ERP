import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-client-app-home',
  templateUrl: './client-app-home.component.html',
  styleUrls: ['./client-app-home.component.css']
})
export class CLientAppHomeComponent implements OnInit {

  constructor(private title: Title) { }

  ngOnInit(): void {
  }

}
