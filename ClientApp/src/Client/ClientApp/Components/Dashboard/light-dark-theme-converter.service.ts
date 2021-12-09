import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ThemeColor } from 'src/Interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})
export class LightDarkThemeConverterService {

  private CurrentThemeClass: Subject<string> = new Subject<string>()
  private ThemeColors: Subject<ThemeColor> = new Subject<ThemeColor>()
  private TableTheme: Subject<string> = new Subject<string>()
  private agGridTable_dir: Subject<'rtl' | 'ltr'> = new Subject<'rtl' | 'ltr'>()
  private ThemeDir: Subject<'rtl' | 'ltr'> = new Subject<'rtl' | 'ltr'>()


  get CurrentThemeClass$() {
    return this.CurrentThemeClass.asObservable();
  }
  get agGridTable_dir$() {
    return this.agGridTable_dir.asObservable();
  }
  get ThemeDir$() {
    return this.ThemeDir.asObservable();
  }
  get TableTheme$() {
    return this.TableTheme.asObservable();
  }
  // set CurrentThemeClass2$(currentTheme: string) {
  //   this.CurrentThemeClass.next(currentTheme);
  // }
  get ThemeColors$() {
    return this.ThemeColors.asObservable();
  }
  ChangeTheme(DarkOrLight: string) {
    this.CurrentThemeClass.next(DarkOrLight);
  }
  ChangeCurrentColor(ThemeColor: ThemeColor) {
    this.ThemeColors.next(ThemeColor);
  }
  ChangeAgGridTable_dir(dir: 'rtl' | 'ltr') {
    this.agGridTable_dir.next(dir);
  }
  ChangeTableTheme(DarkOrLight: string) {
    this.TableTheme.next(DarkOrLight);
  }
  PassThemeDir(dir: 'rtl' | 'ltr') {
    this.ThemeDir.next(dir);
  }
  constructor() {
    let temp: any = localStorage.getItem("BodyAppeareance");
    this.ChangeCurrentColor(temp);

    let ThemColor: any = localStorage.getItem("ChoosenThemeColors");
    ThemColor = JSON.parse(ThemColor);
    this.ChangeCurrentColor(ThemColor);
  }
}
