import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from "src/environment";
import { OpenTasks, Task, User } from "./models/user";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root',
})
export class TasksService {
    private serverUrl: string;

    constructor(private httpClient: HttpClient) {
        this.serverUrl = environment.serverUrl;
    }

    public get(): Observable<Task[]> {
        return this.httpClient.get<Task[]>(`${this.serverUrl}/Tasks`);
    }

    public openTasks(): Observable<OpenTasks[]> {
        return this.httpClient.get<OpenTasks[]>(`${this.serverUrl}/Tasks/Open`);
    }

    public create(model: Task) {
        return this.httpClient.post<Task>(`${this.serverUrl}/Tasks`, model);
    }

    public changeStatus(model: Task) {
        return this.httpClient.put<Task>(`${this.serverUrl}/Tasks/changeStatus`, model);
    }

}