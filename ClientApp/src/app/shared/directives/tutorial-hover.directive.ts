import { Directive, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[appTutorialHover]'
})
export class TutorialHoverDirective {

  @HostBinding('class.hovered') isHovered = false;

  constructor() { }

  @HostListener('mouseenter') onMouseEnter() {
    this.isHovered = true;
  }
  @HostListener('mouseleave') onmouseleave() {
    this.isHovered = false;
  }
}
