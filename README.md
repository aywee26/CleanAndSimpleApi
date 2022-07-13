# CleanAndSimpleApi

Basically, I took ASP.NET Core Web API template, reworked it into Clean Architecture project, and made it work with Heroku.

And it is live! [Check it out!](https://clean-and-simple-api.herokuapp.com/index.html)

# Making it work with Heroku

By default, ASP.NET Core projects run on ports 5000 and 5001. Heroku doesn't allow that. If you don't change anything, the project will fail with System.Net.Sockets.SocketException.

The simplest fix is this:
```C#
string? port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port))
{
    app.Urls.Add("http://*:" + port);
}
```

# References

- HABR: [Practicalities of deploying dockerized ASP.NET Core application to Heroku](https://habr.com/ru/post/450904/)

- Stack Overflow: [ASP .NET Core gives System.Net.Sockets.SocketException error on Heroku](https://stackoverflow.com/questions/59434242/asp-net-core-gives-system-net-sockets-socketexception-error-on-heroku)

