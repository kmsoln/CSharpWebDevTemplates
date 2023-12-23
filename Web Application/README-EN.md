<div align="center">

# Model-View-Controller Project
</div>
<p>

Welcome to the MVC project repository. 
this project is a template to start doing project in MVC architecture

---

## How to use the project
1. ### **[.NET SDK][dotnet]**: Before you begin, ensure that you have the following dependencies installed:
    [.NET SDK][dotnet]: Required for building and running .NET applications.

[dotnet]: https://dotnet.microsoft.com/download

2. ### **Clone the Repository**: If you haven't already, clone this repository to your local machine using the following command:

    ```bash
    git clone https://github.com/your-username/your-repository.git
    ```

3. ### **Set up the project**: 
   Go to the next path and open file "**ProjectInfo.cs**"
   ```
   └── Web Application
     └── Config
         └── ProjectInfo.cs
   ```
   In the `ProjectInfo.cs` file, you will find a class named `ProjectInfo`. this class controlling the project information
   
      ```csharp
      public static class ProjectInfo
      {
          public static readonly string ProjectName = "";
          public static readonly string StudentName = "";
          public static readonly string StudentGroup = "";
      }
      ```
   Then add your name, project name, group inside the class following the next approach:
   - `ProjectName`: Represents the name of the project.
   - `StudentName`: Represents your name.
   - `StudentGroup`: Represents the student group.

4. ### **Install the needed database package**
   Certainly! When it comes to databases, the NuGet package names for their respective .NET Core providers are as follows:

   - ### SQL Server (Microsoft SQL Server):

   NuGet Package Name: `Microsoft.EntityFrameworkCore.SqlServer`

   Install Command:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   ```

   - ### PostgreSQL:
   
   NuGet Package Name: `Npgsql.EntityFrameworkCore.PostgreSQL`
   
   Install Command:
   ```bash
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
   ```

   - ### SQLite:
   
   NuGet Package Name: `Microsoft.EntityFrameworkCore.Sqlite`
   
   Install Command:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   ```

   ### MongoDB:

   NuGet Package Name: `MongoDB.Driver`

   Install Command:
   ```bash
   dotnet add package MongoDB.Driver
   ```
   These packages are Entity Framework Core providers for the specified databases. You can use the `dotnet add package` command to install them in your .NET Core project.

   Replace `dotnet` with `nuget` if you are not using the .NET CLI.

   Remember to install the appropriate package based on the database you are using in your project. After installing the packages, you can configure your DbContext to work with the chosen database provider.


 ### 5. Replace Connection String with Your Database Connection String:

 #### Step 1: Locate the `appsettings.json` File

 1.1. Open your .NET Core project in your preferred code editor.

 1.2. Navigate to the `appsettings.json` file. This file is commonly found in the root directory of your project. The file path might look like: `YourProjectName/appsettings.json`.

 #### Step 2: Open and Modify `appsettings.json`

 2.1. Open the `appsettings.json` file in the code editor.

 2.2. Locate the section that contains your connection string. It look like this:

- ### **Postgres** :

    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Host=your_host;Port=your_port;Database=your_database_name;Username=your_username;Password=your_password;Pooling=true;"

    },
    // Other configurations...
    }
    ```
    Replace the placeholders with your actual PostgreSQL details:

    - `your_host`: The host name or IP address of your PostgreSQL server.
    - `your_port`: The port number on which PostgreSQL is running (usually 5432).
    - `your_database_name`: The name of your PostgreSQL database.
    - `your_username`: Your PostgreSQL username.
    - `your_password`: Your PostgreSQL password.

- ### **SQL** :
    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
    },
    // Other configurations...
    }
    ```
    Replace the placeholders with your actual SQL Server details:

    - `your_server_name`: The name or IP address of your SQL Server.
    - `your_database_name`: The name of your SQL Server database.
    - `your_username`: Your SQL Server username.
    - `your_password`: Your SQL Server password.

- ### **MongoDB** :
    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "mongodb+srv://your_username:your_password@your_cluster.mongodb.net/your_database_name?retryWrites=true&w=majority"
    },
    // Other configurations...
    }
    ```
    Replace the placeholders with your actual MongoDB details:

    - `your_username`: Your MongoDB username.
    - `your_password`: Your MongoDB password.
    - `your_cluster`: Your MongoDB cluster name.
    - `your_database_name`: The name of your MongoDB database.


 #### Step 3: Save the Changes
   4.1. Save the `appsettings.json` file after making the changes.

 #### Step 5: Update Code References (if necessary)
5.1. If your project uses the connection string in code, ensure that you update those references.

   For example, if you are using Entity Framework Core, you might need to update the code in your `Program.cs` or wherever your `DbContext` is configured:

 ```csharp
 // Other configurations...

 string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
 // Use the connectionString variable where needed, such as configuring DbContext.

 builder.Services.AddDbContext<AuthDbContext>(o =>
 {
     o.UseNpgsql(connectionString);
 });

 // Other configurations...

 ```

 Replace `"DefaultConnection"` with the name of your connection string if it's different.


### 6. Initialize Migration with Your Database:

#### Step 1: Install Entity Framework Tools:

1.1. Open a terminal or command prompt.

1.2. Install the Entity Framework Tools globally if not already installed:

```bash
dotnet tool install --global dotnet-ef
```

#### Step 2: Create Database Context:

2.1. Ensure you have a database context class set up. For example:

```csharp
// Data/ApplicationDbContext.cs
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // DbSet properties for your entities
}
```

#### Step 3: Initialize Migration:

3.1. Open a terminal or command prompt.

3.2. Navigate to your project directory.

3.3. Run the following command to initialize a migration, specifying the output path:

```bash
dotnet ef migrations add InitialCreate --output-dir Data/Migrations
```

#### Step 4: Update Database:

4.1. After initializing the migration, run the following command to apply the migration and update the database:

```bash
dotnet ef database update
```

#### Step 5: Make Changes and Repeat:

5.1. If you make further changes to your data model, repeat steps 4 and 5 to create and apply additional migrations.
