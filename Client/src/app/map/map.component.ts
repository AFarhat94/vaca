import { Component, OnInit, ViewChild } from '@angular/core';

import { MapInfoWindow, MapMarker } from '@angular/google-maps';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EditMarkersComponent } from './edit-markers/edit-markers.component';
import { MapService } from './map.service';
import { Marker } from '../shared/models/Marker';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  markerPositions : Marker[] = [];
  static lat?: number;
  static lng?: number;
  static formRef: BsModalRef;

  @ViewChild(MapInfoWindow) infoWindow?: MapInfoWindow;

  mapOptions: google.maps.MapOptions= {
    center: { lat: 33.8736, lng: 35.8637 },
    zoom: 5,
    disableDefaultUI: true
  }

  constructor(private mapService: MapService,
      private bsModalService: BsModalService) { }


  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token)
    {
      this.mapService.getAllByUser().subscribe({
        next: markers => 
        { 
          markers.map(marker => {
            this.markerPositions.push({
              title: marker.title,
              description: marker.description,
              coordinations: {
                lat: marker.coordinations.lat, 
                lng: marker.coordinations.lng
              }
            });
          });
        },
        error: error => console.log(error)
      });
    }
  }

  onMapClick(event: google.maps.MapMouseEvent)
  {
    MapComponent.lat = event.latLng?.toJSON().lat;
    MapComponent.lng = event.latLng?.toJSON().lng;
    MapComponent.formRef = this.bsModalService.show(EditMarkersComponent);
    // if (event.latLng !=null)
    // {
    //   this.markerPositions.push(event.latLng.toJSON());
    // }
  }

  openMakerInfoWindow(marker: MapMarker)
  {
    this.infoWindow?.open(marker);
  }

  closeMarkerInfoWindow()
  {
    this.infoWindow?.close();
  }
}
