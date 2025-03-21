using Newtonsoft.Json;

namespace PrescriberSystem;

public class Case
{
    private DateTime _caseTime = DateTime.Now;
    private string _symptom;
    private Prescription _prescription;
    [JsonConstructor]
    public Case(string symptom, Prescription prescription)
    {
        Symptom = symptom;
        Prescription = prescription;
    }
    public string Symptom
    {
        get => _symptom;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 100)
                throw new ArgumentException("Invalid symptom. Symptom must be between 1 and 100 characters.");
            _symptom = value;
        }
    }
    public Prescription Prescription
    {
        get => _prescription;
        set => _prescription = value ?? throw new ArgumentNullException(nameof(Prescription), "Prescription cannot be null.");
    }
    public DateTime CaseTime => _caseTime;
}