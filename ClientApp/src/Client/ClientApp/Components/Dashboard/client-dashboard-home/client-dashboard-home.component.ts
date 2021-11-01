import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-client-dashboard-home',
  templateUrl: './client-dashboard-home.component.html',
  styleUrls: ['./client-dashboard-home.component.css']
})
export class ClientDashboardHomeComponent implements OnInit {
  //properties
  MediaSubscription: Subscription = new Subscription();
  gridCols: number = 4;
  fontSize: string = '0.5rem';
  //constructor
  constructor(private mediaObserver: MediaObserver, public Constants: ConstantsService) { }

  ngOnInit(): void {
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'lt-sm')) {
          this.gridCols = 1;
          this.fontSize = "0.2rem";
        } else {
          this.gridCols = 4;
          this.fontSize = "0.5rem";
        };
      }
    );
  }

}
