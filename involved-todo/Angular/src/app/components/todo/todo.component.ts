import { Component, input, output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { ToDo } from '../../types/todo';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent {
  // Declare the input data for this component
  todo = input.required<ToDo>();

  // Declare output to notify parent component
  delete = output<number>();
}
