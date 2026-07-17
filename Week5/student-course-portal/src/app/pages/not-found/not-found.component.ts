import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterModule],
  template: `
    <div style="text-align: center; margin-top: 50px;">
      <h2>404 - Page Not Found</h2>
      <p>The page you are looking for does not exist.</p>
      <a routerLink="/">Go Back Home</a>
    </div>
  `
})
export class NotFoundComponent { }
