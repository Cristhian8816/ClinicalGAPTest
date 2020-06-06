import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {PageNotFoundComponent} from './components/page-not-found/page-not-found.component';

import {PageNotFoundRoutingModule} from './pagenotfound-routing.module';
import {SharedModule} from '../shared/shared.module';

@NgModule({
    declarations: [
        PageNotFoundComponent
    ],
    imports: [
        CommonModule,
        PageNotFoundRoutingModule,
        SharedModule
    ]
  })

export class PageNotFoundModule {

}

