using System.IO;
// using System.Data;

namespace DesignPatterns.FactoryPattern.Example
{
    public class CsvReader : IFileReader<System.Data.DataTable>
    {
        public System.Data.DataTable csvDataTable;

        public System.Data.DataTable ReadFile(string name)
        {
            // ReadFile

            return ParseCsvFileToDataTable(name);
        }

        private System.Data.DataTable ParseCsvFileToDataTable(string name) 
        {
            return new System.Data.DataTable(name);
        }
    }
}