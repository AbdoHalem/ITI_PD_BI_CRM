import { Injectable, signal } from '@angular/core';
import { IStudent } from '../models/IStudent';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private students =  signal<IStudent[]>(
    [
      { id: 1, name: 'Alice', age: 20 },
      { id: 2, name: 'Bob', age: 22 },
      { id: 3, name: 'Charlie', age: 21 },
    ]
  );
  // ================ Service Methods ================
  // Return the signal for components to read
  GetAllStudents() {
    return this.students.asReadonly();
  }
  // Find a specific student by ID
  GetStudentById(id: number): IStudent | undefined {
    return this.students().find(student => student.id === id);
  }

  // Add a new student and calculate the next ID
  AddStudent(data: { name: string, age: number}): void {
    this.students.update(list => {
      const maxId = list.length > 0 ? Math.max(...list.map(s => s.id)) + 1 : 1;
      // CRITICAL FIX: Spread the 'data' FIRST, then explicitly set 'id' to override any dummy value
      return [...list, { ...data, id: maxId }];
    });
  }

  // Update an existing student's data
  UpdateStudent(updatedStudent: IStudent): void {
    this.students.update(list => 
      list.map(s => s.id === updatedStudent.id ? updatedStudent : s)
    );
  }

  // Delete a student from the list
  DeleteStudent(id: number): void {
    this.students.update(list => list.filter(student => student.id !== id));
  }
}
