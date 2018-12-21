import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HtmlAttributesComponent } from './html-attributes.component';

describe('HtmlAttributesComponent', () => {
  let component: HtmlAttributesComponent;
  let fixture: ComponentFixture<HtmlAttributesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HtmlAttributesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HtmlAttributesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
