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
	shouldPublishNuGet: true,                           
    shouldGenerateDocumentation: false,
    shouldRunDupFinder: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    buildMSBuildToolVersion: MSBuildToolVersion.VS2019,
    dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Reporting.Generic.Tests/*.cs", BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Reporting.Generic/LitJson/*.cs" },
    testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Cake.Issues]* -[Cake.Issues.Testing]* -[Cake.Issues.Reporting]* -[Cake.Issues.Reporting.Generic]LitJson.* -[Shouldly]* -[HtmlAgilityPack]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
