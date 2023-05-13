import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMarkersComponent } from './edit-markers.component';

describe('EditMarkersComponent', () => {
  let component: EditMarkersComponent;
  let fixture: ComponentFixture<EditMarkersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMarkersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditMarkersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
