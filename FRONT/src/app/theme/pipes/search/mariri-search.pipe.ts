import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'MaririSearchPipe', pure: false })
export class MaririSearchPipe implements PipeTransform {
  transform(value, args?): Array<any> {
    let searchText = new RegExp(args, 'ig');
    if (value) {
      return value.filter(mariri => {
        if (mariri.descricao) {
          return mariri.descricao.search(searchText) !== -1;
        }
        else{
          return mariri.descricao.search(searchText) !== -1;
        }
      });
    }
  }
}
