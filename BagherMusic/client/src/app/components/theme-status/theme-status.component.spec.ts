import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemeStatusComponent } from './theme-status.component';

describe('ThemeStatusComponent', () => {
  let component: ThemeStatusComponent;
  let fixture: ComponentFixture<ThemeStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThemeStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThemeStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
