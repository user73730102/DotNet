import { createReducer, on } from '@ngrx/store';
import { loadCourses, loadCoursesSuccess, loadCoursesFailure } from './course.actions';
import { Course } from '../models/course.model';

export interface CourseState {
  courses: Course[];
  error: string | null;
  loading: boolean;
}

export const initialState: CourseState = {
  courses: [],
  error: null,
  loading: false
};

export const courseReducer = createReducer(
  initialState,
  on(loadCourses, state => ({ ...state, loading: true })),
  on(loadCoursesSuccess, (state, { courses }) => ({
    ...state,
    courses,
    loading: false,
    error: null
  })),
  on(loadCoursesFailure, (state, { error }) => ({
    ...state,
    error,
    loading: false
  }))
);
