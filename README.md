- [documentation](#documentation)
  - [create new model](#create-new-model)
    - [client](#client)
    - [server](#server)
- [Original](#original)
  - [Blazor-CRUD-With-MongoDB](#blazor-crud-with-mongodb)
  - [Demo](#demo)
  - [Read the full article at](#read-the-full-article-at)


# documentation

## create new model

### client

- create new page in `Client/Pages/<Model>Data.razor`
- add it to `Client/Shared/NavMenu.razor`

### server

- create new interface in `Server/Interface/I<Model>.cs`
- create new DAL in `Server/DataAccess/<Model>DataAccessLayer.cs`
- create new controller in `Server/Controllers/<Model>Controller.cs`
- add it to `Server/Startup.ConfigureServices`<br>
  

# Original

## Blazor-CRUD-With-MongoDB
We will create a Blazor application using MongoDB as our database provider. We will create a Single Page Application (SPA) and perform CRUD operations on it. We will use a form to accept the user inputs. The form will have client-side validations and contains a dropdown list, which will bind to a collection in our database. We will also provide a filter option to the user to filter the employee records based on employee name.

We will use Visual Studio 2019 and MongoDB 4.2.

## Demo

![Alt Text](./Output/BlazorWithMongo.gif)

## Read the full article at

http://ankitsharmablogs.com/crud-using-blazor-with-mongodb/

