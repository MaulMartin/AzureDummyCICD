#!/bin/bash

dotnet restore
dotnet build DummyCDCI --runtime linux-x64 --configuration Release
dotnet publish DummyCDCI --runtime linux-x64 --configuration Release -o /app/publish
