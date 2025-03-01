# .NET 8 Web API Project

## Overview
This project is built using **.NET 8** and **Web API**, covering fundamental to advanced topics in .NET development. The project implements **CRUD operations**, various **data passing techniques** (ViewBag, ViewData, TempData), and **data annotations** for validation. It follows a structured approach by incorporating a **Business Layer** and **Interface** to enhance code modularity and maintainability.

Database connectivity is achieved using **Entity Framework Core Code First Approach** with **SQL Server** as the database.

---

## Features
- **CRUD Operations** (Create, Read, Update, Delete)
- **Data Passing Techniques**: ViewBag, ViewData, TempData
- **Data Annotations** for Model Validation
- **Business Layer and Interface Implementation**
- **Database Connectivity using EF Core Code First Approach**
- **.NET 8 Web API Integration**
- **Secure and Scalable Architecture**

---

## Technologies Used
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **C# Programming Language**

---

## Installation and Setup

### Prerequisites
Make sure you have the following installed:
- **.NET SDK 8**
- **SQL Server**
- **Visual Studio 2022** (or any compatible IDE)

### Steps to Run the Project
1. **Clone the repository**:
   ```sh
   git clone https://github.com/Bhaneshvar007/DotNet-MVC-Web-Api
   ```
2. **Navigate to the project folder**:
   ```sh
   cd project-folder-name
   ```
3. **Restore dependencies**:
   ```sh
   dotnet restore
   ```
4. **Update database using EF Core Migrations**:
   ```sh
   dotnet ef database update
   ```
5. **Run the project**:
   ```sh
   dotnet run
   ```
6. **Access the API**:
   - Open browser and navigate to: `https://localhost:5001/swagger`
   - Test endpoints using Swagger UI

---

## API Endpoints

| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | /api/items | Get all items |
| GET | /api/items/{id} | Get item by ID |
| POST | /api/items | Create a new item |
| PUT | /api/items/{id} | Update an item |
| DELETE | /api/items/{id} | Delete an item |
