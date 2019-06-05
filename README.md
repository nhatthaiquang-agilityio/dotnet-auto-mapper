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