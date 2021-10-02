import { Directive, ElementRef, HostBinding, HostListener, Input, Renderer2 } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';

@Directive({
  selector: '[AnimateOnScroll]'
})
export class AnimateOnScrollDirective {

  @Input('animName') animationName = "";
  @HostBinding('class') class = "";

  constructor(public elementRef: ElementRef, public Constants: ConstantsService) { }

  @HostListener('window:scroll')
  onWindowScroll() {
    const rect = this.elementRef.nativeElement.getBoundingClientRect();
    if (
      rect.top >= 0 &&
      rect.top <= (window.innerHeight || this.elementRef.nativeElement.clientHeight)
    ) {
      this.class = `${this.getClassName(this.animationName)}`;
    } else {
      this.class = "";
    }

  }


  getClassName(animationName: string) {
    switch (animationName) {
      case this.Constants.FadeUp: return "animated fadeInUp";
      case this.Constants.BounceUp: return "animate__animated animate__bounce";
      default: return "";
    }
  }
}
