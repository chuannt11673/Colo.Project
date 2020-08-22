import { AuthService } from './../_core/services/auth.service';
import { UserService } from './../_services/user.service';
import { TranslateConfigService } from './../_core/services/translate-config.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-update-info',
  templateUrl: './update-info.page.html',
  styleUrls: ['./update-info.page.scss'],
})
export class UpdateInfoPage implements OnInit {

  form: FormGroup;
  constructor(private formBuilder: FormBuilder,
    public translateConfigService: TranslateConfigService,
    private userService: UserService,
    private authService: AuthService) { }

  ngOnInit() {

    this.form = this.formBuilder.group({
      name: new FormControl(),
      gender: new FormControl(),
      birthday: new FormControl(),
      phone: new FormControl()
    });

    let user = this.authService.getUserProfile();
    this.form.patchValue(user);
  }

  update() {
    let model = {
      ...this.form.value,
      gender: parseInt(this.form.get('gender').value)
    };

    this.userService.updateUserInfo(model).subscribe(_ => {
      this.authService.updateUserProfile(model);
    });
  }
}
