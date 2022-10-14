# Dr SillyStringz Factory

### Created by Noah Lundquist in October of 2022

## Links

* [Repository](https://github.com/nalundquist/DrSilly)

## Description

A web interface for tracking engineers, machines, and repair tickets at one "Dr. SillyStringz" factory.  Since the Machines and Engineers are all based upon user inputs the nature of the good doctors machines are in your hands, reader.

## Features

* Stores Machines and Engineers
* Either or both can be viewed in a bundle
* New Machines and Engineers can be created and details on both can be edited/deleted.
* Machines and Engineers can be assigned to one another in many-to-many maintenence relationships
* Incidents of malfunction can be logged to indivdual machines and have engineers assigned to perform repairs.


## Technologies Used

* Built in VS Code (v.1.70.1) using the following languages:
	* C#
	* HTML
	* CSS

* ASP.Net Core
* MySQL Database
* MySQL Workbench
* Entity Framework

## Installation

* Download [Git Bash](https://git-scm.com/downloads)
* Input the following into Git Bash to clone this repository onto your computer:

		>git clone https://github.com/nalundquist/DrSilly


* Enter the cloned project folder "/DrSilly/Factory" and type:

		>dotnet restore

followed by

		>dotnet build

*After this, create an appsettings.json file in the root /DrSilly folder (sub in your own set username and password for the bracketed bits)

		{
  		"ConnectionStrings": {
      	"DefaultConnection": "Server=localhost;Port=3306;database=factory;uid=[USERNAME];pwd=[PASSWORD];"
  		}
		}

* next, type into console in the root directory:

		>dotnet ef database update

* Finally, navigate to the /Factory directory in git bash (if you navigated away) and type  

		>dotnet run

Follwing this you can navigate to http://localhost:5000 in the browser of your choice to navigate around the interface.  

## Known Bugs

Search functionality is WIP; any query will return an accurate length of the amount of results in the URL (implying the query goes fine) while the results page itself will display nothing.  Will work on it :).

## License

Licensed under [GNU GPL 3.0](https://www.gnu.org/licenses/gpl-3.0.en.html)