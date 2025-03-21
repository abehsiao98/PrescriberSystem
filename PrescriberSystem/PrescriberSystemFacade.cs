using PrescriberSystem.ExportFiles;

namespace PrescriberSystem;

public class PrescriberSystemFacade
{
    private PatientDatabase _patientDatabase = new();
    private Prescriber _prescriber;
    public PrescriberSystemFacade() => _prescriber = new Prescriber(_patientDatabase);
    public void Diagnose(string patientJson, string patientDatabaseFileName, string patientName, string symptoms, string exportFileName, string exportedType)
    {
        if (_patientDatabase.IsDataBaseInit())
            _patientDatabase.InitDatabase();
        _patientDatabase.AddPatients(patientJson);

        var id = _patientDatabase.GetPatientIdByName(patientName);
        var prescription = _prescriber.Diagnose(id, symptoms, patientDatabaseFileName);
        var patient = _patientDatabase.GetPatientById(id);
        SaveToFile(patient, exportFileName, exportedType);
    }

    public void AddPotentialDisease(string name, PotentialDisease potentialDisease) => _prescriber.AddPotentialDisease(name, potentialDisease);

    private void SaveToFile(Patient patient, string fileName, string exportedType)
    {
        var path = $"C:/Users/abehs/source/repos/abehsiao98/PrescriberSystem/{fileName}";
        var action = exportedType.ToLower() switch
        {
            "json" => (Action)(() => { new ExportJson().Export(patient, path); }),
            "csv" => (Action)(() => { new ExportCsv().Export(patient, path); }),
            _ => () => { }
        };
        action();
    }
}