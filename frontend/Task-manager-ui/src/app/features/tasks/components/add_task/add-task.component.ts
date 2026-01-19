import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { TaskService } from '../../../../core/services/task.service';
import { Task } from '../../../../core/models/task.model';

@Component({
  selector: 'app-add-task',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-task.component.html'
})
export class AddTaskComponent {

  title = '';
  date = '';
  hour = '01';
  minute = '00';
  ampm: 'AM' | 'PM' = 'AM';

  reminderEnabled = false;
  submitting = false;

  minDate = new Date().toISOString().split('T')[0];

  hours = Array.from({ length: 12 }, (_, i) =>
    (i + 1).toString().padStart(2, '0')
  );

  minutes = Array.from({ length: 60 }, (_, i) =>
    i.toString().padStart(2, '0')
  );

  @Output() taskAdded = new EventEmitter<Task>();

  constructor(private taskService: TaskService) {}

  addTask(event: Event): void {
    event.preventDefault();

    if (!this.title || !this.date || this.submitting) return;

    let h = parseInt(this.hour, 10);
    const m = parseInt(this.minute, 10);

    // Convert to 24-hour
    if (this.ampm === 'PM' && h < 12) h += 12;
    if (this.ampm === 'AM' && h === 12) h = 0;

    const dueDate = new Date(this.date);
    dueDate.setHours(h, m, 0, 0);

    // Prevent past date
    if (dueDate < new Date()) {
      alert('Due date cannot be in the past');
      return;
    }

    this.submitting = true;

    this.taskService.createTask({
      title: this.title.trim(),
      dueDate: dueDate.toISOString(),
      reminderEnabled: this.reminderEnabled
    })
    .pipe(finalize(() => this.submitting = false))
    .subscribe({
      next: (task) => {
        this.title = '';
        this.date = '';
        this.hour = '01';
        this.minute = '00';
        this.ampm = 'AM';
        this.reminderEnabled = false;

        this.taskAdded.emit(task);
      }
    });
  }
}
