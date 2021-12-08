git submodule update --init --recursive
cd chirpstack-api
git apply --index ../patches/0001-chirpstack_csharp_patch.patch
cd ..

dotnet build ./chirpstack-api/ChirpStack.Generate.csproj
dotnet build -c Release ./ChirpStack.Api/ChirpStack.Api.csproj