import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../services/student-service';
import { IStudent } from '../../models/IStudent';

// PrimeNG Modules
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-student-edit',
  imports: [FormsModule, ButtonModule, InputTextModule],
  templateUrl: './student-edit.html',
  styleUrl: './student-edit.css',
})
export class StudentEdit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private studentService = inject(StudentService);

  // Variable to hold the form data
  editForm: IStudent = { id: 0, name: '', age: 0 };

  ngOnInit(): void {
    this.LoadStudentToEdit();
  }

  // Fetch student data using the ID from the URL
  LoadStudentToEdit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if(id){
      const existingStudent = this.studentService.GetStudentById(Number(id));
      if(existingStudent){
        this.editForm = { ...existingStudent };
      }
    }
  }

  // Save the updated data and redirect
  SaveUpdates(): void{
    this.studentService.UpdateStudent(this.editForm);
    this.router.navigate(['/students']);
  }

  // Cancel and go back to list
  GoBack(): void {
    this.router.navigate(['/students']);
  }

}
