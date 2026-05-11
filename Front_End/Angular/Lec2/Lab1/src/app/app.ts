import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Student } from './models/student';

// Material Imports
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

// Bootstrap Imports
import { NgbTooltipModule, NgbAlertModule, } from '@ng-bootstrap/ng-bootstrap';

// PrimeNG Imports
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule,
    MatToolbarModule, MatIconModule, NgbTooltipModule,
    ButtonModule, DialogModule, TableModule,
    InputTextModule, InputNumberModule, NgbAlertModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // Array to hold our student data
  students: Student[] = [
    { id: 1, name: 'Ali', age: 25 },
    { id: 2, name: 'Omar', age: 32 }, // This will be red!
    { id: 3, name: 'Sara', age: 22 }
  ];

  // Variables for Dialog and Form state
  displayDialog: boolean = false;
  studentForm: Student = { id: 0, name: '', age: 0 };
  isEditMode: boolean = false;

  // Variables for Alert
  alertMessage: string = '';
  showAlert: boolean = false;

  // Open Dialog to Add a new student
  openAddDialog(){
    this.isEditMode = false;
    // Generate a new ID based on the array length
    const newId = this.students.length > 0 ? Math.max(...this.students.map(s => s.id)) + 1 : 1;
    this.studentForm = { id: newId, name: '', age: 0 };
    this.displayDialog = true;
  }
  
  // Open Dialog to Edit an existing student
  openEditDialog(student: Student){
    this.isEditMode = true;
    // Create a copy of the object so we don't modify the table directly before saving
    this.studentForm = { ...student };
    this.displayDialog = true;
  }

  // Save (Add or Update)
  saveStudent(){
    if(this.isEditMode){
      // Find the index and update the student
      const index = this.students.findIndex(s => s.id === this.studentForm.id);
      if(index !== -1){
        this.students[index] = { ...this.studentForm };
        this.displayAlert('Student updated successfully!');
      }
    }
    else{
      // Add new student to the array
      this.students.push({ ...this.studentForm });
      this.displayAlert('Student added successfully!');
    }
    this.displayDialog = false;
  }

  // Delete student
  deleteStudent(id: number){
    this.students = this.students.filter(s => s.id !== id);
    this.displayAlert('Student deleted successfully!');
  }

  // Helper method to show Bootstrap alert for 3 seconds
  displayAlert(msg: string){
    this.alertMessage = msg;
    this.showAlert = true;
    setTimeout(() => {
      this.showAlert = false;
    }, 3000);
  }
}
