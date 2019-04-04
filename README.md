# HTTPListener
Listen and print all HTTP requests to the console.  This can be used for testing data coming from a system to verify the payload.

[![Build Status](https://dev.azure.com/nathanwestfall/HTTPListener/_apis/build/status/nwestfall.HTTPListener?branchName=master)](https://dev.azure.com/nathanwestfall/HTTPListener/_build/latest?definitionId=20&branchName=master)
[![](https://images.microbadger.com/badges/image/nwestfall/httplistener.svg)](https://microbadger.com/images/nwestfall/httplistener "Get your own image badge on microbadger.com")
[![](https://images.microbadger.com/badges/version/nwestfall/httplistener.svg)](https://microbadger.com/images/nwestfall/httplistener "Get your own version badge on microbadger.com")

## What does it do
This is a *very* simple app that just prints what you send it.  GET, POST, PUT, DELETE requests with any body, query or path.  Headers?  Those work here too.  It will return a `200` every time.

Let's look at a few examples

GET - http://localhost:5000/data?type=1

![](https://i.imgur.com/pyv5tbp.png)

POST - http://localhost:5000/data (with xml body)

![](https://i.imgur.com/GO8wKjU.png)

POST - http://localhost:5000/data (with form data)

![](https://i.imgur.com/mDCJi8r.png)

## How to run without Docker
1. Install dotnet SDK 2.2
2. Clone repo
3. Run `dotnet run`
4. Start sending data

## How to run with Docker
1. `docker run -p 5000:80 httplistener -it`
2. Start sending data
