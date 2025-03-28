using PrescriberSystem.ExportFiles;

namespace PrescriberSystem;

public class PrescriberSystemFacade
{
    private PatientDatabase _patientDatabase = new();
    private Prescriber _prescriber;
    public PrescriberSystemFacade() => _prescriber = new Prescriber(_patientDatabase);
    public void Diagnose(string patientJson, string patientDatabaseFileName, string patientName, string symptoms, string exportFileName, IExportFile exportedType)
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

    private void SaveToFile(Patient patient, string fileName, IExportFile exportedType)
    {
        var path = $"C:/Users/abehs/source/repos/abehsiao98/PrescriberSystem/{fileName}";
        exportedType.Export(patient, path);
    }
}