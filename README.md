# Drivers
I Opted for an mvc application because it´s what i have most experience with

There is a method in the HomeController called ProcessFile which receives a file as an array of bytes and returns a partial view containing a table with the info required as a report.
This method in the controller calls a method in the HomeModel in the data layer of the application which is where the fun begins, here i read the file line by line and determine which command was, then proceed to calculate all the values needed.
At the end of this method i calculated the mph  with the total of miles and total of hours of each driver.
