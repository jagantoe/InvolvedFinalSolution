import { Component, inject, input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ApiService } from '../../services/api.service';
import { ToDo } from '../../types/todo';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatProgressSpinnerModule, MatButtonModule, RouterLink],
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent implements OnInit {
  // Declare id input that is passed by route parameter
  id = input.required<number>();

  // Inject our dependencies
  apiService = inject(ApiService);
  snackBar = inject(MatSnackBar);

  // The item we fetch from the api
  item: ToDo | null = null;

  // When the page is loaded we want to fetch the item using the given id
  async ngOnInit() {
    try {
      this.item = await firstValueFrom(this.apiService.get(this.id()));
    } catch (error) {
      // Inform the user that the item does not exist
      this.snackBar.open("Item not found!");
    }
  }

  // Function to save our existing item
  async save() {
    // Make the api call and await the response
    await firstValueFrom(this.apiService.update(this.item!));
    // Inform the user that the item was saved
    this.snackBar.open("Item saved!", "close", { duration: 3000 });
  }
}
