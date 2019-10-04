md %1
cd %1

md tests
md gol

cd gol
dotnet new console

cd ..
cd tests
dotnet new mstest
dotnet add reference ..\gol\gol.csproj

cd..
code .