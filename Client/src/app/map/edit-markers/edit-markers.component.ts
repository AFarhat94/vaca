import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MapComponent } from '../map.component';
import { MapService } from '../map.service';

@Component({
  selector: 'app-edit-markers',
  templateUrl: './edit-markers.component.html',
  styleUrls: ['./edit-markers.component.scss']
})
export class EditMarkersComponent {
  form = new FormGroup({
    title: new FormControl(),
    description: new FormControl(),
    coordinations: new FormGroup({
      latitude: new FormControl(MapComponent.lat),
      longitude: new FormControl(MapComponent.lng)
    })
  });

  constructor(private mapService: MapService) { }

  onSubmit()
  {
    console.log(this.form.value);
    this.mapService.save(this.form.value).subscribe({
      next: reponse => console.log(reponse),
      error: error => console.log(error)
    });
    MapComponent.formRef.hide();
  }

}
