import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuoteToolComponent } from './quote-tool.component';

describe('QuoteToolComponent', () => {
  let component: QuoteToolComponent;
  let fixture: ComponentFixture<QuoteToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuoteToolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuoteToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
