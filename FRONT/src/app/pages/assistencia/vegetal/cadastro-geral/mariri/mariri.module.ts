import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { NgxPaginationModule } from 'ngx-pagination';

import { NgModule } from '@angular/core';
import { DirectivesModule } from 'src/app/theme/directives/directives.module';
import { PipesModule } from 'src/app/theme/pipes/pipes.module';
import { FormElementsModule } from 'src/app/pages/form-elements/form-elements.module';
import { MaririComponent } from './mariri.component';

export const routes: Routes = [
  { path: '', component: MaririComponent, pathMatch: 'full' }
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
    MaririComponent

  ]
})
export class MaririModule { }
