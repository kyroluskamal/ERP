import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { AnimateOnScrollDirective } from 'src/Directives/animate-on-scroll.directive';
import { BidiModule } from '@angular/cdk/bidi';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
const SharedModules = [
  ReactiveFormsModule,
  HttpClientModule, BidiModule, NgbModule,
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
