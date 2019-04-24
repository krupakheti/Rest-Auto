Software Requirements Specification
for
Automated Restaurant System

Version 1.0





















Student Group 1
2/5/2019
   Mississippi State University


Table of Contents
Table of Contents                                                                                                         	2
Revision History                                                                                                           	3
1.   Introduction                                                                                                            	4
1.1   	Purpose 4
1.2   	Document Conventions 4
1.3   	Intended Audience and Reading Suggestions  	4
1.4   	Product Scope   5
1.5   	References    	5
2.   Overall Description                                                                                                	5
2.1   	Product Perspective   	5
2.2   	Product Functions     	6
2.3   	User Classes and Characteristics 6
2.4   	Operating Environment 7
2.5   	Design and Implementation Constraints 7
2.6   	User Documentation 	7
2.7   	Assumptions and Dependencies 7
3.   External Interface Requirements                                                                         	7
3.1   	User Interfaces  7
3.2   	Hardware Interfaces  	8
3.3   	Software Interfaces   	9
3.4   	Communications Interfaces   	9
4.   System Features                                                                                                     	9
4.1   	Table Status       	10
4.2   	Daily Sales Total 	10
4.3		Order Input And Tracking	11
4.4		Waiter And Busser Availability	12
4.5 		Administration	12	
5.   Other Nonfunctional Requirements                                                                     	12
5.1   	Performance Requirements    	12
5.2   	Safety Requirements 	13
5.3   	Security Requirements  13
5.4   	Software Quality Attributes   	13
5.5   	Business Rules  13
6.   Other Requirements                                                                                              	13
Appendix A: Glossary                                                                                                  	14
Appendix B: Analysis Models                                                                                     	14
Appendix C: To Be Determined List                                                                          	14


Revision History
Name
Date
Reason For Change
Version
All
2/5/19
Construction of Document
1.0
Laura
2/12/19
Construction of Document
1.0.1
All
2/12/19
Construction of Document
1.1
All
2/19/2019
Sections 2, 3, and 5
1.2

























1.    Introduction

1.1    Purpose

A restaurant’s workflow is currently done manually via a whiteboard. This SRS describes the proposed system of automation: Release 1.0. In order to streamline operations and reduce downtime, the owners of the restaurant have requested and automated system be designed to reduce operating errors. 
This system will display information relevant to each restaurant employee, informing them of which tasks they need to complete and allowing them to inform other employees when those tasks are completed.   	

1.2    Document Conventions

This Software Requirements Specificatiµon document for the Automated Restaurant System uses Times New Roman, size 12 font.  Different sections are separated by bolded headings. There has been no use of highlighting to designate specific meaning during the creation of this document.  More detailed requirements do inherit higher-level requirements. There exist no shorthand or acronym conventions within this document.
 
Keywords: Automated Restaurant System, Waterfall Model, Software Engineering, Touchscreen

1.3    Intended Audience and Reading

This project is a prototype for the automation system. This has been implemented under the guidance of the contractor: the restaurant owner. The project will be useful for both the employees and the customers of the establishment. 
Restaurant owner: 
Recommended reading sections include:
Product scope
Business rules
Description and priority
User documentation
User interface, including hardware and software interfaces
Developers: 
Recommended reading sections include:
Product scope
Business rules
Product functions
Software and communication interfaces
System features
Functional requirements


1.4    Product Scope

The purpose of the restaurant management system is to ease communication and to create a convenient and easy-to-use application for employees, trying to serve customers. The system is based on a object-oriented abstraction of tables and employees. Above all, we hope to provide a comfortable user experience along with the clearest dissemination of information as possible.

1.5    References

Data flow diagram in section 2.2 made using LucidChart. 

2.    Overall Description

2.1    Product Perspective

Restaurant workers are experiencing difficulty with communications and access of current information system: a communal whiteboard. The system is being designed to replace the whiteboard and prevent certain users from modifying information not directly relevant to themselves. The proposed system is designed to be self-contained, and not part of a larger system or a component. 










2.2    Product Functions


The major functions of the software are as follows:
Host requests a table from the system
Wait staff will be notified when a party has been seated
Wait staff will input customer orders into the system
Food orders will be displayed to the kitchen staff
Kitchen staff will tell the system when an order is filled
System will notify wait staff when an order has been filled
Wait staff will update the system when a party has left
System will notify a busser when a party has left
Bussers will update the system when a table has been cleaned
System will notify the host when a table becomes available

2.3    User Classes and Characteristics

Host:
This is a frequent-user group with limited access. They can view tables and request a clean table for seating. 

Waiters:
Waiters are very frequent users who use this product to place orders for the customer. The privilege level for this user is limited. They can view tables, place orders, and mark tables as empty.

Bussers:
Bussers are frequent users of the system who should be able to update the system once a table has been cleaned. They have limited access to the system. They can view tables and mark them as cleaned.

Manager:
This user group has access to all roles, data, and privileges. The manager is an infrequent user of the system.

Kitchen Staff:
Kitchen staff user group members are frequent users with limited access. They can view orders and mark them as filled. 


2.4    Operating Environment


No software specifications or necessary platforms. 
Software ideally run on a touchscreen, but can be used on a standard desktop as well. 

2.5    Design and Implementation Constraints

No specific constraints necessary. 


2.6    User Documentation

A basic user manual will be provided.

2.7    Assumptions and Dependencies

There are no currently known assumptions or dependencies vital to the functioning of the system.

3.    External Interface Requirements

3.1    User Interfaces

Wait-staff:
The wait-staff will have one shared kiosk into which they enter customer orders (orders are taken down on paper before being transferred into the system). They will also be alerted when a table’s order is ready for delivery and be able to print out bills here. When a host assigns a table to a party, the kiosk will display the table and the wait-person assigned to it who will then need to confirm their recognition of. This will be a two screen interface, one displaying a notification board, visible to those not using the other screen. On this will be displayed new assignments of wait-persons to tables, and order ready alerts. The second screen will be a touch screen on which the wait-staff will acknowledge alerts pertaining to them, enter orders, request bill printouts and mark tables for bussing.

Manager:
The manager will have a console in their office. From here they will be able to monitor all the actions of the other roles and be able to assume control of them. This will be a standard desktop computer.

Host:
The host will have a console at their podium. It will display which tables are free and allow the host to assign a table to an incoming party.  This action will alert the wait-staff of the newly assigned table. This will be a single touch screen interface displaying tables. The host will be able to select a table to be assigned to incoming customers which will alert a member of the wait staff.

Busser: 
The busser will have a kiosk with a large display showing them which tables to bus and which lets them designate a table as cleaned. This will be a single touch screen interface, large enough to be seen by several viewers, which will display the tables which need to be bussed. Once a table has been cleaned, the returning busser will dismiss the table from the to-be-cleaned display, alerting the host to its availability.

Kitchen staff:
There will be a kiosk in the kitchen on which orders are received by the chefs and with which a chef will notify the wait-staff that an order is ready to be served.This will be a single touch screen interface on which incoming orders are displayed in a queue to the chefs. Chefs are alerted when a new order comes in and can mark an order as accepted (they are actively cooking it) and finished, which dismisses it from the queue and alerts the wait-staff that the order is ready to serve.

3.2    Hardware Interfaces

The software is meant to run on any hardware which allows point, click, and text entry. The touch screen devices will provide this through on-screen keyboards and their native touch interfaces. The manager's console will be a standard desktop. The wait-staff kiosk will have a small thermal receipt printer that it will send bills to when they are to be printed out.

3.3    Software Interfaces

The system will be self contained in its communications, only sending messages across a local area network and requiring no connection to the outside world. Messages are passed from one subsystem to another rather than to individuals. The common flow of messages is as follows:
The host console will alert wait staff of a newly seated table and assign a member of the wait staff, posting an alert on their kiosk’s display and removing the table from the list of available tables.. This alert will be acknowledged by the wait staff assigned and they will report back later once they enter an order. The order’s most recent entries are submitted to and appear on the kitchen-staff’s display and when an order is finished the kitchen-staff marks it as complete. When marked as complete an order appears on the wait-staff display as ready to serve and this is acknowledged by a member of the wait-staff. When a table is ready for the bill the wait-staff member assigned to that table will print it out and when the table is vacated the wait-staff will mark it for busing. This will send an alert to the busser’s display and once a table is cleaned the busser that cleaned the table will dismiss it from the to-be-cleaned list. This will move the table back to the host’s list of available tables.

3.4    Communications Interfaces

The network server communications protocol for the system will have the programs on the individual kiosks sending notifications for tasks to be done to the kiosk corresponding to the task.

 4.    System Features

The system intends to solve real world restaurant problems so that the whole restaurant is well maintained, managed, and efficient.  The following are the major system features the automation system would focuses on:

Table status
Daily sales total
Order tracking / management
Waiter and busboy availability
Administration
	

4.1 Table Status

Description and Priority
The restaurant automation system maintains and keeps track of the unoccupied and clean tables in the restaurant.The automation service will allow the host to accurately assign tables that are ready for incoming customers. In addition to that, the automation system notifies bussers to clean a table once the customer leaves. Similarly, a waiter would be assigned to attend to a table automatically so that efficient and quality service is ensured. This feature of the automation software ranks as a very high priority.

Stimulus/Response Sequences
Host requests an empty table
An empty, clean table is chosen by the system
Displays the table which was assigned

Waiter marks a table as empty
Displays the table which was marked

Busser marks table as clean
Added to list of available tables

Functional Requirements
Authorization levels for each employee type
Manager override
User interface
Notification system



4.2 Daily sales total

Description and Priority
The overall sales of the restaurant each day can be monitored with the help of ledgers the system creates.  This is a high priority feature as we aim to deliver a product that replaces the current paper record keeping.

Stimulus/Response Sequences
Orders and payments in association with bills are submitted by waiters through the business day
The system computes bills on demand and the total sales at the end of the day with print out upon request.
	
Functional Requirements
Manager override
Orders submission 
Calculates running bill for each table
Payment information entry
Create ledger of total sales
Printing of bills / ledger


4.3 Order input and tracking

Description and Priority
The customer orders are tracked via the system which can be accessed by the kitchen chefs and waiters assigned for that particular table number. This feature is flexible enough to change and cancel orders. Since this feature ensures efficiency during the customer operation, our system sets a high priority for this system feature.

The Stimulus/Response Sequences
Order input by waiter
Display order to kitchen

Order filled by kitchen
Display order to waiter

Functional Requirements
Add orders to queue 
Number and time stamp orders
Remove filled orders from the queue
Mark orders as delivered

4.4  Waiter and busser availability

Description and Priority
The system requires waiters and busboys sign in and out at the start and end of their shifts. This is used to maintain a list of which staff are available so that only staff that are available will be assigned to wait and bus tables. Medium priority.

Stimulus/Response Sequences
Wait and bussers sign in and out at the beginning and end of their shifts.
The system’s lists of wait and bus staff that are available to be assigned duties are edited.
         
Functional Requirements:
The system should record sign in and sign out time of employees.


4.5  Administration

Description and Priority:
The system allows a manager to administer the system. The system have permission to act as any other employee, making changes to any information or systems these other employees have access to. Besides that, they have access to some additional administration features like editing views, menus, and rosters. This feature would be an important feature with a high priority.

Stimulus/Response Sequences
Manager assumes the role of another employee
Display interface and controls for that user group

Functional Requirements:
Override code / login







5.    Other Nonfunctional Requirements

5.1    Performance Requirements


Notifications must arrive at the appropriate kiosk within 60 seconds. 
No other performance or timing requirements are necessary. 

 5.2    Safety Requirements

There are no occupational safety or health concerns.


5.3    Security Requirements

Profiles should prevent user groups from modifying data relevant to other groups, which can be overridden by the manager. 

No other security or privacy concerns. 

5.4    Software Quality Attributes

Availability - Ideally, the system should have 100% uptime during operating business hours. Updates that require the system to be offline should be done during hours when the restaurant is closed. 

No other specific quality metrics to be assessed. 

5.5    Business Rules

There are no business rules to note.


6.    Other Requirements

<Define any other requirements not covered elsewhere in the SRS. This might include database requirements, internationalization requirements, legal requirements, reuse objectives for the project, and so on. Add any new sections that are pertinent to the project.>




Appendix A: Glossary

<Define all the terms necessary to properly interpret the SRS, including acronyms and abbreviations. You may wish to build a separate glossary that spans multiple projects or the entire organization, and just include terms specific to a single project in each SRS.>

Appendix B: Analysis Models

<Optionally, include any pertinent analysis models, such as data flow diagrams, class diagrams, state-transition diagrams, or entity-relationship diagrams.>

Appendix C: To Be Determined List

<Collect a numbered list of the TBD (to be determined) references that remain in the SRS so they can be tracked to closure.>


Classes to be made:

Waiters: host, busser, kitchen staff
	One host at a time will have a relationship with at least one and potentially many employees of the other types. Waiters have a permanent set of 1-n tables they are assigned to.
Relationships: Waiter activates the order at the table.

Host: waiter, busser
	The host interacts with all n of the tables. All interactions with the other staff are mediated via the tables, a table of tables.
Relationships: Activates a table, summoning its waiter (though the waiter is already assigned).

Busser: waiter, host 
	A busser will interact with one table at a time, and may not have an assigned table at some time.
Relationships: Cleans the table.



Manager: everyone
	A manager will interact with all the other entities and is a “super-entity” that can assume the roles of any other. They have a permanent relationship with all n staff and all n tables.
Relationships: 	Can do any activities others can.

Kitchen Staff: tables.	
	Kitchen staff will have a may to many relationship with waiters so as to receive orders and to let them know orders are finished.
Relationships: Makes/fulfills/cooks orders.

Table(attributes: Order, number of customers, waiter, busser )
	
Table will have the relationship with the number of customers based on many to many relationship. Customer to Order (1 to many)
Relationships: does not initiate


Composition relationship : ( Container is destroyed , contents also destroyed ) 

Tables are destroyed , kitchen chefs, hosts,waiters, busser, manager ,tables are destroyed.

Aggregate relationship :  ( Container is destroyed , contents is not destroyed) 
		No aggregate relationship …..!!



			
			























