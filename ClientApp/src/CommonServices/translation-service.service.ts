import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {
  SelectedLang: string ='en';
  constructor(public translate: TranslateService) {
    translate.addLangs(['en', 'ar']);
    translate.setDefaultLang(this.SelectedLang);
    if (!localStorage.getItem('lang')) {
      this.setTranslationLang(this.SelectedLang);
    } else {
      this.setTranslationLang(localStorage.getItem('lang'));
    }
  }

  setTranslationLang(lang:any) {
    this.translate.use(lang);
    localStorage.setItem("lang", lang);
    return localStorage.getItem('lang');
  }

  getLangs() {
    return this.translate.getLangs();
  }
}
