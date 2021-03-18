#load nuget:?package=Cake.Recipe&version=2.2.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./Source",
    solutionFilePath: "./Source/Anori.ExpressionObservers.sln",
    title: "Anori.ExpressionObservers",
    repositoryOwner: "anorisoft",
    repositoryName: "Anori.ExpressionObservers",
    appVeyorAccountName: "anorisoft",
	shouldGenerateDocumentation: false,
    shouldRunDupFinder: false,
    shouldRunCodecov: false,
    shouldRunCoveralls: true,
    shouldRunDotNetCorePack: true,
    resharperSettingsFileName: "AnoriSoft.DotSettings");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    buildMSBuildToolVersion: MSBuildToolVersion.VS2019);

Build.RunDotNetCore();
