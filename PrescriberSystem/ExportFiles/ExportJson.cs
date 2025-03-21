using Newtonsoft.Json;

namespace PrescriberSystem.ExportFiles;

public class ExportJson : IExportFile
{
    public void Export(Patient patient, string path)
    {
        var json = JsonConvert.SerializeObject(patient);
        File.WriteAllText(path, json);
    }
}