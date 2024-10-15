## Hello! I appreciate you taking the time to review my application. To help you navigate it more easily, please follow the steps outlined below:

## Prerequisites for Backend and Frontend
Before getting started with the project, please make sure you have the following installed on your machine:

1-.NET 8 SDK
2- Node.js (version 20.18)
3- npm (comes bundled with Node.js)
4- To verify that everything is set up correctly, run these commands in your terminal:

## bash
dotnet --version
node -v
npm -v


## The repository is structured with both Backend (BE) and Frontend (FE) folders. Let’s start with the BE setup:

Setting Up the Backend
1- Launch Visual Studio 2022 (version 17.4 or later), which supports .NET 8.
2- Restore the project dependencies by executing the command:
## bash

1- dotnet restore
2- Update the DefaultConnection string in the *appsettings.json* file to match your SQL Server setup:

"ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}

3-Run the following command to apply database migrations:
## bash
dotnet ef database update
Start the application with:
## bash
dotnet run
*Important: Ensure that the host and port settings are configured to allow incoming and outgoing queries.*

## Setting Up the Frontend
1-Open the Frontend (FE) project in either Visual Studio or Visual Studio Code.
2-Access the terminal within your IDE.
3-Install the necessary npm packages by running:
## bash
*npm install*
Launch the development server with:
## bash
npm run dev

Enjoy your application review!

## Running Unit Tests
1-Navigate to the test folder within the Backend project.
2-Right-click to open the context menu.
3-Select the option to run the tests.

*Note: The tests utilize an in-memory database package to create a temporary database, ensuring that everything runs smoothly on your local setup.*

I hope these instructions are clear and helpful! If you have any further questions or need additional information, I’m more than happy to discuss it in an interview or any follow-up tests.
