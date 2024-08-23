# EhrlichCodeChallenge
## Overview
This project is an ASP.NET Core API that allows the client applications to Import and Export Data from a Pizza place.
This API can return various sales informations base from the stored sales data.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or later (optional, but recommended)

## Getting Started

### Clone the Repository

First, clone the repository to your local machine using the web URL: **https://github.com/DevAlvinPayad/ErhlichCodeChallenge.git**

OR

```bash
git clone https://github.com/DevAlvinPayad/ErhlichCodeChallenge.git
cd your-repo
```

Then, after you clone the solution. Run the code below:
```bash
dotnet restore
```
### Import Database
Then import the **PizzaDb.bacpac** from project solution into your SQL Server
Do the following step by step instructions below

**Import Data-tier Application**

![image](https://github.com/user-attachments/assets/0d8306e6-2c08-4a2a-8527-06e261048ef4)


**Click Next**

![image](https://github.com/user-attachments/assets/5b4584d2-a84d-4172-a59e-7513e62ae596)


**Choose the path where the PizzaDb.bacpac file is located, then click Next until the import is finished**

![image](https://github.com/user-attachments/assets/9982bedf-7e17-4442-bd39-a8096fd3ba5e)


### Setup Configuration file
Open appsettings.json file and update the Connection string from below:

![image](https://github.com/user-attachments/assets/ceeee320-4e92-4b9f-962f-027ce0618db7)


Once the setup is done, run the command below:
```bash
dotnet run
```
