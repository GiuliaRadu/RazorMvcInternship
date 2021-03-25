# Razor MVC application

The infrastructure inspiration got [here](https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe)
The app is deployed to: [heroku](https://internship-class-giulia.herokuapp.com/)

## Prerequisites

To work with this application you need to install:
* [.Net Core SDK 5.0+](https://dotnet.microsoft.com/download/dotnet/5.0) - to run and develop the application
* [heroku CLI](https://devcenter.heroku.com/articles/heroku-cli) - to deploy the application
* 
## Build and run locally

```
dotnet build
```

to run
```
dotnet run
```

## Build and run in docker

```
docker build -t mvc .
docker run -d -p 8080:80 --name mvc_container mvc
```

to stop container
```
docker stop mvc_container
```
to remove container
```
docker rm mvc_container
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Choose container registry as deployment method
4. Build the docker locally


Login to heroku
```
heroku container:login
```

Push container
```
heroku container:push -a internship-class-giulia web
```

Release the container
```
heroku container:release -a internship-class-giulia web
```
