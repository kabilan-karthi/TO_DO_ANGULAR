import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../../core/services/task.service';
import { Task } from '../../../core/models/task.model';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { AddTaskComponent } from '../components/add_task/add-task.component';

@Component({
  selector: 'app-tasks-page',
  standalone: true,
  imports: [CommonModule, DashboardComponent, AddTaskComponent],
  templateUrl: './tasks-page.component.html'
})
export class TasksPageComponent implements OnInit {

  tasks: Task[] = [];
  loading = true;
  error: string | null = null;

  activeFilter: 'All' | 'ToDo' | 'InProgress' | 'Done' = 'All';

  filterOptions: Array<'All' | 'ToDo' | 'InProgress' | 'Done'> = [
    'All', 'ToDo', 'InProgress', 'Done'
  ];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.loading = true;
    this.taskService.getTasks().subscribe({
      next: data => {
        this.tasks = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load tasks';
        this.loading = false;
      }
    });
  }

  // ✅ OPTIMISTIC STATUS UPDATE
  changeStatus(id: number, status: 'ToDo' | 'InProgress' | 'Done'): void {
    const task = this.tasks.find(t => t.id === id);
    if (!task) return;

    const oldStatus = task.status;
    task.status = status; // UI updates immediately

    this.taskService.updateStatus(id, status).subscribe({
      error: () => {
        task.status = oldStatus; // rollback on failure
        this.error = 'Failed to update task status';
      }
    });
  }

  // ✅ OPTIMISTIC DELETE
  deleteTask(id: number): void {
    if (!confirm('Are you sure?')) return;

    const backup = [...this.tasks];
    this.tasks = this.tasks.filter(t => t.id !== id);

    this.taskService.deleteTask(id).subscribe({
      error: () => {
        this.tasks = backup; // rollback
        this.error = 'Failed to delete task';
      }
    });
  }

 
  onTaskAdded(task: Task): void {
  this.tasks = [task, ...this.tasks];
}


  get filteredTasks(): Task[] {
    if (this.activeFilter === 'All') return this.tasks;
    return this.tasks.filter(t => t.status === this.activeFilter);
  }
}
