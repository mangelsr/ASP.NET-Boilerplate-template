import { Component, OnInit, Injector } from '@angular/core';

import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { PersonListDto, PersonServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { CreatePersonDialogComponent } from './create-person-dialog/create-person-dialog.component';
import { PermissionCheckerService } from 'abp-ng2-module/dist/src/auth/permission-checker.service';
import * as _ from 'lodash';
import { EditPersonDialogComponent } from './edit-person-dialog/edit-person-dialog.component';

@Component({
    // selector: 'app-phonebook',
    templateUrl: './phonebook.component.html',
    animations: [appModuleAnimation()],
})
export class PhonebookComponent extends AppComponentBase implements OnInit {
    
    people: PersonListDto[] = [];
    filter: string = '';
    
    constructor(
        injector: Injector,
        private _dialog: MatDialog,
        private _personService: PersonServiceProxy,
        public _permissionChecker: PermissionCheckerService,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getPeople();
    }

    getPeople(): void {
        this._personService.getPeople(this.filter).subscribe((result) => {
            this.people = result.items;
        })
    }

    createPerson(): void {
        this.showCreateOrEditPersonDialog();
    }

    editPerson(person: PersonListDto): void {
        this.showCreateOrEditPersonDialog(person);
    }

    deletePerson(person: PersonListDto) {
        this.message.confirm(
            this.l('AreYouSureToDeleteThePerson', person.name),
            this.l('Confirmation'),
            (isConfirmed: boolean) => {
                if (isConfirmed) {
                    this._personService.deletePerson(person.id).subscribe(
                        () => {
                            this.notify.info(this.l('SuccessfullyDeleted'));
                            _.remove(this.people, person);
                        }
                    );
                }
            }
        );
    }

    private showCreateOrEditPersonDialog(person?: PersonListDto): void {
        let createOrEditUserDialog;
        if (person === undefined) {
            createOrEditUserDialog = this._dialog.open(CreatePersonDialogComponent);
        } else {
            createOrEditUserDialog = this._dialog.open(EditPersonDialogComponent, {
                data: person
            });
        }

        createOrEditUserDialog.afterClosed().subscribe(result => {
            if (result) {
                this.getPeople();
            }
        });
    }
}
