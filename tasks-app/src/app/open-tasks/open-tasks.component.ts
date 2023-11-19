import { Component } from '@angular/core';
import { LoaderService } from 'src/shared/loader.service';
import { OpenTasks } from 'src/shared/models/user';
import { TasksService } from 'src/shared/tasks.service';

@Component({
  selector: 'app-open-tasks',
  templateUrl: './open-tasks.component.html',
  styleUrls: ['./open-tasks.component.css']
})
export class OpenTasksComponent {
  public openTasks: OpenTasks[] = [];

  constructor(
    private service: TasksService,
    private loader: LoaderService,
  ) {
    this.initData();
    this.loader.loading$.subscribe(loading=>{
      if(!!loading){
        this.initData();
      }
    })
  }

  initData(){
    this.service.openTasks().subscribe(res=>{
      this.openTasks = res;
    })
  }
}
