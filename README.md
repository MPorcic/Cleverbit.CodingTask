# Cleverbit Coding Task Task Template

An angular client has been added to the angular folder that connects to this backend, be sure to run npm install then npm start to run it.

# Seeding matches
At the moment 3 matches get seeded in memory each with expiry date a minute away

# Notes
Although there still has some elements to work on (session following on client side/whether client is signed in or not)
This task has proven to be a lot of code in regards of implementing it in a SOLID way following Patterns (like repository, dependency injection, DDD).

I hope I have managed to show a proper architectural structure around the code both in the backend and in the frontend in this alloted time. 

The backend contains: 
Repositories and app services for three of the domains Match, MatchEntry, MatchResult
The repositories only deal with database transactions meanwhile the app services are in charge of the business logic
These repositories and app services have all been autoinjected

The frontend contains:
An angular 13 app with material angular
http interceptor which authorizes the calls
service which deals with the matches
persistence of last played match
authguard to check if someone is logged in

I didn't have any left over time but I was going to finish writing the auth service which deals with user sessions.

If there are any questions feel free to contact me 
