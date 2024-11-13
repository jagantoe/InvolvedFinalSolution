import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { TodoComponent } from './components/todo/todo.component';
import { ApiService } from './services/api.service';
import { ToDo } from './types/todo';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TodoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'ToDo';
  apiService = inject(ApiService);

  items: ToDo[] = [];

  async ngOnInit() {
    this.items = await firstValueFrom(this.apiService.getAll());
  }
}
