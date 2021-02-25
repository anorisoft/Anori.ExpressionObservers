#load nuget:?package=Cake.Recipe&version=2.1.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./Source",
    title: "Anori.ExpressionObservers",
    repositoryOwner: "anorisoft",
    repositoryName: "Anori.ExpressionObservers",
    appVeyorAccountName: "anorisoft",
	shouldGenerateDocumentation: false,
    shouldRunDupFinder: false,
	nuspecFilePath: "Source/Anori.ExpressionObservers.nuspec");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    buildMSBuildToolVersion: MSBuildToolVersion.VS2019);

Build.RunDotNetCore();
