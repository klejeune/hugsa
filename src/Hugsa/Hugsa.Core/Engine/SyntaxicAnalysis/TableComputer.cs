using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class TableComputer {
        public int[][] Compute(int wordCount, int funcCount) {
            var list = new List<int[]>();

            var lastRows = new List<int[]>();
            var firstRow = Enumerable.Repeat(1, funcCount).ToArray();
            firstRow[0] = wordCount - funcCount + 1;
            lastRows.Add(firstRow);

            while (lastRows.Any() && lastRows.First()[0] >= 1) {
                list.AddRange(lastRows);
                
                var oldLastRows = lastRows;
                lastRows = new List<int[]>();
                foreach (var lastRow in oldLastRows) {
                    for (int placeHolder = 1; placeHolder < funcCount; placeHolder++) {
                        var newRow = lastRow.ToArray();
                        newRow[0]--;
                        newRow[placeHolder]++;
                        lastRows.Add(newRow);
                    }
                }
            }

            return list.ToArray();
        }

    }
}
