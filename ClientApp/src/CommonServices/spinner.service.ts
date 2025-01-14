import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService
{

  constructor(private spinner: NgxSpinnerService, private translate: TranslationService) { }

  fullScreenSpinner()
  {
    return this.spinner.show('general', {
      fullScreen: true,
      type: "ball-clip-rotate-pulse",
      size: "large",
      bdColor: "rgba(0, 0, 0, 0.25)",
      color: "white",
      zIndex: 500000
    });
  }
  fullScreenSpinnerForForm()
  {
    return this.spinner.show('form', {
      fullScreen: true,
      type: "ball-clip-rotate-pulse",
      size: "large",
      bdColor: "rgba(0, 0, 0, 0.25)",
      color: "white",
      zIndex: 500000
    });
  }
  InsideContainerSpinner()
  {
    return this.spinner.show('inside', {
      fullScreen: false,
      type: "ball-clip-rotate-pulse",
      size: "medium",
      bdColor: "rgba(0, 0, 0, 1)",
      color: "white",
    });
  }
  removeSpinner()
  {
    this.spinner.hide('general');
    this.spinner.hide('inside');
    this.spinner.hide('form');
  }
}
