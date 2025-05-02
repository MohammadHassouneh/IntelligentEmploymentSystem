
# Intelligent Employment System

## Overview

The Intelligent Employment System is a web-based platform designed to facilitate the employment process for both applicants and companies. Built using ASP.NET Core MVC, Entity Framework, and Razor views, the system supports functionalities such as user and company registration, job posting, resume submission, and applicant review.

## Key Features

### 🧑‍💼 For Applicants:
- User registration and login
- Profile management
- Resume upload and update
- View available job postings

### 🏢 For Companies:
- Company registration and login
- Manage company profile
- Post new job descriptions
- View and review applicants

### 📊 Admin Functionality (if applicable):
- View job listings and statistics
- Manage user and company data

## Technologies Used
- **Backend**: ASP.NET Core MVC, Entity Framework Core
- **Frontend**: Razor Pages, Bootstrap 5, jQuery, DataTables
- **Database**: SQL Server (Code First Migrations)

## Folder Structure
- `/Controllers` – Handles web request routing
- `/Models` – Contains data models and entities
- `/Views` – Razor views categorized by feature (Home, User, Company, etc.)
- `/wwwroot` – Static files (CSS, JS, etc.)

## Getting Started
1. Clone the repository or extract the source files.
2. Open the solution in Visual Studio.
3. Update the database using `Update-Database` in the Package Manager Console.
4. Run the project using IIS Express or `dotnet run`.

## Future Improvements
- Add role-based access control
- Improve UI/UX with modern components
- Implement API endpoints for future mobile app integration
- Add job recommendation system using AI

## License
This project is for educational and demonstration purposes.

---

*Developed as part of a smart employment portal.*

