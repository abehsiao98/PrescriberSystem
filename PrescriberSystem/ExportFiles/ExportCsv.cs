using System.Text;

namespace PrescriberSystem.ExportFiles;

public class ExportCsv : IExportFile
{
    public void Export(Patient patient, string path)
    {
        var sb = new StringBuilder();
        WriteStringBuilderToCsv(patient, sb);
        File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
    }

    private void WriteStringBuilderToCsv(object obj, StringBuilder sb, string prefix = "")
    {
        if (obj == null) return;
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            if (value != null)
            {
                if (value is IEnumerable<object> list)
                {
                    foreach (var item in list)
                    {
                        if (item.GetType().IsPrimitive || item.GetType() == typeof(string))
                            sb.AppendLine($"{prefix}{property.Name},{item}");
                        else
                            WriteStringBuilderToCsv(item, sb, $"{prefix}{property.Name}.");
                    }
                }
                else if (value.GetType().IsPrimitive || value.GetType() == typeof(string) || value.GetType() == typeof(DateTime))
                    sb.AppendLine($"{prefix}{property.Name},{value}");
                else
                    WriteStringBuilderToCsv(value, sb, $"{prefix}{property.Name}.");
            }
        }
    }
}