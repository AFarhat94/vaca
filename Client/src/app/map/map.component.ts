import { Component } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent {
  markerPositions : google.maps.LatLngLiteral[] = [];

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
}
