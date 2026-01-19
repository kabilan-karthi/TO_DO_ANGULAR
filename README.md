# 📝 Task Manager App

A robust full-stack Task Management application built with **Angular (v17+)**, **ASP.NET Core**, and **MongoDB**. This project demonstrates a production-ready architecture following **SOLID principles** and **Clean Architecture**.

---

## 🚀 Tech Stack

### Frontend
- **Angular:** Standalone components for a modular architecture.
- **Tailwind CSS:** For a modern, utility-first responsive UI.
- **RxJS:** Reactive programming for state and data stream management.

### Backend
- **ASP.NET Core 8.0:** High-performance RESTful API.
- **MongoDB.Driver:** NoSQL database integration.
- **Pattern:** Repository Pattern and Dependency Injection (DI).

---

## 🛡️ Architecture & Design Patterns

The project is built with maintainability in mind:
* **Repository Pattern:** Abstracts the data layer, ensuring the business logic is decoupled from MongoDB-specific logic.
* **Dependency Injection:** Enhances testability and reduces tight coupling between classes.
* **Clean Architecture:** Clear separation between Models, Controllers, and Services.
* **Reactive UI:** Angular services leverage RxJS `Observables` to ensure the UI stays in sync with the backend state.



---

## 🧱 Project Structure

```text
TO-DO_ANGULAR
├── backend/
│   └── TaskManager.Api
│       ├── Configuration/  # MongoDB settings & mapping
│       ├── Controllers/    # API endpoints (REST)
│       ├── Data/           # ITaskRepository & Mongo implementation
│       ├── Models/         # Domain Entities & DTOs
│       └── Services/       # Specialized business logic
│
├── frontend/
│   └── Task-manager-ui
│       ├── src/app/
│       │   ├── core/       # Services, Models, Interceptors
│       │   ├── features/   # Standalone Components (Task List, Form)
│       │   └── app.routes.ts
│       └── proxy.conf.json # Local dev API proxy

```

---

## 🌐 REST API Endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| `GET` | `/api/tasks` | Fetch all tasks |
| `POST` | `/api/tasks` | Create a new task |
| `PATCH` | `/api/tasks/{id}/status` | Update task status (ToDo/InProgress/Done) |
| `DELETE` | `/api/tasks/{id}` | Permanently remove a task |

---

## ⚙️ Setup & Installation

### 🔧 Backend (ASP.NET Core)

1. **Navigate to directory:** `cd backend/TaskManager.Api`
2. **Configure Database:** Update `appsettings.json` with your MongoDB connection string.
3. **Run App:**
```bash
dotnet restore
dotnet run
```
4. **Swagger:** View the interactive API documentation at `http://localhost:5214/swagger`.

### 🎨 Frontend (Angular)

1. **Navigate to directory:** `cd frontend/Task-manager-ui`
2. **Install:** `npm install`
3. **Run App:**
```bash
ng serve --proxy-config proxy.conf.json
```
4. **Access:** Open `http://localhost:4200` in your browser.
---
## ✨ Key Features

* **Status Dashboard:** Visual breakdown of task progress.
* **Smart Filtering:** Filter tasks by status in real-time.
* **Validation:** Frontend and Backend validation for task data.
* **Overdue Tracking:** Automatic highlighting of tasks past their due date.

## TASK MANAGER DASHBOARD
![Create Task]{<img width="1380" height="851" alt="image" src="https://github.com/user-attachments/assets/ff8ede56-0724-4c09-a025-833be0542922" />
}
![Status Dashboard]{<img width="1298" height="890" alt="image" src="https://github.com/user-attachments/assets/218070ca-359d-4aba-ac84-7457e6221ffc" />
}
![Swagger API check]{<img width="1809" height="718" alt="image" src="https://github.com/user-attachments/assets/64624559-1396-4e53-a792-3937d79ba8dd" />
}
