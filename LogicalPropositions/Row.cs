using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LogicalPropositions
{
    class Row
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Row()
        {
            Values = new List<int>();
            IsSimplified = false;
        }

        public Row(List<int> values)
        {
            Values = values;
            IsSimplified = false;
        }

        /// <summary>
        /// Property for the row values
        /// </summary>
        public List<int> Values { get; set; }

        /// <summary>
        /// Property that indicates if the row is siplified
        /// </summary>
        public bool IsSimplified { get; set; }
    }
}
