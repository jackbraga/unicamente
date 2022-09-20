import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'ChacronaSearchPipe', pure: false })
export class ChacronaSearchPipe implements PipeTransform {
  transform(value, args?): Array<any> {
    let searchText = new RegExp(args, 'ig');
    if (value) {
      return value.filter(chacrona => {
        if (chacrona.descricao) {
          return chacrona.descricao.search(searchText) !== -1;
        }
        else{
          return chacrona.descricao.search(searchText) !== -1;
        }
      });
    }
  }
}
