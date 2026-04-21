# EJ2 DataGrid Cascading DropDown with Remote Data (ASP.NET Core)

This repository demonstrates how to implement cascading DropDownList editors inside a Syncfusion Essential JS 2 (EJ2) DataGrid using remote data binding in an ASP.NET Core application.

## Overview

The sample shows a real-world editing scenario where the available values of one column’s DropDownList depend on the selection made in another column. Data is fetched dynamically from remote services during Grid editing, ensuring that the dependent dropdown values are always in sync with the selected parent field.

This approach is commonly used in enterprise applications for scenarios such as Country–State selection, Category–Product mapping, or any hierarchical data relationships within tabular editing workflows.

## Key Features

- Syncfusion EJ2 DataGrid with inline editing
- Cascading DropDownList editors
- Remote data binding using ASP.NET Core controllers
- Dynamic filtering of child dropdown based on parent selection
- Clean separation of client-side and server-side logic

## Prerequisites

- .NET Core SDK
- Visual Studio 2019 or later
- Syncfusion EJ2 ASP.NET Core packages
- Valid Syncfusion license or trial setup

## Getting Started

1. Clone the repository.
2. Restore NuGet packages.
3. Configure Syncfusion license key if required.
4. Run the application and navigate to the Grid page.
5. Edit a row to see cascading dropdown behavior in action.

## Resources

- https://ej2.syncfusion.com/aspnetcore/documentation/grid/editing/edit-types#render-cascading-dropdownlist-in-edit-form
