import { Component, input, signal } from '@angular/core';
// Import Dialog module for p-dialog
import { DialogModule } from 'primeng/dialog';

import { Student } from '../../models/student';

@Component({
  selector: 'app-details-student',
  imports: [DialogModule],
  templateUrl: './details-student.html',
  styleUrl: './details-student.css',
})
export class DetailsStudent {
  student = input<Student | null>(null);
  visible = signal(false);
}
