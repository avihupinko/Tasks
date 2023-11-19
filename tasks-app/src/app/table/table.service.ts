import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject, debounceTime, delay, switchMap, tap } from "rxjs";
import { LoaderService } from "src/shared/loader.service";
import { Task, User } from "src/shared/models/user";
import { TasksService } from "src/shared/tasks.service";
import { UsersService } from "src/shared/users.service";

interface State {
    page: number;
    pageSize: number;
    userId: string;
    userName: string;
    phone: string;
}


@Injectable({
    providedIn: 'root',
})
export class TableService {

    private _search$ = new Subject<void>();
    private _data$ = new BehaviorSubject<Task[]>([]);

    constructor(private service: TasksService,
        private loader: LoaderService) {
        this._search$
            .pipe(
                tap(() => this.loader.setLoading(true)),
                debounceTime(200),
                switchMap(() => this._search()),
                delay(200),
            )
            .subscribe((result) => {
                this._data$.next(result);
                this.loader.setLoading(false)
            });

        this._search$.next();
    }

    get data$() {
        return this._data$.asObservable();
    }

    private _set(patch: Partial<State>) {
        Object.assign(patch);
        this._search$.next();
    }

    public refresh(){
        this._search$.next();
    }

    private _search(): Observable<Task[]> {
        return this.service.get();
    }
}