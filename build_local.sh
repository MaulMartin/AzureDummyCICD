docker run \
-v `pwd`:/src \
-v `pwd`/app:/app \
-it mcr.microsoft.com/dotnet/sdk:5.0 \
/bin/bash 
