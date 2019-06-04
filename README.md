# ASP NET CORE 2.1 and Automapper
ASP NET CORE APIs + Mongo DB + Automapper + MiniProfiling


### Requirements
+ Docker & Docker Compose
+ ASP NET CORE 2.1
+ Automapper
+ MongoDB
+ MiniProfiling: monitor the application

### Usage

+ Start MongoDB & APIs
```
cd devops
docker-compose up
```

+ Monitor your application http://localhost:5000/profiler/results

#### Testing
-------------
TODO: Need to create Seed Data for testing(Getting List Books and Book Detail)
```
Id = 5cefa9cfa8af8905f4457ba1
Author = "Rick Johnson",
Price = (decimal)48.45,
Category = "Computer",
BookName = "Advance C#"
```

+ Start MongoDB
```
cd devops
docker-compose up mongo
```

+ Run Testing
```
cd DotnetMapper
dotnet test
```

### Reference
+ [Automapper](http://anthonygiretti.com/2018/12/19/common-features-in-asp-net-core-2-2-webapi-mapping)
+ [Profiling](http://anthonygiretti.com/2018/12/16/common-features-in-asp-net-core-2-2-webapi-profiling/)