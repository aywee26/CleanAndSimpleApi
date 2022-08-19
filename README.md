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

# Easy deployment with GitHub Actions

1. Go to ```Settings``` -> ```Secrets```.
2. Set up following secrets: ```HEROKU_API_KEY```, ```HEROKU_APP_NAME```, ```HEROKU_EMAIL```.
3. Create a workflow. Use [heroku-deploy](https://github.com/marketplace/actions/deploy-to-heroku), supply secrets and set ```usedocker``` flag to true.

# References

- HABR: [Practicalities of deploying dockerized ASP.NET Core application to Heroku](https://habr.com/ru/post/450904/)

- Stack Overflow: [ASP .NET Core gives System.Net.Sockets.SocketException error on Heroku](https://stackoverflow.com/questions/59434242/asp-net-core-gives-system-net-sockets-socketexception-error-on-heroku)

- C# Corner: [Deploy A .NET API To Heroku Through GitHub Actions
](https://www.c-sharpcorner.com/article/deploy-a-net-api-to-heroku-through-github-actions/)

