import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { AnimateOnScrollDirective } from 'src/Directives/animate-on-scroll.directive';

const SharedModules = [
  ReactiveFormsModule,
  HttpClientModule,
  CommonModule, TranslateModule
];
const Directives = [AnimateOnScrollDirective];
@NgModule({
  declarations: [Directives

  ],
  imports: [SharedModules],
  exports: [SharedModules, Directives]
})
export class SharedModule { }
