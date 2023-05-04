import { Component } from '@angular/core';
import { Marker } from './shared/models/Marker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  markerPositions : google.maps.LatLngLiteral[] = [];

  mapOptions: google.maps.MapOptions = {
    center: { lat: 33.8736, lng: 35.8637 },
    zoom: 5,
    disableDefaultUI: true
  }

  onMapClick(event: google.maps.MapMouseEvent)
  {
    console.log(event.latLng?.toJSON());
    if (event.latLng !=null)
    {
      this.markerPositions.push(event.latLng.toJSON());
    }
  }

}
