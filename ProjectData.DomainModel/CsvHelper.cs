using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectData.DomainModel
{
    public class CsvHelper
    {
        public string ExportDataToCSV(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Columns.Count == 0 || dataTable.Rows.Count == 0)
            {
                return string.Empty;
            }

            string csvPath = AppDomain.CurrentDomain.BaseDirectory + "TempFiles\\";
            string fileName = Guid.NewGuid().ToString() + ".csv";
            if (!System.IO.Directory.Exists(csvPath))
            {
                System.IO.Directory.CreateDirectory(csvPath);
            }

            using (StreamWriter writer = new StreamWriter(csvPath + fileName, false, System.Text.UnicodeEncoding.Unicode))
            {
                string column = string.Empty;
                column = CreateColumn(dataTable);
                writer.WriteLine(column);

                string line = string.Empty;
                foreach (DataRow row in dataTable.Rows)
                {
                    line = CreateLine(row);
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
            return @"TempFiles\" + fileName;
        }

        private string CreateLine(DataRow row)
        {
            int count = row.ItemArray.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
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
            int count = dataTable.Columns.Count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
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

        private char[] SplitChar
        {
            get
            {
                return new char[] { '\t' };
            }
        }
    }
}
