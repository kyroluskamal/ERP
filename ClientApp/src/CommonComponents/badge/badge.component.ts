import { Component, Input, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';

@Component({
  selector: 'badge',
  templateUrl: './badge.component.html',
  styleUrls: ['./badge.component.css']
})
export class BadgeComponent implements OnInit {

  @Input() text: string = "";
  @Input() color: string = "";
  classes: string = ""
  constructor(public Constants: ConstantsService) { }
  ngOnInit(): void {
    this.classes = `${this.Constants.CSS_badge} ${this.color}`
  }

}
