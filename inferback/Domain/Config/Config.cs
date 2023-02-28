namespace inferback.Domain.Config;

public class Config {
    public const string PathToScript = 
        "/home/savickij_ivan/RiderProjects/inferback/Scripts/InferScript.sh";
    
    public const string PathToScriptCompare = 
        "/home/savickij_ivan/RiderProjects/inferback/Scripts/InferScriptCompare.sh";
    
    public const string PathToScriptCompareWithFlags = 
        "/home/savickij_ivan/RiderProjects/inferback/Scripts/InferScriptCompareWithFlags.sh";
    
    public const string CurrentFile = 
        "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/report.json";
    
    public const string PreviousFile = 
        "/home/savickij_ivan/RiderProjects/inferback/previous.json";

    public const string ReportInferRun = 
        "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/report.json";

    public const string ReportInferReportdiffPreexisting = 
        "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/differential/preexisting.json";

    public const string ReportInferReportdiffIntroduced = 
        "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/differential/introduced.json";

    public const string ReportInferReportdiffFixed = 
        "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/differential/fixed.json";

    public const string FileNameBash = "/bin/bash";
}
