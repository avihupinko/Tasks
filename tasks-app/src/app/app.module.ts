import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule, NgbPaginationModule, NgbToastModule, NgbTooltipModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { TableComponent } from './table/table.component';

import { TaskComponent } from './task/task.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TruncatePipe } from 'src/shared/pipes/truncate.pipe';
import { SpinnerComponent } from './spinner/spinner.component';
import { DatePipe } from '@angular/common';
import { TaskCardComponent } from './task-card/task-card.component';
import { OpenTasksComponent } from './open-tasks/open-tasks.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    TaskCardComponent,
    TaskComponent,
    TruncatePipe,
    SpinnerComponent,
    OpenTasksComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    NgbTypeaheadModule,
    NgbPaginationModule,
    NgbTooltipModule,
    ReactiveFormsModule,
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
