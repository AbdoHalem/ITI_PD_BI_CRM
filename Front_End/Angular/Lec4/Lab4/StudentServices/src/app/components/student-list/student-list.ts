import { Component, inject, Signal, signal, WritableSignal } from '@angular/core';
import { StudentService } from '../../services/student-service';
import { IStudent } from '../../models/IStudent';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

// PrimeNG Modules
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-student-list',
  imports: [CommonModule, RouterLink, TableModule, ButtonModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.css',
})
export class StudentList {
  // Injecting our data service
  private readonly studentService = inject(StudentService);
  students: Signal<IStudent[]> = this.studentService.GetAllStudents();

  ngOnInit(): void {
    // Initial logic if needed when component starts
    this.LogStatus();
  }

  // Function to log status (starts with Capital letter)
  LogStatus(): void {
    console.log('Student list component initialized successfully.');
  }
}
