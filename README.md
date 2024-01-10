# Vision

## Description

This project is designed to detect labels, and save the results into a database and a bucket

## Getting Started

### Prerequisites

Make sure you have a credentials file with you, or that you have credentials with enough permissions

from there be sure to follow this https://cloud.google.com/docs/authentication/gcloud

this will show you how to properly authenticate your app to your google cloud account

Set up the environment variables with whatever you wish, be careful : if you want to provide your own bucket, be sure it's from google cloud and that you have the following permissions on it : read, write, delete, update on objects

#### Environment

- Database Engine (mysql, Latest version)
- IDE (Visual community or Visual Code studio, or anything that can resolve nuget packages and build c# based codes)
- Package manager (Nuget)
- OS (windows 10, not tested under other OS)

#### Libraries

- Google.Apis 1.64.0
- Google.Cloud.Storage.V1 4.7.0
- Google.Cloud.Vision.V1 3.3.0
- MySql.Data 8.2.0 (for DB connection, SQL requests)

### Application configuration

Visual studio community, should automatically download all dependencies, if not just run `nuget update`

### Database configuration

just run the Create_database.sql under the sql folder

## Deployment

### Dev environment

With visual studio community, you only need to build the application within visual studio and for the tests, it's fairly simple too, just run them

### integration environment

Go over github packages, and download the latest executable, and put it on the prod environment

#### building

Tests mustn't be build, so, you must only build "VisitionTest", from the main branch, put it on github packages and then correctly version it, with a changelog, explaining what has been added, change, and removed, this should reflect the doc too

## Directory tree
    VisionTest
    ├───Analysers
    ├───Database
    ├───Datas
    ├───Exceptions
    ├───Interfaces
    VisionTestTests

## Collaborate

If you wish to collaborate, simply clone the repo, create a branch with the feature you want to fix, or add.

When you're finish with it, create a pull request, we will review your code, comment it, and it will be merged once it passes our requirements.

For more info please check the wiki

## License

Unlicensed, Available at project root

## Contact

If you have any problems, please reach us on github issues