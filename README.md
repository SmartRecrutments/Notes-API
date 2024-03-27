
# Simple Note Taking API


Basic RESTful API for creating, reading, updating, and deleting notes. Users are able to manage their notes through HTTP requests.

## Features:
- Note Management
    - Users can create new notes by sending a POST request with note content
    - Users can retrieve a list of all notes by sending a GET request.

    - Users can retrieve a specific note by its ID with a GET request.
    - Users can update an existing note by its ID with a PUT request.
    - Users can delete a note by its ID with a DELETE request.



## Run Locally
System requirements:
 - .NET SDK 8.0.203+
 - Visual Studio Version 17.9.5+

Clone the project

```bash
  git clone https://github.com/SmartRecrutments/Simple-Note-Taking-API.git
```

Go to the project directory

```bash
  cd src/Notes-API
```

Start the server

```bash
  dotnet run
```

> [!NOTE]
> For the lunch with swagger, use VS "Dev Swagger" profile, then the swagger page will open automatically after the run.


> [!TIP]
> You can choose if want to seed the in-mememory DB by setting  
` "SeedDb": true` in appsettings.Development.json
 


