import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, NavigationEnd, NavigationExtras, Router } from '@angular/router';
import { filter } from 'rxjs/operators';


@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  error: any;
  back: string = "";
  @Input("extras") extras: any;
  constructor(private router: Router, private location: Location) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras?.state?.error == null) this.GoToHome();
    this.error = navigation?.extras?.state?.error; 
  }

  ngOnInit(): void {
    //this.error = localStorage.getItem("ServerError");
    //this.error = JSON.parse(this.error);
    //this.error = this.error.state.error;
    //localStorage.removeItem("ServerError");
  }
  GoToHome() {
    //this.router.events
    //  .pipe(
    //    filter(e => e instanceof NavigationEnd)
    //  )
    //  .subscribe((navEnd: any) => {
    //    window.location.assign("/");
    //  });
    this.location.back();
  }
}

