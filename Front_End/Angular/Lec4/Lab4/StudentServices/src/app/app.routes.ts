import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { About } from './components/about/about';
import { StudentList } from './components/student-list/student-list';
import { StudentDetails } from './components/student-details/student-details';
import { StudentAdd } from './components/student-add/student-add';
import { StudentEdit } from './components/student-edit/student-edit';
import { StudentDelete } from './components/student-delete/student-delete';

export const routes: Routes = [
    // Home and About routes
  { path: 'home', component: Home },
  { path: 'about', component: About },

  // Students main list
  { path: 'students', component: StudentList },

  // Add new student
  { path: 'students/add', component: StudentAdd },

  // Dynamic routes using ':id' parameter
  { path: 'students/details/:id', component: StudentDetails },
  { path: 'students/updates/:id', component: StudentEdit },
  { path: 'students/delete/:id', component: StudentDelete },

  // Default route redirects to home
  { path: '', redirectTo: '/home', pathMatch: 'full' },

  // Wildcard for 404 - you can add a specialized component later
  { path: '**', redirectTo: '/home' }
];
