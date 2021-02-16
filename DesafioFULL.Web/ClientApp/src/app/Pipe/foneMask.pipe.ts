import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'foneMask'
})
export class FoneMaskPipe implements PipeTransform {
  transform(value: string, ...args: any[]): any {

    if (value == null) {
      return '';
    }
      
    if (value.length == 11) {
      return value.replace(/(\d{2})(\d{9})/g, '\($1)\ $2');
      //return value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, '\$1.\$2.\$3\-\$4');
    }
    return '';
  }
}
