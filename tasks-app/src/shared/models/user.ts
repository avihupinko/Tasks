export interface User {
    id : string; 
    name : string; 
}

export interface Task {
    id : string; 
    subject : string; 
    user?: User;
    targetDate: Date;
    isCompleted: boolean;
}

export interface OpenTasks{
    name: string;
    count: number;
}
