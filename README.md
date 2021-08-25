# LetterWordExercise

This is ASP.NET Core Web Application with ASP.NET Razor Pages.

From the letter of exercise description we can chose from winforms app or asp.net web app.
winforms app is for windows systems only, and as.net web app is cross platform. That's why I use it.

For asp.net web app we have MVC, API and Razor pages (also we have react and angular, but I wanted to realize main algoritm by c# and for front we don't need so powerfull tools).
Razor page is giving us all what we need. However we could use MVC or API, but as for me they are for lager apps.

# What to improve

1) Add validation for file
2) Remove consts and add them into appsettings
3) Add animation of loading file, after start uploading file disable buttons (so user can't spam it)
4) Add new page for matched file with preview and download button
5) Add logs
6) Do something with function Match in DefaultMatchWordsService, there are a lot of if's, it's look weird
7) Perhaps we don't need server side work for matching file, we don't save it at server and don't use it after returning result, so it could be better if we move all work to client side, use JS or AngularJS for this purpose. Maybe better use SPA with ReactJS

# Exercise description

There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:

  ```sh
  foobar
  fo
  obar
  ```

should result in the ouput:

  ```sh
  fo+obar=foobar
  ```

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

Don't spend too much time on this. When submitting the exercise, briefly write down where you would improve the code if you were given more time.