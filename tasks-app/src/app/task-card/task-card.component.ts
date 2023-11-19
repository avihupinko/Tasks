import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Task } from 'src/shared/models/user';
import { UsersService } from 'src/shared/users.service';

@Component({
  selector: 'task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent {

  @Input() task?: Task;

  constructor(
    private service: UsersService,
    private router: Router,
  ) {
  }


}
