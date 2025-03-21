namespace PrescriberSystem;

public class Prescriber(PatientDatabase patientDatabase)
{
    private PatientDatabase _patientDatabase = patientDatabase;
    private readonly object _lock = new();
    private Dictionary<string, PotentialDisease> _potentialDiseases = new();

    public Prescription? Diagnose(string id, string symptoms, string fileName)
    {
        lock (_lock)
        {
            Thread.Sleep(3000);
            var patient = _patientDatabase.GetPatientById(id);
            if (patient == null)
                throw new ArgumentException("Patient doesn't exit");
            var filePath = $"C:/Users/abehs/source/repos/abehsiao98/PrescriberSystem/{fileName}";
            var content = File.ReadLines(filePath);
            var prescription = content
                .Select(line => _potentialDiseases.TryGetValue(line, out var potentialDisease) ? potentialDisease.Diagnostic(patient, symptoms) : null)
                .FirstOrDefault(result => result != null);
            patient.AddCase(new(symptoms, prescription));
            return prescription;
        }
    }
    public void AddPotentialDisease(string name, PotentialDisease potentialDisease) => _potentialDiseases.Add(name, potentialDisease);
}