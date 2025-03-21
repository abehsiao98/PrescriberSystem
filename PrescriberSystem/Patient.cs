using PrescriberSystem.Enums;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace PrescriberSystem;

public class Patient
{
    private string _id;
    private string _name;
    private Gender _gender;
    private int _age;
    private float _height;
    private float _weight;
    [JsonConstructor]
    public Patient(string id, string name, Gender gender, int age, float height, float weight)
    {
        Id = id;
        Name = name;
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        Case = new List<Case>();
    }
    public string Id
    {
        get => _id;
        set
        {
            if (!Regex.IsMatch(value, "^[A-Z][0-9]{9}$"))
                throw new ArgumentException("Invalid ID. ID must start with a capital letter followed by 9 digits.");
            _id = value;
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            if (value.Length < 1 || value.Length > 30 || !Regex.IsMatch(value, "^[a-zA-Z]+$"))
                throw new ArgumentException("Invalid name. Name must be between 1 and 30 characters and only contain letters.");
            _name = value;
        }
    }
    public Gender Gender
    {
        get => _gender;
        set
        {
            if (value != Gender.Male && value != Gender.Female)
                throw new ArgumentException("Invalid gender. Gender must be either Male or Female.");
            _gender = value;
        }
    }
    public int Age
    {
        get => _age;
        set
        {
            if (value < 1 || value > 180)
                throw new ArgumentOutOfRangeException("Invalid age. Age must be between 1 and 180.");
            _age = value;
        }
    }
    public float Height
    {
        get => _height;
        set
        {
            if (value < 1 || value > 500)
                throw new ArgumentOutOfRangeException("Invalid height. Height must be between 1 and 500 cm.");
            _height = value;
        }
    }
    public float Weight
    {
        get => _weight;
        set
        {
            if (value < 1 || value > 500)
                throw new ArgumentOutOfRangeException("Invalid weight. Weight must be between 1 and 500 kg.");
            _weight = value;
        }
    }
    public List<Case> Case { get; private set; } = new();
    public void AddCase(Case patientCase) => Case.Add(patientCase);
}