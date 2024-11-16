import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ApiService } from '../../services/api.service';
import { ToDo } from '../../types/todo';

@Component({
  selector: 'app-new',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './new.component.html',
  styleUrl: './new.component.scss'
})
export class NewComponent {
  // Inject our dependencies
  apiService = inject(ApiService);
  snackBar = inject(MatSnackBar);
  router = inject(Router);

  // Set up an object with the default values
  item: ToDo = {
    id: 0,
    title: "",
    assignee: "",
    description: ""
  }

  // Function to save our new item
  async save() {
    // Make the api call and await the response
    await firstValueFrom(this.apiService.add(this.item));
    // Inform the user that the item was added
    this.snackBar.open("Item added!", "close", { duration: 3000 });
    // Navigate back to the overview to see our new item
    this.router.navigate(["/"]);
  }
}
