import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task } from '../../../../core/models/task.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  @Input() tasks: Task[] = [];

  get total(): number {
    return this.tasks.length;
  }

  get todo(): number {
    return this.tasks.filter(t => t.status === 'ToDo').length;
  }

  get inProgress(): number {
    return this.tasks.filter(t => t.status === 'InProgress').length;
  }

  get done(): number {
    return this.tasks.filter(t => t.status === 'Done').length;
  }
}
