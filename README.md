# Assignment 1
This assignment is meant for recruitment purposes for Adera AS

## Environment requirements
* .NET Core SDK 2.2.103 or newer

## General
* Apply the SOLID principles though the whole exercise
* Data:
  * Fields: total, createdAt, paidAt
  * total: the transaction value
  * createdAt: the date and time of the revenue
  * paidAt: the date and time of the cash flow
* Git is part of the exercise, commit sizes and comments matter
* Let us known when you are finished by sending a mail, after the assessment is complete the fork should be deleted (Keeping a local copy is not a problem, but getting a list of completed assignments by looking at the forks will render it useless for other candidates)

## Tasks
1. Create a fork of this repository where you make all your changes
2. Change the layout of the web application to a classic dashboard layout (fixed left menu, fixed header with logo)
3. Make sure selected menu item is highlighted
4. Create a new controller named Reporting with an Index view (The rest of the tasks should be in this view)
5. Create a data read model to load data from /App_Data/data.json
6. Display a comparison between revenue and cashflow in a chart (of your own choosing)
7. Add a calendar (of your own choosing) to select a time period to show in your comparison chart
8. Add a chart that shows the following counts per day in the selected time period
   * Free transactions count
   * Paid transactions count
   * Credit transactions count
9. Bonus: Find out what other usefull charts can be created with the dataset available, and create them
