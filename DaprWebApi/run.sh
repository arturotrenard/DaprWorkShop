#dapr run --app-id DaprWebApi --app-port 6004 --dapr-http-port 3604 --dapr-grpc-port 60004 --app-ssl dotnet run
#dapr run --app-id DaprWebApi --app-port 5123 --log-level debug dotnet run

dapr run --app-id DaprWebApi --app-port 5123  dotnet run
