#load nuget:?package=Cake.Recipe&version=2.1.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./Source",
    title: "Anori.Extensions",
    repositoryOwner: "anorisoft",
    repositoryName: "Anori.Extensions",
    appVeyorAccountName: "anorisoft",
	shouldGenerateDocumentation: false,
    shouldRunDupFinder: false,
	nuspecFilePath: "./Source/Anori.Extensions.nuspec");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    buildMSBuildToolVersion: MSBuildToolVersion.VS2019);

Build.RunDotNetCore();
