import { Component, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from 'src/shared/loader.service';
import { Task } from 'src/shared/models/user';
import { TasksService } from 'src/shared/tasks.service';
import { UsersService } from 'src/shared/users.service';

@Component({
  selector: 'task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent {

  @Input() task?: Task;
  @Input() reload$: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(
    private service: TasksService,
    private router: Router,
    private loader: LoaderService,
  ) {
  }

  public switchChange(evt: any) {
    if (!!this.task) {
      this.task.isCompleted = evt.target.checked;
      this.loader.setLoading(true);
      this.service.changeStatus(this.task).subscribe(res => {
        this.loader.setLoading(false);
        this.reload$.next(true);
      }, err => {
        window.alert(err.error);
        this.loader.setLoading(false);
      })
    }
  }
}
