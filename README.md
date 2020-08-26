<header align="center">
  <h1> Party Squirrel</h1><br>
  <a href="https://github.com/chyoon2/PartySquirrelClient.Solution"><img src="https://media.discordapp.net/attachments/746547229824909342/748277551692251291/default_squirrel.jpg" alt="Squirrel"></a><br>
  <h2>C# Team Week Project, 08.27.2020</h2><br>
  <h3>By Chris Yoon, Ben Russell, Kate Skorija, Peter Grimm</h3>
</header><br>

## Description

_This application will let users create accounts and add squirrels they would like to party with to their individual parties. Each user will have a party and can view other users parties. They will also have the ability to add squirrels from others parties to their own. Users will also be able to post messages to each other on their the party pages. The application uses the Pexels API to generate random pictures of squirrels that a user can either "Go Nuts!" or say "No Nuts!". The go nuts button will allow the user to create a profile of that squirrel and add them to their party. The no nuts button will reload the page and show a fresh image for the user._<br><br>


## Setup/Installation Requirements

* Clone this repository from GitHub https://github.com/chyoon2/PartySquirrelClient.Solution
* Open the downloaded directory in a text editor of your choice. (VSCode, Atom, etc.)
* Install [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/2.2) 
* To install the REPL dotnet script, run `dotnet tool install -g dotnet-script` in your terminal.
* To get an API key, create a free [Pexel account](https://www.pexels.com/).
* In the ApiHelper.cs file, add your Pexel API key on line 12 after `"Authorization",`.
* Run `dotnet restore` in terminal to get all dependencies.
* Run `dontnet build` in terminal to make sure project has everything required and no issues.
* Run the program with the command `dotnet run`.<br>

### Additional Setup/Installation Notes:

* You will need to have [MySQL](https://www.mysql.com/) installed on your computer to start the database for this project. 
* Once you have it installed open your terminal and `run mysql -uroot -pepicodus`. This will start the mysql server on your computer. 
* You will need to run the command `dotnet ef migrations add Initial`. This create a folder that holds information MySQL needs to create the database.
* Then run `dotnet ef database update`. This will migrate the database to MySQL workbench where you can refresh the Schemas tab to make sure everything was created properly.
* Then you will have the database correctly set up and you can start the project in a separate terminal that the one running mysql by running dotnet run.<br><br>

## Specifications

| Behavior | Input | Output |
| -------- | ----- | ------ |
| 1. A user will be able to create an account, login and logout. | User info | Hello User! |
| 2. All users will have a party named after them. | User Name: Ben | Ben's Party |
| 3. A user will be able to view images of squirrels and decide if they want to party with that squirrel. |  |  |
| 4. A user can either choose "Go Nuts!" or "No Nuts!", "Go Nuts!" will allow the user to add party info to that squirrel and add it to their party page. | "Go Nuts!" | Name: Squeeky, Party Trick: Juggling, Party Story: Makes delicious salsa, Party Location: Pool, Party Since: 12/31/1999 |
| 5. A user will be able to add squirrels from a different users party to their party. | | |
| 6. A user will be able to post messages on other users party pages| Yo Sweet Squirrel! | "Yo Sweet Squirrel" |
<br>

## Stretch Goals

* Allow users to upload their own images of squirrels
* Add user roles (Administrator, etc.)
* Allow users to see the location of party squirrels on Google Maps<br><br>


## Known Bugs

_No known issues. Please reach out if you have any problems._<br><br>



## Support and contact details

Please feel free to contact us through GitHub (usernames: brussell36, kate-skorija, chyoon2, pagrimm) with any questions, ideas or concerns.<br><br>

## Technologies Used

* C#
* .NET Core 2.2
* Visual Studio Code 
* Git and Git BASH 
* MySQL Workbench
* MySQL Database
* Entity Framework
* Identity
* Pexels API<br><br>

### License

*This site is licensed under the MIT license.*

Copyright (c) 2020 **_Chris Yoon, Ben Russell, Kate Skorija, Peter Grimm_**