export type TaskStatus = 'ToDo' | 'InProgress' | 'Done';

export interface Task {
  id: number;
  title: string;
  dueDate: string;
  status: TaskStatus;
  reminderEnabled: boolean;
}
