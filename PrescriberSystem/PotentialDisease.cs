namespace PrescriberSystem;

public class PotentialDisease(Prescription prescription)
{
    private List<Delegate> _diagnosticCriteria = new();
    private Prescription _prescription = prescription;
    public void AddDiagnosticCriteria<T>(Predicate<T> criteria)
    {
        if (!_diagnosticCriteria.Contains(criteria))
            _diagnosticCriteria.Add(criteria);
    }
    public void RemoveDiagnosticCriteria<T>(Predicate<T> criteria)
    {
        if (_diagnosticCriteria.Contains(criteria))
            _diagnosticCriteria.Remove(criteria);
    }

    public Prescription? Diagnostic(Patient patient, string symptoms)
    {
        var allCriteriaMet = _diagnosticCriteria.All(criteria =>
        {
            return criteria switch
            {
                Predicate<string> symptomsPredicate => symptomsPredicate(symptoms),
                Predicate<Patient> patientPredicate => patientPredicate(patient),
                _ => false
            };
        });
        return allCriteriaMet ? _prescription : null;
    }
}