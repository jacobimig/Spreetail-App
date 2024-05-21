# Spreetail-App

An interactive command line app that stores a multi-value dictionary in memory.

1. Have Visual Studio 2022 installed
2. Clone the repository
3. Open the project in visual studio and right-click on the Spreetail App.sln file and then click "Build".
4. To run unit tests, click on Tests -> Run All Tests.  Or run "dotnet build" in the command prompt.
5. To run the app, click on the down arrow next to the green arrow near the top of the visual studio window and select "Spreetail App".  Then click the green arrow.

Valid Command Examples

ADD colors blue &nbsp;&nbsp;&nbsp;&nbsp;  Adds single value 'blue'<br />
ADD colors blue red &nbsp;&nbsp;&nbsp;&nbsp; Adds 'blue' and 'red'<br />
KEYS &nbsp;&nbsp;&nbsp;&nbsp; Returns list of keys<br />
MEMBERS colors &nbsp;&nbsp;&nbsp;&nbsp; Returns list of members from the colors key<br />
REMOVE colors blue &nbsp;&nbsp;&nbsp;&nbsp; Removes blue from colors<br />
REMOVEALL colors &nbsp;&nbsp;&nbsp;&nbsp;  Removes all of the members from the colors key<br />
CLEAR &nbsp;&nbsp;&nbsp;&nbsp; Removes all key value pairs<br />
KEYEXISTS colors &nbsp;&nbsp;&nbsp;&nbsp; Checks if colors is a key.  Returns true or false<br />
MEMBEREXISTS colors blue &nbsp;&nbsp;&nbsp;&nbsp; Checks if blue is a member of the colors key.  Returns true or false<br />
ALLMEMBERS &nbsp;&nbsp;&nbsp;&nbsp; Returns all members<br />
ITEMS &nbsp;&nbsp;&nbsp;&nbsp; Returns all key value pairs<br />
EXIT &nbsp;&nbsp;&nbsp;&nbsp; Exits the app<br />
