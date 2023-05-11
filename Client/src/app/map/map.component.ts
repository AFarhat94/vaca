import { Component, ViewChild } from '@angular/core';

import { MapInfoWindow, MapMarker } from '@angular/google-maps';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent {
  markerPositions : google.maps.LatLngLiteral[] = [];

  @ViewChild(MapInfoWindow) infoWindow?: MapInfoWindow;

  mapOptions: google.maps.MapOptions= {
    center: { lat: 33.8736, lng: 35.8637 },
    zoom: 5,
    disableDefaultUI: true
  }

  onMapClick(event: google.maps.MapMouseEvent)
  {
    if (event.latLng !=null)
    {
      this.markerPositions.push(event.latLng.toJSON());
    }
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
