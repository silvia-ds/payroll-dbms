# Payroll DBMS Menu

A Windows Forms GUI application for managing a payroll database system, built with C# and Oracle Database.

## About

This project is a GUI implementation of a command-line payroll database management system. It allows users to create, drop, populate, and query tables in an Oracle database through an intuitive graphical interface.

## Features

### Main Menu
- Navigate between different database operations
- Test database connection

### Drop Tables
- Drop individual tables by name
- Drop all tables at once
- View current tables in the database

### Create Tables
- Create new tables with a default schema
- Validates table names (letters, numbers, underscores only)
- Prevents duplicate table names

### Populate Tables
- Insert data into the 5 original schema tables:
  - Departments
  - Employees
  - Salary
  - Payroll
  - Attendance
- Input validation for all fields
- User-friendly input dialogs

### Query Tables
- **Custom Search:**
  - Select any table and field
  - View all valid search values
  - Case-insensitive partial matching
  - Query All feature to view entire tables

## Database Schema

| Table | Description |
|-------|-------------|
| Payroll | Payroll records (payroll-id, salary-id, emp-id, pay-date, gross-pay, net-pay) |
| Employees | Employee details (emp-id, first-name, last-name, phone-num, title, email, dept-id) |
| Attendance | Attendance tracking (attendance-id, emp-id, date, status, hours-worked, overtime) |
| Departments | Department information (dept-id, manager-id, dept-name, location, budget, phone-num) |
| Salary | Salary information (salary-id, emp-id, pay-frequency, base-salary, allowance, deductions, effective-date) |

## Technologies Used

- **Language:** C# (.NET Framework)
- **UI:** Windows Forms
- **Database:** Oracle Database
- **Connection:** Oracle.ManagedDataAccess NuGet package

## Setup

### Prerequisites
- Visual Studio 2019 or later
- Oracle Database access
- VPN connection (for database access)

### Installation
1. Clone the repository
2. Open `PayrollDBMS.sln` in Visual Studio
3. Install NuGet package: `Oracle.ManagedDataAccess`
4. Build and run the project

## Project Structure

```
PayrollDBMS/
├── Program.cs              # Application entry point
├── DBConnection.cs         # Database connection handler
├── Utils.cs                # Utility methods
└── UIForms/
    ├── MainMenu.cs         # Main navigation menu
    ├── LoginForm.cs        # Login interface
    ├── DropForm.cs         # Drop tables interface
    ├── CreateForm.cs       # Create tables interface
    ├── PopulateForm.cs     # Populate tables interface
    └── QueryForm.cs        # Query tables interface
```

## Usage

1. Launch the application
2. Sign in using school DB credentials
3. Select an operation from the Main Menu
4. Follow the on-screen prompts
5. Use the Back button to return to the Main Menu
6. Close the application using the X button

## Author

Silvia Das

## Acknowledgments

- Course: CPS510
