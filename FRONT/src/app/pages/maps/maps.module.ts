import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AgmCoreModule } from '@agm/core';
import { GoogleMapsComponent } from './google-maps/google-maps.component';
import { LeafletMapsComponent } from './leaflet-maps/leaflet-maps.component';

export const routes: Routes = [
  { path: '', redirectTo: 'googlemaps', pathMatch: 'full'},
  { path: 'googlemaps', component: GoogleMapsComponent, data: { breadcrumb: 'Google Maps' } },
  { path: 'leafletmaps', component: LeafletMapsComponent, data: { breadcrumb: 'Leaflet Maps' } }
];

@NgModule({
  imports: [
    CommonModule,
    AgmCoreModule,
    RouterModule.forChild(routes)
  ],
  declarations: [ 
    GoogleMapsComponent, 
    LeafletMapsComponent 
  ]
})
export class MapsModule { }
