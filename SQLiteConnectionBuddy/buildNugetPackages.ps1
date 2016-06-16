rm *.nupkg
nuget pack .\SQLiteConnectionBuddy.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push *.nupkg