import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { DatingPage } from './dating.page';

describe('DatingPage', () => {
  let component: DatingPage;
  let fixture: ComponentFixture<DatingPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatingPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(DatingPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
