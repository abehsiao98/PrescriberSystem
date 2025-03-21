using Newtonsoft.Json;
using System.Text;

namespace PrescriberSystem;

public class PatientDatabase
{
    private List<Patient> _patients = new();
    public void AddPatients(string json)
    {
        var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
        _patients.AddRange(patients);
    }
    public void InitDatabase() => _patients.Clear();
    public bool IsDataBaseInit() => _patients.Any();
    public Patient? GetPatientById(string id) => _patients.FirstOrDefault(p => p.Id == id);
    public string? GetPatientIdByName(string name) => _patients.FirstOrDefault(p => p.Name == name)?.Id;
}