# 📝 Task Manager App

A full-stack **Task Manager application** built using **Angular**, **ASP.NET Core Web API**, and **MongoDB**, following **RESTful API design**, **clean architecture**, and **SOLID principles**.

---

## 🚀 Tech Stack

**Frontend**
- Angular (Standalone Components)
- TypeScript
- Tailwind CSS
- RxJS

**Backend**
- ASP.NET Core Web API (.NET 7+)
- RESTful APIs
- Dependency Injection
- MongoDB.Driver

**Database**
- MongoDB (Local / Atlas)

---

## ✨ Features

- Create, update, and delete tasks
- Task statuses: **ToDo**, **InProgress**, **Done**
- Status-based filtering
- Dashboard summary
- Overdue task indication
- Reminder flag
- Clean and responsive UI

---
## 🧱 Project Structure
TO-DO_ANGULAR
│
├── backend/
│ └── TaskManager.Api
│ ├── Configuration/
│ ├── Controllers/
│ ├── Data/
│ ├── Models/
│ ├── Services/
│ └── Program.cs
│
├── frontend/
│ └── Task-manager-ui
│ ├── src/app/
│ │ ├── core/
│ │ ├── features/
│ │ └── app.routes.ts
│ └── proxy.conf.json
│
└── README.md


---

## 📦 Backend Folder Explanation

| Folder | Purpose |
|------|--------|
| Configuration | Application settings (MongoDB config) |
| Controllers | Handle HTTP requests and responses |
| Services | Business logic |
| Data | Database access using repository pattern |
| Models | Domain models & DTOs |

---

## 📦 Frontend Folder Explanation

| Folder | Purpose |
|------|--------|
| core | Services and models |
| features | Task-related UI components |
| app.routes.ts | Application routing |
| proxy.conf.json | API proxy configuration |

---

## 🌐 REST API Endpoints

| Method | Endpoint | Description |
|------|---------|-------------|
| GET | `/api/tasks` | Get all tasks |
| POST | `/api/tasks` | Create a task |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

---
## ⚙️ Setup & Run the Application

Follow the steps below to run the **backend API** and **frontend UI** locally.

---

## 🔧 Backend Setup (ASP.NET Core)

### Prerequisites
- .NET SDK 7 or later
- MongoDB (local or Atlas)

---

### 1️⃣ Navigate to backend
```bash
cd backend/TaskManager.Api
dotnet run

2️⃣ Configure MongoDB

Update appsettings.json:

"MongoSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "TaskManagerDb",
  "TasksCollectionName": "Tasks"
}


Ensure MongoDB is running.

3️⃣ Run the backend
dotnet restore
dotnet run

4️⃣ Verify backend

API: http://localhost:5214

Swagger UI: http://localhost:5214/swagger

🎨 Frontend Setup (Angular)
Prerequisites

Node.js (v18+ recommended)

Angular CLI

Install Angular CLI if not installed:

npm install -g @angular/cli

1️⃣ Navigate to frontend
cd frontend/Task-manager-ui

2️⃣ Install dependencies
npm install

3️⃣ Start frontend (with API proxy)
ng serve --proxy-config proxy.conf.json

4️⃣ Access application
http://localhost:4200


The frontend uses a proxy configuration to communicate with the backend API during development.




