using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
namespace AutoFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCollection = new List<Datacollection>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCollection.Add(dtTable);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCollection
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //private static DataTable ExcelToDataTable(string fileName) {

        //    FileStream filestream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        //    IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(filestream);
        //    excelDataReader.IsFirstRowAsColumnNames = true;
        //    DataSet result = excelDataReader.AsDataSet();
        //    DataTableCollection table = result.Tables;
        //    DataTable resultTable = table[0];
        //    return resultTable;
        //}
        private static DataTable ExcelToDataTable(string fileName)
        {
            using (var filestream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(filestream))
                {
                    var result = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table[0];
                    return resultTable;
                }
            }

        }
    }
    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
