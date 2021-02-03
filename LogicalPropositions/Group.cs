using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalPropositions
{
    class Group
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfOnes">How many ones in the group</param>
        /// <param name="firstRow">The first row in the group</param>
        public Group(int numberOfOnes, Row firstRow)
        {
            NumberOfOnes = numberOfOnes;
            Rows = new List<Row>();
            Rows.Add(firstRow);
        }

        public Group(int numberOfOnes, List<Row> rows)
        {
            NumberOfOnes = numberOfOnes;
            Rows = rows;
        }

        /// <summary>
        /// Property for the number of ones in the group
        /// </summary>
        public int NumberOfOnes { get; set; }

        /// <summary>
        /// Property for the list of rows
        /// </summary>
        public List<Row> Rows { get; set; }
    }
}
