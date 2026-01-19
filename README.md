📝 Task Manager Application

A full-stack Task Manager application built using Angular, ASP.NET Core Web API, and MongoDB, following clean architecture, RESTful API design, and SOLID principles.

This project was built to understand frontend–backend–database integration, real-world API flow, and modern web development practices.

🚀 Tech Stack
Frontend

Angular (Standalone Components)

TypeScript

Tailwind CSS

RxJS

Angular HttpClient

Proxy configuration for API calls

Backend

ASP.NET Core Web API (.NET 7+)

RESTful API design

Dependency Injection

SOLID principles

Clean Architecture

MongoDB.Driver

Database

MongoDB (Local / Atlas)

Single collection: Tasks

✨ Features
Core Features

Create a task with:

Title

Due date & time

Reminder flag

Default task status: ToDo

Update task status:

ToDo → InProgress → Done

Delete tasks

View all tasks grouped by status

UI Features

Status filter board (All / ToDo / InProgress / Done)

Dashboard showing:

Total tasks

Completed tasks

In-progress tasks

Overdue task detection

Reminder badge indicator

Clean, responsive UI

🧱 Project Structure
TO-DO_ANGULAR
│
├── backend/
│   └── TaskManager.Api
│       ├── Configuration/
│       ├── Controllers/
│       ├── Data/
│       ├── Models/
│       ├── Services/
│       └── Program.cs
│
├── frontend/
│   └── Task-manager-ui
│       ├── src/app/
│       │   ├── core/
│       │   ├── features/
│       │   └── app.routes.ts
│       └── proxy.conf.json
│
└── README.md

🔄 Backend Architecture Flow
Client (Angular / Swagger)
↓
Controller (HTTP Layer)
↓
Service (Business Logic)
↓
Repository (Data Access)
↓
MongoDB
↑
JSON Response

📦 Backend Folder Explanation
Folder	Purpose
Configuration	App settings (MongoDB config)
Controllers	Handle HTTP requests
Services	Business logic
Data	Database access (Repository pattern)
Models	Domain models & DTOs
📦 Frontend Folder Explanation
Folder	Purpose
core	Services & models
features	Task UI components
app.routes.ts	Routing
proxy.conf.json	API proxy
🌐 REST API Endpoints
Method	Endpoint	Description
GET	/api/tasks	Get all tasks
POST	/api/tasks	Create task
PATCH	/api/tasks/{id}/status	Update status
DELETE	/api/tasks/{id}	Delete task
⚙️ Setup Instructions
1️⃣ Backend Setup
cd backend/TaskManager.Api
dotnet restore
dotnet run


Backend runs on:

http://localhost:5214


Swagger:

http://localhost:5214/swagger

2️⃣ Frontend Setup
cd frontend/Task-manager-ui
npm install
ng serve --proxy-config proxy.conf.json


Frontend runs on:

http://localhost:4200

🔐 Environment Configuration
MongoDB (appsettings.json)
"MongoSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "TaskManagerDb",
  "TasksCollectionName": "Tasks"
}

🧠 Key Concepts Used

RESTful API

DTOs (Data Transfer Objects)

Repository Pattern

Dependency Injection

SOLID Principles

CORS

RxJS Observables

Angular Standalone Components

Clean Architecture
