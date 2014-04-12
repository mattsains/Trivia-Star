Trivia-Star
===========

An ASP.net Multiple choice quiz game. This web application was made for a Web Systems assignment testing html5 and basic ASP.net.

This project also uses Linq to SQL, ASP.net web methods (talking to AJAX), jQuery, master pages and SHA hashing & salting of passwords.

However, I didn't do any input sanitization. It's really easy to inject arbitrary code into the leaderboard page. It is also quite easy to circumvent the the scoring system. These were informed choices because this was a quick project for an entry-level course in web systems.

If you don't want to construct an account, feel free to use mine on the example database:

> username: matt
> password: hello
