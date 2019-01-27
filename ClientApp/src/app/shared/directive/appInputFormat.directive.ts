import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { format } from 'util';

@Directive({
  selector: '[appInputFormat]'
})
export class InputFormatDirective {
  value: string;
  @Input('appInputFormat') format;
  constructor(private el: ElementRef) { }

  @HostListener('blur') onblur() {
    const value: string = this.el.nativeElement.value;

    if (this.format === 'lowercase') {
      this.el.nativeElement.value = value.toLowerCase();
    } else {
      this.el.nativeElement.value = value.toUpperCase();
    }
  }

}
