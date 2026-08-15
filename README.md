# Student Management System

A simple console based Student Management System built with C#

## Features

* Add, edit, and remove students
* Search by ID or Name
* Sort students by name or age
* Show all students and total count
* Validate student information
* Prevent duplicate email addresses and phone numbers
* Use `Guid` for unique student ID
* Formatted console interface with colors and menus

## Project Structure

```text
StudentManagementSystem/
├── Program.cs
├── Student.cs
├── StudentManager.cs
└── StudentValidation.cs
```

## Validation

The application validates:

* Full name
* Age
* Phone number
* Email
* Name search input

Email and phone numbers must also be unique.

## Student ID

Each student receives a unique `Guid` when created.

```csharp
Guid.NewGuid()
```

The entered ID is validated using:

```csharp
Guid.TryParse()
```

## Data Storage

Student data is currently stored in memory using `List<Student>`, so the data is cleared when the application closes.

## Run

```bash
git clone https://github.com/mehran79bahrami/StudentManagementSystem.git
dotnet run
```
