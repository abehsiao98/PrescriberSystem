using PrescriberSystem;
using PrescriberSystem.Enums;
using PrescriberSystem.ExportFiles;


//Create COVID-19
var covidPrescription = new Prescription("清冠一號", "新冠肺炎（專業學名：COVID-19）", new() { "清冠一號" }, "將相關藥材裝入茶包裡，使用500 mL 溫、熱水沖泡悶煮1~3 分鐘後即可飲用。");
var covidPotentialDisease = new PotentialDisease(covidPrescription);
covidPotentialDisease.AddDiagnosticCriteria<string>(content => content.Contains("打噴嚏"));
covidPotentialDisease.AddDiagnosticCriteria<string>(content => content.Contains("咳嗽"));
covidPotentialDisease.AddDiagnosticCriteria<string>(content => content.Contains("頭痛"));
//Create Attractive
var attractivePrescription = new Prescription("青春抑制劑", "有人想你了 (專業學名：Attractive)", new() { "假鬢角", "惡臭味" }, "把假鬢角黏在臉的兩側，讓自己異性緣差一點，自然就不會有人想妳了。");
var attractivePotentialDisease = new PotentialDisease(attractivePrescription);
attractivePotentialDisease.AddDiagnosticCriteria<Patient>(patient => patient.Age == 18 && patient.Gender == Gender.Female);
attractivePotentialDisease.AddDiagnosticCriteria<string>(content => content.Contains("打噴嚏"));
//Create SleepApneaSyndrome
var sleepApneaSyndromePrescription = new Prescription("打呼抑制劑", "睡眠呼吸中止症（專業學名：SleepApneaSyndrome）", new() { "一捲膠帶" }, "睡覺時，撕下兩塊膠帶，將兩塊膠帶交錯黏在關閉的嘴巴上，就不會打呼了。");
var sleepApneaSyndromePotentialDisease = new PotentialDisease(sleepApneaSyndromePrescription);
sleepApneaSyndromePotentialDisease.AddDiagnosticCriteria<Patient>(patient => patient.Weight / Math.Pow((patient.Height / 100), 2) > 26);
sleepApneaSyndromePotentialDisease.AddDiagnosticCriteria<string>(content => content.Contains("打呼"));


var facade = new PrescriberSystemFacade();
facade.AddPotentialDisease("COVID-19", covidPotentialDisease);
facade.AddPotentialDisease("Attractive", attractivePotentialDisease);
facade.AddPotentialDisease("SleepApneaSyndrome", sleepApneaSyndromePotentialDisease);

var patientJson = @"[{'Id':'A123456789','Name':'Abe','Gender':1,'Age':18,'Height':174,'Weight':80}]";
facade.Diagnose(patientJson, "DiagnosticRules.txt", "Abe", "如果病患有打噴嚏、頭痛 (Headache) 和咳嗽 (Cough)等症狀的話", "Test.csv", new ExportCsv());

Console.ReadLine();