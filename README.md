# AccountManagementSystem.Web
* First need to install all this pakage
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
* Then run migration and update
  - dotnet ef migration add Initial --project AccountManagementSystem.Web --context AppDbContext
  - dotnet ef database update --project AccountManagementSystem.Web --context AppDbContext
* Then run the Sql Command which in the GetAccount sql in sql server
After that run the prpject this will show this home page
![image](https://github.com/user-attachments/assets/c9c2d217-be2f-43d3-837d-52b756221e77)
* This project is base on clearn architecture there are 4 layer Web, Domain, Application, Infrustructure
Have a Account Entity where a Have Accout info like Cash, Account Type.
this account have Crude opration 
this url : https://localhost:7203/admin/Account/add
take you to add a new account
![image](https://github.com/user-attachments/assets/49b39a25-c1a2-4090-8fe1-de91ed63875a)
After submit with info that take this in this url : https://localhost:7203/Admin/Account
where is showing a dashboard
![image](https://github.com/user-attachments/assets/53e90aab-9435-45bb-94d9-dc96301f9a5b)
There have a advance search option where you can search indiviual with colum
and edit and delete button
* In the home page there are Register Button and Login Button 
register button take this url :https://localhost:7203/Profile/Register
![image](https://github.com/user-attachments/assets/af1bab1a-b628-4451-ac0a-46484cc14fce)
Login bttuon goes this url : https://localhost:7203/Profile/Login
![image](https://github.com/user-attachments/assets/1d3df545-98ba-4b36-96ba-8d881011c0f9)
if you register it will automaticly add in add as a user .
First with seeding there are add Three rules(Admin, Accountant, Viewer)
set the role using selective user using sql server in AspNetRoles Table
then it can access the Dashboard and add pages 
but if you are access those url  using viewer then it will take you to Access Denied page
![image](https://github.com/user-attachments/assets/0793f9ff-4082-4482-8413-f08990056f06)








