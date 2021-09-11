import { Component, Inject, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-client-main-domain',
  templateUrl: './client-main-domain.component.html',
  styleUrls: ['./client-main-domain.component.css']
})
export class ClientMainDomainComponent implements OnInit {
  @Input("apptitle") title: string = "";
  
  notFound: boolean = false;
  constructor(private router: Router, private location: Location) {
  }

  ngOnInit(): void {
    //this.router.events
    //  .pipe(
    //    filter(e => e instanceof NavigationEnd)
    //  )
    //  .subscribe((navEnd: any) => {
    //   if ()
    //    //window.location.assign("/");
    //  });
  }

}
