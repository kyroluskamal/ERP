import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { CommonModule } from '@angular/common';

const SharedModules = [
  ReactiveFormsModule,
  HttpClientModule,
  CommonModule
];

@NgModule({
  declarations:[],
  imports: [SharedModules],
  exports: [SharedModules]
})
export class SharedModule { }
