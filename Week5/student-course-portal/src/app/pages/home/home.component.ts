import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy {
  portalName = 'Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';
  totalCourses = 0;

  constructor(
    private courseService: CourseService,
    private router: Router
  ) {}

  ngOnInit() {
    this.courseService.getCourses().subscribe({
      next: (courses) => {
        this.totalCourses = courses.length;
        console.log('HomeComponent initialised — courses loaded from API');
      },
      error: (err) => console.error('Failed to load courses', err)
    });
  }

  onSearch() {
    if (this.searchTerm) {
      this.router.navigate(['/courses'], { queryParams: { search: this.searchTerm } });
    }
  }

  ngOnDestroy() {
    console.log('HomeComponent destroyed');
  }

  onEnrollClick() {
    this.message = 'Enrollment opened!';
  }
}
