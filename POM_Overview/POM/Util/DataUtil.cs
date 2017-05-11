using ExcelReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Util
{
    public class DataUtil
    {
        public static object[] getData(ExcelReaderFile xls, string sheetName)
        {

            int rows = xls.getRowCount(sheetName);
            int cols = xls.getColumnCount(sheetName);

            object[][] data = new object[rows - 1][];


            for (int rNum = 2; rNum <= rows; rNum++)
            {
                data[rNum - 2] = new object[cols];
                for (int cNum = 0; cNum < cols; cNum++)
                {
                    string d = xls.getCellData(sheetName, cNum, rNum);
                    data[rNum - 2][cNum] = d;
                }
            }
            return data;
        }

        public static bool isTestRunnable(ExcelReaderFile xls, string testCaseName)
        {
            int rows = xls.getRowCount("TestCases");
            for (int rNum = 2; rNum <= rows; rNum++)
            {
                string currentTestCaseName = xls.getCellData("TestCases", "TCID", rNum);
                if (currentTestCaseName.Equals(testCaseName))
                {
                    string runmode = xls.getCellData("TestCases", "Runmode", rNum);
                    if (runmode.Equals("N"))
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }

    }
}
