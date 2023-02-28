using System.Diagnostics;
using inferback.DAL.Interfaces;
using inferback.Domain.Config;
using inferback.Domain.Entity;
using inferback.Domain.Enum;
using inferback.Domain.Response;
using inferback.Service.Interfaces;
using InferTest;
using Newtonsoft.Json;

namespace inferback.Service.Implementations;

public class DescriptionService : IDescriptionService {
    private readonly IDescriptionRepository _descriptionRepository;

    public DescriptionService(IDescriptionRepository descriptionRepository) {
        _descriptionRepository = descriptionRepository;
    }
    
    public async Task<IBaseResponse<IEnumerable<Description>>> GetDescriptions() {
        var baseResponse = new BaseResponse<IEnumerable<Description>>();

        try {
            var descriptions = await _descriptionRepository.Select();

            if (descriptions.Count == 0) {
                baseResponse.Result = "Get descriptions. Descriptions did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = descriptions;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<IEnumerable<Description>>() {
                Result = $"[GetDescriptions] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<IEnumerable<Description>>> GetDescriptionsByNameAndReportId(string name, int id) {
        var baseResponse = new BaseResponse<IEnumerable<Description>>();

        try {
            var descriptions = 
                await _descriptionRepository.SelectByNameAndReportId(name, id);

            if (descriptions.Count == 0) {
                baseResponse.Result = 
                    "Get descriptions by name and report id. Descriptions did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = descriptions;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<IEnumerable<Description>>() {
                Result = $"[GetDescriptions] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<Description>>> GetDescriptionsOfReport(int id) {
        var baseResponse = new BaseResponse<IEnumerable<Description>>();

        try {
            var descriptions = 
                await _descriptionRepository.SelectDescriptionsOfReport(id);

            if (descriptions.Count == 0) {
                baseResponse.Result = 
                    "Get descriptions of report. Descriptions did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = descriptions;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<IEnumerable<Description>>() {
                Result = $"[GetDescriptionsOfReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> DeleteDescription(int id) {
        var baseResponse = new BaseResponse<bool>();

        try {
            var description = await _descriptionRepository.Get(id);

            if (description == null) {
                baseResponse.Result = "Description does not exist";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _descriptionRepository.Delete(description);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<bool>() {
                Result = $"[DeleteDescription] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Description>> CreateDescription(Script script, int id) {
        var baseResponse = new BaseResponse<Description>();
    
        try {
            var newScript = new Script() {
                command = script.command,
                flags = script.flags,
                path = script.path,
            };

            RunBashCommand(newScript);

            Thread.Sleep(5000);

            if (script.command == "infer-run") {
                var descriptions = JsonConvert.DeserializeObject<List<Description>>(
                    File.ReadAllText(Config.ReportInferRun)
                );

                if (descriptions.Count == 0) {
                    var newDescription = new Description() {
                        name = "Infer-run",
                        bug_type = "No issues found",
                        severity = "Analized successfully",
                        qualifier = "Nothing",
                        line = 0,
                        column = 0,
                        file = script.path,
                        reportId = id,
                    };

                    await _descriptionRepository.Create(newDescription);
                } else {
                    foreach (var description in descriptions) {
                        var newDescription = new Description() {
                            name = "Infer-run",
                            bug_type = description.bug_type,
                            severity = description.severity,
                            qualifier = description.qualifier,
                            line = description.line,
                            column = description.column,
                            file = description.file,
                            reportId = id,
                        };

                        if (newDescription == null) {
                            baseResponse.Result = "Description did not add";
                            baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                            return baseResponse;
                        }

                        await _descriptionRepository.Create(newDescription);
                    }
                }
            } else {
                var descriptions = JsonConvert.DeserializeObject<List<Description>>(
                    File.ReadAllText(Config.ReportInferReportdiffPreexisting)
                );

                if (descriptions.Count == 0) {
                    var newDescription = new Description() {
                        name = "Infer-reportdiff. Preexisting.json",
                        bug_type = "There are not identical issues",
                        severity = "Compared successfully",
                        qualifier = "Nothing",
                        line = 0,
                        column = 0,
                        file = script.path,
                        reportId = id,
                    };

                    await _descriptionRepository.Create(newDescription);
                } else {
                    foreach (var description in descriptions) {
                        var newDescription = new Description() {
                            name = "Infer-reportdiff. Preexisting.json",
                            bug_type = description.bug_type,
                            severity = description.severity,
                            qualifier = description.qualifier,
                            line = description.line,
                            column = description.column,
                            file = description.file,
                            reportId = id,
                        };

                        if (newDescription == null) {
                            baseResponse.Result = "Description did not add";
                            baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                            return baseResponse;
                        }

                        await _descriptionRepository.Create(newDescription);
                    }
                }

                descriptions = JsonConvert.DeserializeObject<List<Description>>(
                    File.ReadAllText(Config.ReportInferReportdiffFixed)
                );
                
                if (descriptions.Count == 0) {
                    var newDescription = new Description() {
                        name = "Infer-reportdiff. Fixed.json",
                        bug_type = "There are not issues in the previous file.",
                        severity = "Compared successfully",
                        qualifier = "Nothing",
                        line = 0,
                        column = 0,
                        file = script.path,
                        reportId = id,
                    };

                    await _descriptionRepository.Create(newDescription);
                } else {
                    foreach (var description in descriptions) {
                        var newDescription = new Description() {
                            name = "Infer-reportdiff. Fixed.json",
                            bug_type = description.bug_type,
                            severity = description.severity,
                            qualifier = description.qualifier,
                            line = description.line,
                            column = description.column,
                            file = description.file,
                            reportId = id,
                        };

                        if (newDescription == null) {
                            baseResponse.Result = "Description did not add";
                            baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                            return baseResponse;
                        }

                        await _descriptionRepository.Create(newDescription);
                    }
                }
                
                descriptions = JsonConvert.DeserializeObject<List<Description>>(
                    File.ReadAllText(Config.ReportInferReportdiffIntroduced)
                );
                
                if (descriptions.Count == 0) {
                    var newDescription = new Description() {
                        name = "Infer-reportdiff. Introduced.json",
                        bug_type = "There are not issues in the current file.",
                        severity = "Compared successfully",
                        qualifier = "Nothing",
                        line = 0,
                        column = 0,
                        file = script.path,
                        reportId = id,
                    };

                    await _descriptionRepository.Create(newDescription);
                } else {
                    foreach (var description in descriptions) {
                        var newDescription = new Description() {
                            name = "Infer-reportdiff. Introduced.json",
                            bug_type = description.bug_type,
                            severity = description.severity,
                            qualifier = description.qualifier,
                            line = description.line,
                            column = description.column,
                            file = description.file,
                            reportId = id,
                        };

                        if (newDescription == null) {
                            baseResponse.Result = "Description did not add";
                            baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                            return baseResponse;
                        }

                        await _descriptionRepository.Create(newDescription);
                    }
                }
            }

            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<Description>() {
                Result = $"[CreateDescription] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    private void RunBashCommand(Script script) {
        var process = new Process();

        if (script.command == "infer-run") {
            process.StartInfo = new ProcessStartInfo() {
                FileName = Config.FileNameBash,
                Arguments = $"{Config.PathToScript} " +
                            $"{script.command} " +
                            $"{script.flags} " +
                            $"{script.path}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        } else
            process.StartInfo = script switch {
                { command: "infer-reportdiff", flags: "" } => new ProcessStartInfo() {
                    FileName = Config.FileNameBash,
                    Arguments = $"{Config.PathToScriptCompare} " +
                                $"{script.command} " + 
                                $"{Config.CurrentFile} " + 
                                $"{Config.PreviousFile}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
                { command: "infer-reportdiff", flags: "--cost" } or { command: "infer-reportdiff", flags: "--pulse" } =>
                    new ProcessStartInfo() {
                        FileName = Config.FileNameBash,
                        Arguments = $"{Config.PathToScriptCompareWithFlags} " + 
                                    $"{script.command} " +
                                    $"{Config.CurrentFile} " + 
                                    $"{Config.PreviousFile} " + 
                                    $"{script.flags}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    },
                _ => process.StartInfo
            };

        process.Start();
    }
}
