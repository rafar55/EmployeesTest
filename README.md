# Technologies 
  * Blazor Server For the Web UI
  * Dapper For Sql Server Access
  * .Net 6

# How to Run the project

This project will **create the database and tables automatically**, when the project runs for the first time. It will also seed the database with some dummy data

## With Dotnet Cli

1. For you need to be sure that you have .Net 6 installed on your marchine. You can download .Net 6 from this link
https://dotnet.microsoft.com/en-us/download/dotnet/6.0
2. Once dotnet is installed the next step is to clone this repository.
3. Update the appsettings.json change con Default Connection string to you preference.
```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeesDbRromero;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```
If you are working in windows and have visual studio installed, this step might no be neccesary since you already have localdb installed. You can leave the connection
string as it is.

4. Open your favorite terminal and navigate to the location where you cloned the repo. Then run the following command
`dotnet run --project .\EmployeeChallenges.Web\`

## With Visual Studio 2022
 1. Make sure you have the latest version of visual studio installed
 2. Clone the project
 3. It might be required that you change the connection string. Depending if you have installed localdb
 3. Run the Project
 
 # Testing in Azure
 In order to quickly view the result this application is hosted in azure. Here is the link
 https://demo-blazor-employee.azurewebsites.net/
 
 
