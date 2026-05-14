import { Component, inject } from '@angular/core';
import { IStudent } from '../../models/IStudent';
import { StudentService } from '../../services/student-service';
import { ActivatedRoute, Router } from '@angular/router';

// PrimeNG Modules
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-student-details',
  standalone: true,
  imports: [ButtonModule, CardModule],
  templateUrl: './student-details.html',
  styleUrl: './student-details.css',
})
export class StudentDetails {
  private readonly studentService = inject(StudentService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  // Variable to hold the fetched student data
  studentInfo: IStudent | undefined;

  // Angular lifecycle hook
  ngOnInit(): void {
    this.LoadStudentData();
  }

  // Extract ID from URL and fetch data from the service
  LoadStudentData(): void {
    // 1. Get the 'id' parameter from the active route
    const id = this.route.snapshot.paramMap.get('id');

    if(id){
      // 2. Convert to number and fetch from service
      const studentId = Number(id);
      this.studentInfo = this.studentService.GetStudentById(studentId);
    }
  }

  // Navigate back to the list
  GoBack(): void {
    this.router.navigate(['/students']);
  }
}
