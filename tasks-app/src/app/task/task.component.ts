import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { LoaderService } from 'src/shared/loader.service';
import { User } from 'src/shared/models/user';
import { TasksService } from 'src/shared/tasks.service';
import { UsersService } from 'src/shared/users.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  public form?: FormGroup;
  public date?: any;
  public users$?: Observable<User[]>;
  @Input() reload$: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(
    private service: TasksService,
    private usersService: UsersService,
    private formBuilder: FormBuilder,
    private loader: LoaderService,
  ) {
    this.users$ = this.usersService.get();
    this.date = new Date().toISOString().slice(0, 10);
    this.form = this.formBuilder.group({
      'userId': this.formBuilder.control('', {
        validators: [Validators.required, Validators.maxLength(250), Validators.pattern('[0-9]*')]
      }),
      'subject': this.formBuilder.control('', {
        validators: [Validators.required, Validators.maxLength(250)]
      }),
      'targetDate': this.formBuilder.control('', {
        validators: [Validators.required]
      }),
      'isCompleted': this.formBuilder.control(false,),
    });
  }

  public switchChange(evt: any){
    this.form?.controls['isCompleted'].setValue(  evt.target.checked);
  }

  submit() {
    if (this.form?.valid) {
      this.loader.setLoading(true);
      this.service.create(this.form.getRawValue()).subscribe(res => {
        this.loader.setLoading(false);
        this.reload$.next(true);
      }, err => {
        window.alert(err.error);
        this.loader.setLoading(false);
      })
    } else {
      window.alert('Please fix form errors');
    }
  }
}
