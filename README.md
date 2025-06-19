# 📘 AccountManagementSystem.Web

## 🧩 Project Overview

This is a full-featured account management system built using **Clean Architecture**. It includes:

- User registration & login  
- Role-based access control (Admin, Accountant, Viewer)  
- Account creation and management  
- Advanced filtering with pagination  
- Email confirmation support  

> ✅ Architecture Layers:  
- `Web` – MVC & Razor Pages frontend  
- `Application` – CQRS with MediatR  
- `Infrastructure` – EF Core, logging, email  
- `Domain` – Business entities  

---

## 📦 Required NuGet Packages

Make sure the following packages are installed:

- Autofac.Extensions.DependencyInjection  
- AutoMapper  
- MailKit  
- MediatR  
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore  
- Microsoft.AspNetCore.Identity.EntityFrameworkCore  
- Microsoft.AspNetCore.Identity.UI  
- Microsoft.AspNetCore.Mvc.ViewFeatures  
- Microsoft.EntityFrameworkCore.Sqlite  
- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.VisualStudio.Web.CodeGeneration.Design  
- Serilog.AspNetCore  
- Serilog.Settings.Configuration  
- Serilog.Sinks.MSSqlServer  
- System.Linq.Dynamic.Core  

---

## 🛠️ Setup Instructions

### 1. Apply EF Core Migrations

```bash
dotnet ef migrations add Initial --project AccountManagementSystem.Web --context AppDbContext
dotnet ef database update --project AccountManagementSystem.Web --context AppDbContext
```
## Execute the SQL Procedure in the GetAccount.sql
🖥️ Application Walkthrough
After that, run the project. It will show the following home page:

![image](https://github.com/user-attachments/assets/c9c2d217-be2f-43d3-837d-52b756221e77)

This project is based on Clean Architecture and contains 4 layers:
  - Web
  - Domain
  - Application
  - Infrastructure
It includes an Account entity that stores data such as Cash and AccountType.
The system supports full CRUD operations.
To add a new account, navigate to: https://localhost:7203/admin/Account/add

![image](https://github.com/user-attachments/assets/49b39a25-c1a2-4090-8fe1-de91ed63875a)

After submission, it redirects you to the dashboard: https://localhost:7203/Admin/Account
Where it displays a full listing of accounts:

![image](https://github.com/user-attachments/assets/53e90aab-9435-45bb-94d9-dc96301f9a5b)

The dashboard includes:
  - Column-based advanced search
  - Edit and Delete options for each record
🔐 Authentication & Roles
On the home page, there are Register and Login buttons:

🔑 Register Url : https://localhost:7203/Profile/Register

![image](https://github.com/user-attachments/assets/af1bab1a-b628-4451-ac0a-46484cc14fce)


🔐 Login Url : https://localhost:7203/Profile/Login

![image](https://github.com/user-attachments/assets/1d3df545-98ba-4b36-96ba-8d881011c0f9)

👥 Roles & Permissions
Three roles are seeded automatically:
  - Admin  
  - Accountant
  - Viewer

You can assign roles using SQL Server in the AspNetRoles and AspNetUserRoles tables.
  - Admin and Accountant have full access to dashboards and forms.
  - Viewer users will be redirected to Access Denied when attempting restricted actions.

![image](https://github.com/user-attachments/assets/0793f9ff-4082-4482-8413-f08990056f06)

✉️ Email Confirmation
To enable email confirmation:
  - Create an account on Mailtrap
  - Add your SMTP configuration in appsettings.json like this:
 ```bash
"SmtpSettings": {
  "FromName": "Asrar Tamim",
  "FromEmail": "AsrarTamim8@gmail.com",
  "Host": "sandbox.smtp.mailtrap.io",
  "Port": 2525,
  "Username": "your_mailtrap_username",
  "Password": "your_mailtrap_password",
  "SmtpEncryption": "Normal"
}
```
If not configured, registration will still work, but confirmation emails won't be sent.

# Userpage
You can add user using this 
go to this url : https://localhost:7203/Admin/User/AddUser
![image](https://github.com/user-attachments/assets/e9d7d92d-4cb7-475d-a7b2-7ba8c4340306)


