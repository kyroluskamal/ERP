import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs';
import { ConstantsService } from './constants.service';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {
  //properties
  SelectedLang: any = 'en';
  languages: string[] = ['en', 'ar'];
  selected: any = "en";
  SelectedLangSubject: Subject<any>;

  //constructor
  constructor(public translate: TranslateService, private Constants: ConstantsService) {
    this.SelectedLangSubject = new Subject<string>();
    this.SelectedLangSubject.next(this.selected);
    translate.addLangs(this.languages);
    translate.setDefaultLang(this.SelectedLang);
    this.SelectedLang = localStorage.getItem('lang');
    if (!localStorage.getItem('lang') && (JSON.parse(this.SelectedLang) === undefined || JSON.parse(this.SelectedLang) === null)) {
      this.setTranslationLang('en');
    } else {
      this.setTranslationLang(this.SelectedLang);
    }
  }

  setTranslationLang(lang: any) {
    this.Constants.CurrentLang = lang;
    this.translate.use(lang);
    localStorage.setItem("lang", lang);
    this.selected = localStorage.getItem('lang');
    this.SelectedLangSubject.next(this.selected);
    return this.selected;
  }

  getLangs() {
    return this.translate.getLangs();
  }

  GetTranslation(key: string) {

    return this.translate.instant(key);
  }
  GetCurrentLang() {
    return this.translate.currentLang;
  }
  NameByCode(lang: any): string {
    switch (lang) {
      case 'aa': return 'Afar';
      case 'ab': return 'Abkhazian';
      case 'ae': return 'Avestan';
      case 'af': return 'Afrikaans';
      case 'ak': return 'Akan';
      case 'am': return 'Amharic';
      case 'an': return 'Aragonese';
      case 'ar': return 'Arabic';
      case 'as': return 'Assamese';
      case 'av': return 'Avaric';
      case 'ay': return 'Aymara';
      case 'az': return 'Azerbaijani';
      case 'ba': return 'Bashkir';
      case 'be': return 'Belarusian';
      case 'bg': return 'Bulgarian'
      case 'bh': return 'Bihari';
      case 'bi': return 'Bislama';
      case 'bm': return 'Bambara';
      case 'bn': return 'Bengali';
      case 'bo': return 'Tibetan';
      case 'br': return 'Breton';
      case 'bs': return 'Bosnian';
      case 'ca': return 'Catalan';
      case 'ce': return 'Chechen';
      case 'ch': return 'Chamorro';
      case 'co': return 'Corsican';
      case 'cr': return 'Cree';
      case 'cs': return 'Czech';
      case 'cu': return 'Slavonic';
      case 'cv': return 'Chuvash';
      case 'cy': return 'Welsh';
      case 'da': return 'Danish';
      case 'de': return 'German';
      case 'dv': return 'Maldivian';
      case 'dz': return 'Dzongkha'
      case 'ee': return 'Ewe';
      case 'el': return 'Greek';
      case 'en': return 'English';
      case 'eo': return 'Esperanto'
      case 'es': return 'Spanish';
      case 'et': return 'Estonian';
      case 'eu': return 'Basque';
      case 'fa': return 'Persian';
      case 'ff': return 'Fulah';
      case 'fi': return 'Finnish';
      case 'fj': return 'Fijian';
      case 'fo': return 'Faroese';
      case 'fr': return 'French';
      case 'fy': return 'Western Frisian';
      case 'ga': return 'Irish';
      case 'gd': return 'Gaelic';
      case 'gl': return 'Galician';
      case 'gn': return 'Guarani';
      case 'gu': return 'Gujarati'
      case 'gv': return 'Manx';
      case 'ha': return 'Hausa';
      case 'he': return 'Hebrew';
      case 'hi': return 'Hindi';
      case 'ho': return 'Hiri Motu';
      case 'hr': return 'Croatian';
      case 'ht': return 'Haitian';
      case 'hu': return 'Hungarian';
      case 'hy': return 'Armenian';
      case 'hz': return 'Herero';
      case 'ia': return 'Interlingua';
      case 'id': return 'Indonesian';
      case 'ie': return 'Interlingue';
      case 'ig': return 'Igbo';
      case 'ii': return 'Nuosu';
      case 'ik': return 'Inupiaq';
      case 'io': return 'Ido';
      case 'is': return 'Icelandic';
      case 'it': return 'Italian';
      case 'iu': return 'Inuktitut';
      case 'ja': return 'Japanese';
      case 'jv': return 'Javanese';
      case 'ka': return 'Georgian';
      case 'kg': return 'Kongo';
      case 'ki': return 'Kikuyu';
      case 'kj': return 'Kuanyama';
      case 'kk': return 'Kazakh';
      case 'kl': return 'Kalaallisut';
      case 'km': return 'Khmer';
      case 'kn': return 'Kannada';
      case 'ko': return 'Korean';
      case 'kr': return 'Kanuri';
      case 'ks': return 'Kashmiri';
      case 'ku': return 'Kurdish';
      case 'kv': return 'Komi';
      case 'kw': return 'Cornish';
      case 'ky': return 'Kirghiz';
      case 'la': return 'Latin';
      case 'lb': return 'Luxembourgish';
      case 'lg': return 'Ganda';
      case 'li': return 'Limburgan';
      case 'ln': return 'Lingala';
      case 'lo': return 'Lao';
      case 'lt': return 'Lithuanian';
      case 'lu': return 'Luba-Katanga';
      case 'lv': return 'Latvian';
      case 'mg': return 'Malagasy';
      case 'mh': return 'Marshallese';
      case 'mi': return 'Maori';
      case 'mk': return 'Macedonian';
      case 'ml': return 'Malayalam';
      case 'mn': return 'Mongolian';
      case 'mr': return 'Marathi';
      case 'ms': return 'Malay';
      case 'mt': return 'Maltese';
      case 'my': return 'Burmese';
      case 'na': return 'Nauru';
      case 'nb': return 'Norwegian Bokmål';
      case 'nd': return 'Ndebele';
      case 'ne': return 'Nepali';
      case 'ng': return 'Ndonga';
      case 'nl': return 'Dutch';
      case 'nn': return 'Norwegian Nynorsk';
      case 'no': return 'Norwegian';
      case 'nr': return 'Ndebele';
      case 'nv': return 'Navajo';
      case 'ny': return 'Chichewa';
      case 'oc': return 'Occitan';
      case 'oj': return 'Ojibwa';
      case 'om': return 'Oromo';
      case 'or': return 'Oriya';
      case 'os': return 'Ossetian';
      case 'pa': return 'Panjabi';
      case 'pi': return 'Pali';
      case 'pl': return 'Polish';
      case 'ps': return 'Pushto';
      case 'pt': return 'Portuguese';
      case 'qu': return 'Quechua';
      case 'rm': return 'Romansh';
      case 'rn': return 'Rundi';
      case 'ro': return 'Romanian';
      case 'ru': return 'Russian';
      case 'rw': return 'Kinyarwanda';
      case 'sa': return 'Sanskrit';
      case 'sc': return 'Sardinian';
      case 'sd': return 'Sindhi';
      case 'se': return 'Northern Sami';
      case 'sg': return 'Sango';
      case 'si': return 'Sinhala';
      case 'sk': return 'Slovak';
      case 'sl': return 'Slovenian';
      case 'sm': return 'Samoan';
      case 'sn': return 'Shona';
      case 'so': return 'Somali';
      case 'sq': return 'Albanian';
      case 'sr': return 'Serbian';
      case 'ss': return 'Swati';
      case 'st': return 'Sotho';
      case 'su': return 'Sundanese';
      case 'sv': return 'Swedish';
      case 'sw': return 'Swahili';
      case 'ta': return 'Tamil';
      case 'te': return 'Telugu';
      case 'tg': return 'Tajik';
      case 'th': return 'Thai';
      case 'ti': return 'Tigrinya';
      case 'tk': return 'Turkmen';
      case 'tl': return 'Tagalog';
      case 'tn': return 'Tswana';
      case 'to': return 'Tonga';
      case 'tr': return 'Turkish';
      case 'ts': return 'Tsonga';
      case 'tt': return 'Tatar';
      case 'tw': return 'Twi';
      case 'ty': return 'Tahitian';
      case 'ug': return 'Uighur';
      case 'uk': return 'Ukrainian';
      case 'ur': return 'Urdu';
      case 'uz': return 'Uzbek';
      case 've': return 'Venda';
      case 'vi': return 'Vietnamese';
      case 'vo': return 'Volapük';
      case 'wa': return 'Walloon';
      case 'wo': return 'Wolof';
      case 'xh': return 'Xhosa';
      case 'yi': return 'Yiddish';
      case 'yo': return 'Yoruba';
      case 'za': return 'Zhuang';
      case 'zh': return 'Chinese';
      case 'zu': return 'Zulu';
      default: return "unknown";
    }
  }

  isRightToLeft(lang: any) {
    switch (lang) {
      case 'ar': return true;
      case 'arc': return true;
      case 'dv': return true;
      case 'fa': return true;
      case 'ha': return true;
      case 'he': return true;
      case 'khw': return true;
      case 'ks': return true;
      case 'ku': return true;
      case 'ps': return true;
      case 'ur': return true;
      case 'yi': return true;
      default: return false;
    }
  }
}
