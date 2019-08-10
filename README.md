# App4
 UWP Inventory Application
This is a Universal Windows Inventory Application written in C# using the .NET framework and external app services provided by Microsoft Azure.  


Use Cases
for
UWP Inventory Project
Version 1.0 approved
Prepared by Domingo Vargas Anchondo
Rasmussen College
July 12, 2019
Revision History

Name	Date	Reason For Changes	Version
Domingo Vargas Anchondo	August 04, 2019	Implementation of new Enhancement	
			

 
1.	Use Case Identification
1.1.	Use Case Name
State a concise, results-oriented name for the use case. These reflect the tasks the user needs to be able to accomplish using the system. Include an action verb and a noun. Some examples:
•	Add Inventory using forms in the UWP application. 
•	Display inventory. 
•	Sort through inventory via grid or search functionality. 
1.2.	Use Case History
1.2.1	Created By
This use case was created by Domingo Vargas Anchondo.
1.2.2	Date Created
This use case was created on July 12, 2019
1.2.3	Last Updated By
This use case was last updated by Domingo Vargas Anchondo.
1.2.4	Date Last Updated
1. July 12, 2019
2.	Use Case Definition
2.1.	Description
The UWP inventory project will consist of a Universal Windows Application that connects to a Microsoft Azure database. The user will be able to navigate through the database via functions that will enable the user to add inventory items, update inventory items, and display how many product items the person has.
2.2.	Features
The application will include these features:
1.	Add Inventory Form
2.	Update Inventory
3.	See Inventory
4.	Search for Inventory

2.3.	Preconditions
List any activities that must take place, or any conditions that must be true, before the use case can be started. Number each precondition. Examples:
1.	Database would have to be created with all of the specifications that the application will need and the appropriate information for each product. 
2.	The user would have to fill the database with enough inventory items to test sorting and updating functions.

2.4.	Priority
The priority of these features is high as they will be the main functionality of the application. Without these features the user wouldn’t be able to store inventory items in the database and much less access them without the implementation of the database and the forms that are used to gather that data.
2.5.	Normal Course of Events
Upon running the application, the user would be able to create new inventory by entering the correct information on the form page and hitting submit. The user would then be able to search for their inventory and see how many of each item they have. 
2.6.	Dependencies
The application would depend on having Microsoft Azure running the server for the SQL functionality to be implemented into the application. 
2.7.	Assumptions
This Universal Windows application requires an Azure database. Due to setting up the database last week the application should be ready to connect to the database. The forms in the application have also been created to in order to fully implement the changes all that would be needed to do would be to setup a connection string with SQL functions so that the application could get the text values in the forms and store them into the database. 

 
3.	Enhancements
3.1.	Delete Function
One of the enhancements I’ve decided to go with in the application is the delete function that will delete the specific row that the user needs to delete. For example, if the user clicks the trash icon that appears for every instance of every row that is called into the Listview the application will display a confirmation message that would allow the application to distinguish if the delete was intentional or not. This is important because before the implementation the application would just delete the row when the trash icon was clicked without confirmation. This new implementation would prevent mistakes from deleting important information. While it is possible to recover the information, the user would have to contact the database administrator to update the delete field for the row to false and would allow the information to be retrieved from the application again. The following screenshots show how the application works when the delete icon is clicked and when the user cancels it and when the user actually deletes it.  
 
 
