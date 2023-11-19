import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenTasksComponent } from './open-tasks.component';

describe('OpenTasksComponent', () => {
  let component: OpenTasksComponent;
  let fixture: ComponentFixture<OpenTasksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OpenTasksComponent]
    });
    fixture = TestBed.createComponent(OpenTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
