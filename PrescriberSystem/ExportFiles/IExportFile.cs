namespace PrescriberSystem.ExportFiles;

public interface IExportFile
{
    void Export(Patient patient, string path);
}