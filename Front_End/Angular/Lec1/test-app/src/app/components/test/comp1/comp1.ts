import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-comp1',
  imports: [],
  templateUrl: './comp1.html',
  styleUrl: './comp1.css',
})
export class Comp1 {
  target = signal('Halem comp1');
}
