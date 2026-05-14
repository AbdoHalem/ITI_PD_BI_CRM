import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentService } from '../../services/student-service';

// PrimeNG Modules
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-student-add',
  standalone: true,
  imports: [FormsModule, ButtonModule, InputTextModule],
  templateUrl: './student-add.html',
  styleUrl: './student-add.css',
})
export class StudentAdd {
  private studentService = inject(StudentService);
  private router = inject(Router);

  // Temporary object to hold form data
  newStudent: { name: string, age: number } = { name: '', age: 0 };

  SaveStudent(): void{
    this.studentService.AddStudent(this.newStudent);
    this.router.navigate(['/students']);
  }

  // Cancel and go back
  GoBack(): void {
    this.router.navigate(['/students']);
  }
}
