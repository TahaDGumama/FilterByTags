using System.Data;

namespace FilterByTags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new CSVInputReader() { ReadFirstRowAsHeader = true };
            var table = reader.Read("./books.csv");

            // TODO: Your code here

            // Load tag list from taglist.txt
            var tagList = File.ReadAllLines("taglist.txt").Select(tag => tag.Split(",")).First().ToList();
            var filteredBooks = FilterBooksByTag(table, tagList);

            // Store the output to a text file
            StoreOutputToFile(filteredBooks, "Taha.txt");
        }

        static DataTable FilterBooksByTag(DataTable booksTable, List<string> tagList)
        {
            var filteredRows = booksTable.AsEnumerable()
                .Where(row =>
                {
                    var bookTags = row.Field<string>("Tags")?
                        .Split(new[] { '"', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(tag => tag.Trim());

                    return bookTags?.Any(bookTag => tagList.Any(tag => bookTag.Contains(tag, StringComparison.OrdinalIgnoreCase))) ?? false;
                })
                .ToList();

            return filteredRows.Any() ? filteredRows.CopyToDataTable() : booksTable.Clone();
        }

        static void StoreOutputToFile(DataTable booksTable, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (DataRow row in booksTable.Rows)
                {
                    writer.WriteLine($"{row["Identifier"]}\t{row["Title"]}");
                }
            }
        }
    }
}