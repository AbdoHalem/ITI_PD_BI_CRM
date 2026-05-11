import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Comp1 } from './components/test/comp1/comp1';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Comp1],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('test-app');
}
