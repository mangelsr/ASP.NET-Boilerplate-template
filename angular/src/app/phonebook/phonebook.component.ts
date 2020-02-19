import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    // selector: 'app-phonebook',
    templateUrl: './phonebook.component.html',
    animations: [appModuleAnimation()],
})
export class PhonebookComponent extends AppComponentBase implements OnInit {
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    ngOnInit(): void { }
}
