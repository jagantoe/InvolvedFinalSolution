import { Component, inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { firstValueFrom } from 'rxjs';
import { TodoComponent } from "../../components/todo/todo.component";
import { ApiService } from '../../services/api.service';
import { ToDo } from '../../types/todo';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [TodoComponent],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent {
  // Inject our dependencies
  apiService = inject(ApiService);
  snackBar = inject(MatSnackBar);

  // The array of items we fetch from the api
  items: ToDo[] = [];

  // We want to fetch all the items on page load
  async ngOnInit() {
    await this.loadItems();
  }

  // Function for fetching all the items
  async loadItems() {
    this.items = await firstValueFrom(this.apiService.getAll());
  }

  // Function to delete the item
  async deleteTodo(id: number) {
    // Make the api call
    await firstValueFrom(this.apiService.delete(id));
    // Inform the user that the item was deleted
    this.snackBar.open("Item deleted!", "close", { duration: 1000 });
    // Refetch all the items because we deleted one
    await this.loadItems();
  }
}
