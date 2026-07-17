import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [],
  // Component-level providers create a new service instance for this component and its children.
  // This is useful when you need isolated state per component instance, such as a form wizard
  // where each step needs its own separate service state, rather than sharing globally.
  providers: [NotificationService],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css'
})
export class NotificationComponent {
  constructor(private notificationService: NotificationService) {}
}
