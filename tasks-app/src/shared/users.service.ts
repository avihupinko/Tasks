import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from "src/environment";
import { User } from "./models/user";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root',
})
export class UsersService {
    private serverUrl: string;
	
    constructor(private httpClient: HttpClient) {
        this.serverUrl = environment.serverUrl;
    }

    public get(): Observable<User[]> {
        return this.httpClient.get<User[]>(`${this.serverUrl}/Users`);
    }

    public create(model: User) {
        return this.httpClient.post<User>(`${this.serverUrl}/Users`, model);
    }

}