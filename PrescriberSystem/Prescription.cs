using Newtonsoft.Json;

namespace PrescriberSystem;

public class Prescription
{
    private string _name;
    private string _potentialDisease;
    private List<string> _medicines = new();
    private string _usage;
    [JsonConstructor]
    public Prescription(string name, string potentialDisease,List<string> medicines, string usage)
    {
        Name = name;
        PotentialDisease = potentialDisease;
        Medicines.AddRange(medicines);
        Usage = usage;
    }
    public string Name
    {
        get => _name;
        set
        {
            if (value.Length < 4 || value.Length > 30)
                throw new ArgumentException("Invalid name. Name must be between 4 and 30 characters.");
            _name = value;
        }
    }
    public string PotentialDisease
    {
        get => _potentialDisease;
        set
        {
            if (value.Length < 3 || value.Length > 100)
                throw new ArgumentException("Invalid potential disease. Potential disease must be between 3 and 100 characters.");
            _potentialDisease = value;
        }
    }
    public List<string> Medicines
    {
        get => _medicines;
        set
        {
            foreach (var medicine in value)
            {
                if (medicine.Length < 3 || medicine.Length > 30)
                    throw new ArgumentException($"Invalid medicine name: '{medicine}'. Medicine names must be between 3 and 30 characters.");
            }
            _medicines = value;
        }
    }
    public string Usage
    {
        get => _usage;
        set
        {
            if (value.Length > 1000)
                throw new ArgumentException("Invalid usage. Usage must be up to 1000 characters.");
            _usage = value;
        }
    }
}