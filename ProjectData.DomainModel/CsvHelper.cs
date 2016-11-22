using System;
using System.Data;
using System.IO;
using System.Text;

namespace ProjectData.DomainModel
{
    public class CsvHelper
    {
        private char[] SplitChar
        {
            get { return new[] {'\t'}; }
        }

        public string ExportDataToCsv(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Columns.Count == 0 || dataTable.Rows.Count == 0)
            {
                return string.Empty;
            }

            var csvPath = AppDomain.CurrentDomain.BaseDirectory + "TempFiles\\";
            var fileName = Guid.NewGuid() + ".csv";
            if (!Directory.Exists(csvPath))
            {
                Directory.CreateDirectory(csvPath);
            }

            using (var writer = new StreamWriter(csvPath + fileName, false, Encoding.Unicode))
            {
                var column = CreateColumn(dataTable);
                writer.WriteLine(column);

                foreach (DataRow row in dataTable.Rows)
                {
                    var line = CreateLine(row);
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
            return @"TempFiles\" + fileName;
        }

        private string CreateLine(DataRow row)
        {
            var count = row.ItemArray.Length;
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    sb.AppendFormat("{0}", row[i].ToString().Replace(SplitChar[0].ToString(), ""));
                }
                else
                {
                    sb.AppendFormat("{0}{1}", row[i].ToString().Replace(SplitChar[0].ToString(), ""), SplitChar[0]);
                }
            }

            return sb.ToString();
        }

        private string CreateColumn(DataTable dataTable)
        {
            var count = dataTable.Columns.Count;
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    sb.AppendFormat("{0}", dataTable.Columns[i].ColumnName);
                }
                else
                {
                    sb.AppendFormat("{0}{1}", dataTable.Columns[i].ColumnName, SplitChar[0]);
                }
            }

            return sb.ToString();
        }
    }
}