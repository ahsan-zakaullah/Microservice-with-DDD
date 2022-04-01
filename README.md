# Microservice by following DDD

example
```
[::MIC-I:::]  [::::::::::::::MIC-II::::::::::::::::][:MIC-III:]
```

In json format this would look like the following:

```json
{
  "scheduleId": 12132891,
  "plantId": 1213,
  "updatedOn": "2021-12-01T12:44:17Z",
  "scheduleItems": [
    {
      "scheduleItemId": 1,
      "cementType": "MIC-I",
      "start": "2021-11-23T00:00:00Z",
      "end": "2021-11-23T02:15:00Z",
      "updatedOn": "2021-12-01T11:43:17Z"
    },
    {
      "scheduleItemId": 2,
      "cementType": "MIC-II",
      "start": "2021-11-23T03:00:00Z",
      "end": "2021-11-23T10:30:00Z",
      "updatedOn": "2021-12-01T11:43:17Z"
    },
    {
      "scheduleItemId": 3,
      "cementType": "MIC-III",
      "start": "2021-11-23T10:30:00Z",
      "end": "2021-11-23T11:00:00Z",
      "updatedOn": "2021-12-01T11:43:17Z"
    }
  ]
}
```

It has the following end points

* GET   `schedule` allows getting the latest created schedule for a plant
* POST  `schedule` allows adding a schedule for a plant
* POST  `schedule/items` allows adding an item to a schedule.

# Project Setup Basics

* **Api** - The actual microservice scaffolding.
* **Api.Tests.Integration** - Integration tests related to the Api
* **Infrastructure** - Dealing with the database and other infra-related aspects.
* **Domain** - All of the business models and business logic relating to these models are contained here.
* **Common** - Any code which could be shared across all other projects (i.e. common extension methods or the like)

# Getting Started

1. Install .NET 6
1. Clone the repo.
1. Run the postgres service in docker compose `docker-compose up`
1. Run the tests (`dotnet test`)
