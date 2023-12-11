# _Animal Shelter API_

#### By: _**Julien Lenaz**

#### _A website for an animal shelter api listing the cats and dogs of the shelter_


## Technologies Used

* _C#_
* _MSTest_
* _Git_
* _Visual Studio Code_
* _ASP.NET Core MVC_
* _MySQL_
* _Razor_

## Description
#### _An api which calls stores information regarding available cats and dogs to adopt.  _

## Setup/Installation Requirements
* Clone this respository to your desktop_
* Navigate to the top level of the directory_
* Open in your code editor_
* Create a file named "appsettings.json" in the PierresTreats directory with the following code, replacing the "YOUR" statements with applicable information:
   ```json
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=YOUR-DATABASE-NAME;uid=YOUR-USERNAME;pwd=YOUR-MYSQL-PASSWORD;"
      }
    }
    ``` 
* Create the database using the migrations in the project. Open your shell and run [dotnet ef database update]. 
* Within the directory "AnimalShelterApi", run dotnet watch run --launch-profile "AnimalShelterApi-Production" to start the project with a watcher. 
* Start the project in development mode with dotnet watch run in the terminal in the "AnimalShelterApi" directory".
* Using program of your choice to make API calls, use the domain http://localhost:5000. 

## API Documentation

* Launch the project using dotnet run within the AnimalShelterApi directory, and input the following url: http://localhost:5000/swagger/
* To view all animals, make a GET request to http://localhost:5000/api/animals
* To view a specific animal, make a GET request to http://localhost:5000/api/animals/{id}

* To view a random animal, make a GET request to http://localhost:5000/api/animals/random 

* To view a list of cats, make a GET request to http://localhost:5000/api/v1/stringlist

* To view a list of dogs, make a GET request to http://localhost:5000/api/v2/stringlist


## Endpoints

Base URL: `https://localhost:5000`

### HTTP Request Structure

```
GET /api/animals
POST /api/animals
GET /api/animals/{id}
PUT /api/animals/{id}
DELETE /api/animals/{id}
GET /api/animals/random
GET /api/v1/stringlist
GET /api/v2/stringlist/
```

## Known Bugs

* Attempted to implement verisoning, but was unable to get it to work.

## License

_[MIT](https://choosealicense.com/licenses/mit/)_

Copyright (c) _2023_ _Julien Lenaz_
