import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ToDo } from '../types/todo';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  // Inject the HttpClient so we can make API calls
  httpClient = inject(HttpClient);
  // The base url
  baseUrl = "http://localhost:5136/api/ToDo";

  getAll() {
    return this.httpClient.get<ToDo[]>(`${this.baseUrl}/GetAll`);
  }
  get(id: number) {
    return this.httpClient.get<ToDo>(`${this.baseUrl}/Get/${id}`);
  }
  search(title: string, assignee: string) {
    return this.httpClient.get<ToDo[]>(`${this.baseUrl}/Search?title:${title}&assignee=${assignee}`);
  }

  add(todo: ToDo) {
    return this.httpClient.post<number>(`${this.baseUrl}/Add`, todo);
  }
  update(todo: ToDo) {
    return this.httpClient.put<void>(`${this.baseUrl}/Update`, todo);
  }
  delete(id: number) {
    return this.httpClient.delete<void>(`${this.baseUrl}/Delete/${id}`);
  }
}
