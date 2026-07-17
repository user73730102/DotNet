import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CourseService } from '../../services/course.service';
import { Course } from '../../models/course.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <ng-container *ngIf="course$ | async as course; else loading">
      <div style="padding: 20px;">
        <h2>{{ course.name }} Details</h2>
        <p><strong>Code:</strong> {{ course.code }}</p>
        <p><strong>Credits:</strong> {{ course.credits }}</p>
        <p><strong>Status:</strong> {{ course.gradeStatus }}</p>
        <button routerLink="/courses">Back to Courses</button>
      </div>
    </ng-container>
    <ng-template #loading>
      <p>Loading course details...</p>
    </ng-template>
  `,
  styleUrl: './course-detail.component.css'
})
export class CourseDetailComponent implements OnInit {
  course$!: Observable<Course>;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        this.course$ = this.courseService.getCourseById(+idParam);
      }
    });
  }
}
