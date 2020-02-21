import { Component, OnInit, Injector, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import * as _ from 'lodash';
import { finalize } from 'rxjs/operators';

import { AppComponentBase } from '@shared/app-component-base';
import { PersonServiceProxy, PersonListDto, PhoneType, AddPhoneInput, PhoneInPersonListDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-person-dialog',
  templateUrl: './edit-person-dialog.component.html',
})
export class EditPersonDialogComponent extends AppComponentBase implements OnInit {

  saving = false;
  newPhone: AddPhoneInput = new AddPhoneInput();
  
  constructor(
    injector: Injector,
    private _personService: PersonServiceProxy,
    private _dialogRef: MatDialogRef<EditPersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public person: PersonListDto,
  ) {
    super(injector);
  }

  values(): any[] {
    var values = Object.values(PhoneType);
    return values.slice(values.length / 2);
}

  getPhoneTypeAsString(phoneType: PhoneType): string {
    switch(phoneType) {
      case PhoneType._0:
          return this.l('PhoneType_Mobile');
        case PhoneType._1:
          return this.l('PhoneType_Home');
        case PhoneType._2:
          return this.l('PhoneType_Business');
        default:
          return '?';
    }
  }

  savePhone(): void {
    if (!this.newPhone.number || !this.newPhone.type) {
      this.message.warn('Please enter a number or select a type!');
      return;
    }
    this._personService.addPhone(this.newPhone).subscribe(
      result => {
        this.person.phones.push(result);
        this.newPhone.number = '';
        this.newPhone.type = undefined;
        this.notify.success(this.l('SavedSuccessfully'));
      }
    );
  }

  deletePhone(phone: PhoneInPersonListDto): void {
    this._personService.deletePhone(phone.id).subscribe(
      (result) => {
        this.notify.info(this.l('SuccessfullyDeleted'));
        _.remove(this.person.phones, phone);
      }
    )
  }

  editPerson() {
    this.saving = true;

    this._personService
      .editPerson(this.person)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SuccessfullyEdited'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }

  ngOnInit() {
    this.newPhone.personId = this.person.id;
  }

}
