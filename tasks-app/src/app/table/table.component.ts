import { Component, EventEmitter, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from 'src/shared/models/user';
import { TableService } from './table.service';
import { Router } from '@angular/router';
import { UsersService } from 'src/shared/users.service';
import { LoaderService } from 'src/shared/loader.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  public data$: Observable<Task[]>;
  public reload$: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(public service: TableService,
    private router: Router) {
    this.data$ = service.data$;
    this.reload$.subscribe(res=>{
      this.service.refresh();
    })
  }
  ngOnInit(): void {
    this.service.refresh();
  }

  public create() {
    this.router.navigate(['create'])
  }

}
