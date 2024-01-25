using Nuke.Common;
using Nuke.Common.Tooling;

namespace Nuke.Build
{
    internal class Build : NukeBuild
    {
#if NET7_0
        [NuGetPackage(
            packageId: "ReportGenerator",
            packageExecutable: "ReportGenerator.dll",
            Framework = "net7.0",
            Version = "5.2.0"
        )]
#elif NET8_0
        [NuGetPackage(
            packageId: "ReportGenerator",
            packageExecutable: "ReportGenerator.dll",
            Framework = "net8.0",
            Version = "5.2.0"
        )]
#endif
        public Tool ReportGenerator { get; set; }

        public static int Main() => Execute<Build>(x => x.ContinuousIntegration);

        Target ContinuousIntegration =>
            _ =>
                _.Executes(() =>
                {
                    ReportGenerator.Invoke("Hello");
                });
    }
}
