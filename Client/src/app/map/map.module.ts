import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from './map.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { EditMarkersComponent } from './edit-markers/edit-markers.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@microsoft/signalr';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    MapComponent,
    EditMarkersComponent
  ],
  imports: [
    CommonModule,
    GoogleMapsModule,
    ReactiveFormsModule
  ],
  exports: [
    MapComponent
  ]
})
export class MapModule { }
