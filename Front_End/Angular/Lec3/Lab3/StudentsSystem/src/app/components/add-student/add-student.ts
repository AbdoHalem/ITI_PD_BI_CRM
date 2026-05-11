import { Component, output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
// 2. Path fixed: go up twice to reach the app level, then into models
import { Student } from '../../models/student';

@Component({
  selector: 'app-add-student',
  imports: [DialogModule, ButtonModule, InputTextModule, FormsModule],
  templateUrl: './add-student.html',
  styleUrl: './add-student.css',
})
export class AddStudent {
  visible = signal(false);
  newStudent: Partial<Student> = { name: '', age: 0 };
  
  // Using the modern output() function
  onAdd = output<Student>();

  save() {
    // Emit the event with a dummy ID (0), the parent component will calculate and assign the correct ID
    this.onAdd.emit({ ...this.newStudent, id: 0 } as Student);
    this.visible.set(false);
    this.newStudent = { name: '', age: 0 }; // Reset
  }
}
