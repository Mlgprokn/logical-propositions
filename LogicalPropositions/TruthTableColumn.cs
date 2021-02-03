using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalPropositions
{
    public class TruthTableColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="variable">Variable for the column</param>
        /// <param name="values">Values in the column</param>
        public TruthTableColumn(char variable, List<int> values)
        {
            Variable = variable;
            Values = values;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="variable">Variable for the column</param>
        /// <param name="firstValue">The first value in the column</param>
        public TruthTableColumn(char variable, int firstValue)
        {
            Variable = variable;
            Values = new List<int>();
            Values.Add(firstValue);
        }

        /// <summary>
        /// Property for the variable of the column
        /// </summary>
        public char Variable { get; set; }

        /// <summary>
        /// Property for the values of the column
        /// </summary>
        public List<int> Values { get; set; }

        /// <summary>
        /// Adds a value to the column
        /// </summary>
        /// <param name="value">The value that is going to be added</param>
        public void AddValue(int value)
        {
            Values.Add(value);
        }
    }
}
