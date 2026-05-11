import { Component, input, output, signal, effect } from '@angular/core';
// Import the required PrimeNG modules
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { Student } from '../../models/student';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-edit-student',
  imports: [ButtonModule, DialogModule, InputTextModule, FormsModule],
  templateUrl: './edit-student.html',
  styleUrl: './edit-student.css',
})
export class EditStudent {
  student = input<Student | null>(null);
  visible = signal(false);
  onUpdate = output<Student>();

  editForm = signal<Student>({id: 0, name: '', age: 0});

  constructor() {
    effect(() => {
      const s = this.student();
      if(s){
        this.editForm.set({...s});
      }
    });
  }

  update() {
    this.onUpdate.emit(this.editForm());
    this.visible.set(false);
  }
}
