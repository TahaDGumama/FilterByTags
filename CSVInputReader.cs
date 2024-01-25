using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace FilterByTags
{
    internal class CSVInputReader : IInputReader
    {
        public bool ReadFirstRowAsHeader { get; set; }

        public CSVInputReader() { }

        public DataTable Read(string file)
        {            
            using var parser = new TextFieldParser(file)
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new string[] { "," }
            };
            try
            {
                var table = new DataTable();

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields() ?? new string[0];
                    if (table.Columns.Count == 0)
                    {
                        table.Columns.AddRange(fields
                            .Select((f, idx) => this.ReadFirstRowAsHeader ?
                                            new DataColumn(f, typeof(string)) :
                                            new DataColumn($"Col_{idx}", typeof(string)))
                            .ToArray());

                        if (this.ReadFirstRowAsHeader) continue;
                    }

                    var row = table.NewRow();
                    row.ItemArray = fields;
                    table.Rows.Add(row);
                }

                return table;
            }
            finally
            {
                parser.Close();
            }
        }
    }
}
