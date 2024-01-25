using System.Data;

namespace FilterByTags
{
    public interface IInputReader
    {
        DataTable Read(string file);
    }
}
