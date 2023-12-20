# Vision

## Description

This project is designed to detect labels, and save the results into a database and a bucket

## Getting Started

### Prerequisites

#### Environment

- Database Engine (mysql, Latest version, not used by the tests but used in the program's main)
- IDE (Visual community or Visual Code studio, or anything that can resolve nuget packages and build c# based codes)
- Package manager (Nuget)
- OS (windows 10)

#### Libraries

- Google.Apis 1.64.0
- Google.Cloud.Storage.V1 4.7.0
- Google.Cloud.Vision.V1 3.3.0
- Microsoft.Data.SqlClient 5.1.2 (Pour la connection à la db, requêtes sql)

## Tree
VisionTest
├───Analysers
├───Database
├───Datas
├───Exceptions
├───Interfaces
VisionTestTests