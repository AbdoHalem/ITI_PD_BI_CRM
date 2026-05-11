import { Component, signal, ViewChild } from '@angular/core';
import { Student} from './models/student';

// PrimeNG Modules
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
// Child Components
import { AddStudent } from './components/add-student/add-student';
import { DeleteStudent } from './components/delete-student/delete-student';
import { DetailsStudent } from './components/details-student/details-student';
import { EditStudent } from './components/edit-student/edit-student';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [AddStudent, CommonModule, TableModule,
    ButtonModule, DeleteStudent, DetailsStudent, EditStudent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // 1. The main students array as a signal;
  students = signal<Student[]>([
    { id: 1, name: 'Ali', age: 25 },
    { id: 2, name: 'Omar', age: 32 },
    { id: 3, name: 'Sara', age: 22 }
  ]);

  // 2. Signal to hold the currently selected student for details or edit
  selectedStudent = signal<Student | null>(null);

  // 3. ViewChild allows us to control the child components (like opening their dialogs)
  @ViewChild('detailsChild') detailsChild!: DetailsStudent;
  @ViewChild('editChild') editChild!: EditStudent;

  // Function to add a new student
  addStudent(data: { name: string, age: number }) {
    this.students.update(list => {
      const maxId = list.length > 0 ? Math.max(...list.map(s => s.id)) + 1 : 1;
      // CRITICAL FIX: Spread the 'data' FIRST, then explicitly set 'id' to override any dummy value
      return [...list, { ...data, id: maxId }];
    });
  }

  // Function to update an existing student
  updateStudent(updated: Student) {
    this.students.update(list => 
      list.map(s => s.id === updated.id ? updated : s)
    );
  }

  // Function to delete a student
  removeStudent(id: number){
    this.students.update(list => list.filter(s => s.id !== id));
  }

  // Function to show student details
  showDetails(student: Student){
    this.selectedStudent.set(student);
    this.detailsChild.visible.set(true); // Open the details dialog
  }

  // Function to start editing (You can implement the edit dialog logic similarly later)
  startEdit(student: Student){
    this.selectedStudent.set(student);
    this.editChild.visible.set(true); // Open the edit dialog
  }

}
