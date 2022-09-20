import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { NgxPaginationModule } from 'ngx-pagination';
import { PipesModule } from '../../../theme/pipes/pipes.module';
import { CadastroVegetalComponent } from './cadastro-vegetal.component';

import { NgModule } from '@angular/core';
import { DirectivesModule } from 'src/app/theme/directives/directives.module';
import { FormElementsModule } from '../../form-elements/form-elements.module';
import { ImageUploaderComponent } from '../../form-elements/controls/image-uploader/image-uploader.component';

export const routes: Routes = [
  { path: '', component: CadastroVegetalComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    // InMemoryWebApiModule.forRoot(CadastroVegetalData, { delay: 0 }),
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    MultiselectDropdownModule,
    NgxPaginationModule,
    PipesModule,
    DirectivesModule,
    FormElementsModule,

    RouterModule.forChild(routes)


  ],
  declarations: [
    CadastroVegetalComponent

  ]
})
export class CadastroVegetalModule { }
