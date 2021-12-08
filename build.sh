git submodule init --recursive
git apply --index
git submodule update

dotnet build ./chirpstack-api/ChirpStack.Generate.csproj
dotnet build -c Release ./ChirpStack.Api/ChirpStack.Api.csproj