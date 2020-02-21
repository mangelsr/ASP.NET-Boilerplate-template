import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

import { finalize } from 'rxjs/operators';

import { AppComponentBase } from '@shared/app-component-base';
import { CreatePersonInput, PersonServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'createPersonModal',
  templateUrl: './create-person-dialog.component.html',
})
export class CreatePersonDialogComponent extends AppComponentBase {
  
  saving = false;
  person: CreatePersonInput = new CreatePersonInput();

  constructor(
    injector: Injector,
    private _personService: PersonServiceProxy,
    private _dialogRef: MatDialogRef<CreatePersonDialogComponent>
  ) {
    super(injector);
  }

  save(): void {
    this.saving = true;

    this._personService
      .createPerson(this.person)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }

}
