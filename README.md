XSockets with WCF Guide
=============

# An introduction
Lots of RESTful WCF services out there with lots of polling over AJAX to them.
Even though I would like to replace these walkie-talkie applications with realtime it´s not likely 
that we will see this yet. However, you can boost your WCF (or any other legacy application) to realtime with XSockets.

# For who´?
Anyone interested in realtime development with knowledge of C# and JavaScript

# A short summary of what I did.
- Created a new MVC4 project
- Ran "Install-Package XSockets"
- Ran "Install-Package XSockets.Fallback"
- Ran "Install-Package jQuery
- Added a WCF service (see under the WCF folder in the MVC3 project)
- Added a few lines of code in my RoomService (WCF) to get it to be realtime.

- Also added a test page in the root of my MVC4 project (default.htm)
  Open multiple browser windows and you will see the realtime WCF in action.

Note: make a call to the root to start the web-application (and the XSockets server) if needed.


Regards
Uffe, Team Xsockets.NET