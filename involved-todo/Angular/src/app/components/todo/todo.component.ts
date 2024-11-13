import { Component, input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ToDo } from '../../types/todo';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent {
  todo = input.required<ToDo>();
}
