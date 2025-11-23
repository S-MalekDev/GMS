# Gym Management System (GMS)

---

> ⚠️ **Warning:** This project is currently under development (Work in Progress). Some features may be incomplete or unstable.

## Description

Gym Management System (GMS) is a multi-layered application designed to manage gym membership subscriptions, including registering new members, creating subscriptions for various sports types such as Body Building, Workout, and Cardio, with support for promotions and discounts within specific time frames.  
The system supports multiple subscription types including weekly, monthly, quarterly, semi-annual, annual, and customizable subscriptions.  
It offers full member management, tracks subscription histories for each member, and optionally allows assigning personal coaches.  
Developed using C# and WinForms as the current UI layer, with a RESTful API layer planned for future web integration, the system relies on SQL Server with Entity Framework for database interaction.  
The project follows SOLID principles and adopts a layered architecture inspired by Clean Architecture, incorporating encryption and access protection mechanisms to ensure data security.

---

## Features

- Multi-layered application for managing gym membership subscriptions.  
- Full CRUD operations for members, users, and coaches.  
- Support for various subscription types: weekly, monthly, quarterly, semi-annual, annual, and customizable.  
- Management of different sports categories such as Bodybuilding, Workout, and Cardio.  
- Optionally assign personal coaches to members.  
- Centralized error logging and tracking system.  
- Customizable UI themes for improved user experience.  
- Automated email notifications.  
- Subscription document printing capability.  
- Member attendance tracking.  
- Role-based access control with user authentication and authorization.  
- Data encryption to ensure security.  
- Protection and security for RESTful APIs.  
- Efficient database access via Entity Framework.  
- Adherence to SOLID principles and dependency injection for maintainability and scalability.  
- Use of DTOs for structured and secure data transfer between layers.

---

## Technologies Used

- Programming Language: C#  
- Application Type: WinForms (current UI)  
- Framework: .NET Core 8  
- Database: SQL Server  
- ORM: Entity Framework  
- Project Architecture: Five layers (UI, API, Application, Core, Data Access)  
- Design Pattern: Inspired by Clean Architecture

---

## Project Structure

- **UI Layer:** WinForms user interfaces and user interactions.  
- **API Layer:** RESTful web services layer providing core functionalities.  
- **Application Layer:** Business logic and rules implementation.  
- **Core Layer:** Contains interfaces, entities, and shared code between layers.  
- **Data Access Layer:** Database communication using Entity Framework.  
- **Use of DTOs** for organized and secure data transfer between layers.

---

## Installation

### Prerequisites

- Install [.NET 8 SDK and Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- Install [SQL Server](https://www.microsoft.com/en-us/sql-server)  
- Install development environment such as Visual Studio 2022 or later

### Setup and Running Instructions

1. Restore the database from the `.bak` backup file or run the database creation script located in the `DataBase` folder within the project.  
2. Modify the **Connection String** in the Data Access layer to match your database configuration.  
3. Run the API layer first and ensure it is working properly.  
4. Run the WinForms UI application that consumes the API.  
5. Log in using the default admin account:  
   - Username: `admin`  
   - Password: `admin`

---

## Screenshots

> Screenshots of the application UI will be added later to enhance documentation.

---

## License

This project is **without an official license** (All rights reserved).  
Use or distribution of this project is not permitted without explicit permission from the author.

---
