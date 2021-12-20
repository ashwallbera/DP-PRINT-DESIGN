import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopNowDialogComponent } from './shop-now-dialog.component';

describe('ShopNowDialogComponent', () => {
  let component: ShopNowDialogComponent;
  let fixture: ComponentFixture<ShopNowDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopNowDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShopNowDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
