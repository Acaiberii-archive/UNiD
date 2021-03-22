@echo off
echo AutoBuild by AcaiBerii -- 2021
echo Running build - Make sure .NET is installed.
if %1==32 (dotnet build /p:Configuration=Release /p:Platform="Any CPU") else (if %1==64 (dotnet build /p:Configuration=Debug /p:Platform="x64") else (echo "Unknown BuildArg"))