# ASP.NET Core DataGrid – Cascading Dropdown Editing with Remote Data

## Repository Description

This repository demonstrates how to implement cascading dropdown editors with remote data binding inside an ASP.NET Core DataGrid during inline editing scenarios.

## Project Overview

This sample project shows how to configure the Syncfusion ASP.NET Core DataGrid to support cascading DropDownList components when editing grid rows. The primary use case is handling dependent fields such as Country and State, where the available options in one dropdown depend on the selected value of another.

The grid is configured with inline CRUD operations and retrieves its dropdown data from remote endpoints using the `UrlAdaptor`. JavaScript editor lifecycle methods (`create`, `read`, `write`, and `destroy`) are used to fully control the behavior of each dropdown editor.

## Key Features

- Inline editing with Add, Edit, Delete, Update, and Cancel actions
- Cascading dropdown editors inside grid columns
- Remote data loading using DataManager and UrlAdaptor
- Dynamic filtering of dependent dropdown values
- Clean separation of grid configuration and editor logic

## Technologies Used

- ASP.NET Core MVC
- Syncfusion EJ2 ASP.NET Core DataGrid
- JavaScript (EJ2 DropDownList components)
- Remote data binding using Web API endpoints

## Prerequisites

- Visual Studio 2022
- .NET SDK compatible with ASP.NET Core
- Syncfusion EJ2 ASP.NET Core packages

## Functionality

When a country is selected in the `ShipCountry` column, the `ShipCity` dropdown is enabled and filtered dynamically using a query based on the selected country ID. The state dropdown remains disabled until a valid country selection is made, ensuring proper cascading behavior.

## Running the Application

1. Clone or download the repository to your local machine.
```
git clone <repo_link>
```
2. Open the solution file in Visual Studio 2022.
3. Restore NuGet packages by rebuilding the solution.
4. Run the project and navigate to the home page to view the grid.

## Usage
Use the toolbar buttons to add or edit a record. Select a country first, then choose the corresponding state from the filtered dropdown list.

## Reference Documentation:

- [Getting started with ASP.NET CORE Grid](https://ej2.syncfusion.com/aspnetcore/documentation/grid/getting-started-core) 
- [Editing](https://ej2.syncfusion.com/aspnetcore/documentation/grid/editing/edit)
- [API Reference](https://help.syncfusion.com/cr/aspnetcore-js2/syncfusion.ej2.grids.grid.html)
