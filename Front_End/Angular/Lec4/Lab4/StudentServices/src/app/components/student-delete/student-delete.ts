import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../services/student-service';
import { IStudent } from '../../models/IStudent';

// PrimeNG Modules
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-student-delete',
  standalone: true,
  imports: [ButtonModule, CardModule],
  templateUrl: './student-delete.html',
  styleUrl: './student-delete.css',
})
export class StudentDelete {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private studentService = inject(StudentService);

  studentToDelete: IStudent | undefined;

  ngOnInit(){
    this.LoadStudentToDelete();
  }

  LoadStudentToDelete(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.studentToDelete = this.studentService.GetStudentById(Number(idParam));
    }
  }

  ConfirmDelete(): void {
    if(this.studentToDelete) {
      this.studentService.DeleteStudent(this.studentToDelete.id);
      this.router.navigate(['/students']);
    }
  }

  CancelDelete(): void {
    this.router.navigate(['/students']);
  }

}
