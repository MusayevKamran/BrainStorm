import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(values, args) {
    return values.filter(value => {
      return value.name.includes(args);
    });
  }

}
