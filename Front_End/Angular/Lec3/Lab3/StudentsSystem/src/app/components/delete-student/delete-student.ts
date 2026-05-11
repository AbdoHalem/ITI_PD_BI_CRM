import { Component, input, output } from '@angular/core';
// Import the Button module for p-button
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-delete-student',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './delete-student.html',
  styleUrl: './delete-student.css',
})
export class DeleteStudent {
  studentId = input.required<number>();
  onConfirm = output<number>();

  confirm(){
    if(confirm('Are you sure you want to delete this student?')){
      this.onConfirm.emit(this.studentId());
    }
  }
}
