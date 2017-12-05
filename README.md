# FootballStats
A web application that displays results and statistics from the top European football leagues. I have gathered this data by querying and parsing a popular football statistics web site. For this purpose I created a custom spider program (not shared here) that uses HTTP and regular expressions and to download and parse match data.

This includes German Bundesliga, English Premier League, Italy Seria A, Spain La Liga, France League 1 and Portugal Primeira Liga. 

Demo: http://footballstats20171206124559.azurewebsites.net

![Match details](https://raw.githubusercontent.com/TheoKand/FootballStats/master/Screenshots/matchDetails.png)
![Match replay](https://raw.githubusercontent.com/TheoKand/FootballStats/master/Screenshots/matchReplay.png)
![Season details](https://raw.githubusercontent.com/TheoKand/FootballStats/master/Screenshots/seasonDetails.png)
![Team details](https://raw.githubusercontent.com/TheoKand/FootballStats/master/Screenshots/teamDetails.png)
![Teams list](https://raw.githubusercontent.com/TheoKand/FootballStats/master/Screenshots/teamsList.png)

# Technologies
The project is built using the following technologies:

- Microsoft MVC 5.2
- Razor 3.2
- Bootstrap 3.3
- Entity Framework 6.1
- ADO.NET Entity Data Model
- AngularJS
- MySql
- JQuery 3.1

It's a fully responsive website which means that all the information is visible on any type of device like mobiles and tablets.

The site is published on the cloud using Microsoft Azure.

# Features

http://goalsweb20170519023933.azurewebsites.net/allteams
You can view a list of teams organized by country. 

http://goalsweb20170519023933.azurewebsites.net/team/details/Real%20Madrid
Click on the team name to view all details about the team, including their trophies and a list of all their matches.

http://goalsweb20170519023933.azurewebsites.net/season/Premier%20League/2014
Click on the season name to view the league table and a list of all matches.

http://goalsweb20170519023933.azurewebsites.net/match/Details/985635
You can view the details of any match by clicking on the score of a match. This includes the match timeline which has all the events of the match like passes, goals etc.

http://goalsweb20170519023933.azurewebsites.net/replayMatch/Details/985635
Click Replay Match to view a graphical representation of the match events as they happened.
