import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemBrandsComponent } from './item-brands.component';

describe('ItemBrandsComponent', () => {
  let component: ItemBrandsComponent;
  let fixture: ComponentFixture<ItemBrandsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemBrandsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemBrandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
