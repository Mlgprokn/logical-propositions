using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace LogicalPropositions
{
    public class PrepositionTree
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PrepositionTree()
        {
            this.Root = null;
        }

        /// <summary>
        /// The root of the tree
        /// </summary>
        public TreeNode Root { get; private set; }

        public List<TruthTableColumn> TruthTable { get; set; }

        public List<TruthTableColumn> SimplifiedTruthTable { get; set; }

        /// <summary>
        /// Inserts prepostion into the tree
        /// </summary>
        /// <param name="preposition">Prepostion inseted in the tree</param>
        public void Insert(char preposition)
        {
            if (this.Root != null)
            {
                this.Root.Insert(preposition);
            }
            else
            {
                this.Root = new TreeNode(preposition, null);
            }
        }

        /// <summary>
        /// Temporary to display the tree
        /// </summary>
        /// <returns></returns>
        public string BreadthFirstSearch()
        {
            string bfs = "";
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();

                if (currentNode == null)
                    continue;

                queue.Enqueue(currentNode.LeftChild);
                queue.Enqueue(currentNode.RightChild);

                bfs += currentNode.Data;
            }

            return bfs;
        }

        /// <summary>
        /// Creates a truth table for the tree
        /// </summary>
        public string CreateTruthTable()
        {
            List<TruthTableColumn> truthTable = new List<TruthTableColumn>();

            //Dictionary<char, List<bool>> truthTable = new Dictionary<char, List<bool>>();
            List<char> variables = BreadthFirstSearchVariables();

            double numberOfRows = Math.Pow(2, variables.Count);

            for (int i = 0; i < variables.Count; i++)
            {
                char variable = variables[i];
                double changeValue = Math.Pow(2, variables.Count - i - 1);
                bool value = false;
                truthTable.Add(new TruthTableColumn(variable, new List<int>()));
                 
                for (int j = 0; j <= numberOfRows - 1; j++)
                {
                    if (j%changeValue == 0)
                    {
                        value = !value;
                    }

                    truthTable[i].AddValue(value ? 1 : 0);
                }
            }

            List<int> results = new List<int>();

            for (int i = 0; i < numberOfRows; i++)
            {
                results.Add(Root.GenerateResults(truthTable, i) ? 1 : 0);
            }

            truthTable.Add(new TruthTableColumn('-', results));

            this.TruthTable = truthTable;
            string hexCode = "";

            for (int i = results.Count - 1; i >= 0; i--)
            {
                hexCode += results[i];
            }

            return hexCode;
        }

        /// <summary>
        /// Simplifies given truthTable
        /// </summary>
        /// <param name="truthTable">The truth table that is going to be simplified</param>
        public string SimplifyThurthTable()
        {
            if (TruthTable == null)
            {
                return null;
            }

            List<TruthTableColumn> truthTable = TruthTable;
            List<TruthTableColumn> simplifiedTruthTable = new List<TruthTableColumn>();
            List<TruthTableColumn> simplifiedColumns = new List<TruthTableColumn>();
            List<Row> rowsToBeSimplified = new List<Row>();

            //Add rows that are going to be simplified
            for (int j = 0; j < truthTable[truthTable.Count - 1].Values.Count; j++)
            {
                if (truthTable[truthTable.Count - 1].Values[j] == 1)
                {
                    Row row = new Row();

                    for (int i = 0; i < truthTable.Count; i++)
                    {
                        if (truthTable[i].Variable != '-')
                        {
                            row.Values.Add(truthTable[i].Values[j]);
                        }
                    }

                    rowsToBeSimplified.Add(row);
                }
            }

            //Add false columns to the final result
            foreach (TruthTableColumn truthTableColumn in truthTable)
            {
                for (int i = 0; i < truthTableColumn.Values.Count; i++)
                {
                    if (truthTable[truthTable.Count - 1].Values[i] == 0)
                    {
                        TruthTableColumn tempColumn = simplifiedTruthTable.Find(c => c.Variable == truthTableColumn.Variable);

                        if (tempColumn != null)
                        {
                            tempColumn.AddValue(truthTableColumn.Values[i]);
                        }
                        else
                        {
                            simplifiedTruthTable.Add(new TruthTableColumn(truthTableColumn.Variable,
                                truthTableColumn.Values[i]));
                        }
                    }
                }
            }

            //Create groups
            List<Group> tempGroups = new List<Group>();

            foreach (Row row in rowsToBeSimplified)
            {
                int oneCounter = 0;

                for (int i = 0; i < row.Values.Count; i++)
                {
                    if (row.Values[i] == 1)
                    {
                        oneCounter++;
                    }
                }

                Group existing = tempGroups.Find(g => g.NumberOfOnes == oneCounter);

                if (existing == null)
                {
                    tempGroups.Add(new Group(oneCounter, row));
                }
                else
                {
                    existing.Rows.Add(row);
                }
            }

            List<Group> orderedGroups = tempGroups.OrderBy(g => g.NumberOfOnes).ToList();
            List<Group> currentGroup;
            List<List<Group>> QMGroups = new List<List<Group>>();
            QMGroups.Add(orderedGroups);
           
            int count = 0;
            while (true)
            {
                if (QMGroups.ElementAtOrDefault(count) == null)
                {
                    break;
                }

                currentGroup = QMGroups[count];
                count++;
                
                for (int i = 0; i < currentGroup.Count - 1; i++)
                {
                    foreach (Row firstRow in currentGroup[i].Rows)
                    {
                        List<Row> newRows = new List<Row>();
                        if (!firstRow.IsSimplified || firstRow.IsSimplified)
                        {
                            foreach (Row secondRow in currentGroup[i + 1].Rows)
                            {
                                if (!secondRow.IsSimplified || secondRow.IsSimplified)
                                {
                                    Row newRow = CompareRows(firstRow, secondRow);
                                    if (newRow != null)
                                    {
                                        newRows.Add(newRow);
                                        QMGroups.Add(new List<Group>());

                                        firstRow.IsSimplified = true;
                                        secondRow.IsSimplified = true;
                                    }
                                }
                            }
                        }

                        if (newRows.Count > 0)
                        {
                            int groupNumberOfOnes = currentGroup[i].NumberOfOnes;
                            int index = QMGroups[count].FindIndex(g => g.NumberOfOnes == groupNumberOfOnes);
                            if (index >= 0)
                            {
                                QMGroups[count][index].Rows.AddRange(newRows);
                            }
                            else
                            {
                                QMGroups[count].Add(new Group(currentGroup[i].NumberOfOnes, newRows));
                            }
                        }
                    }
                }
            }

            List<Row> simplifiedRows = new List<Row>();
            foreach (List<Group> lg in QMGroups)
            {
                foreach (Group group in lg)
                {   
                    foreach (Row row in group.Rows)
                    {
                        if (!row.IsSimplified)
                        {
                            simplifiedRows.Add(row);
                        }
                    }
                }
            }

            //Do a final check if all the rows are simplified corretly
            foreach (Row firstRow in simplifiedRows)
            {
                foreach (Row secondRow in simplifiedRows)
                {
                    if (firstRow != secondRow)
                    {
                        CheckIfRowsAreSiplified(firstRow, secondRow);
                    }
                }
            }

            foreach (Row row in simplifiedRows)
            {
                if (!row.IsSimplified)
                {
                    for (int i = 0; i < row.Values.Count; i++)
                    {
                        simplifiedTruthTable[i].Values.Add(row.Values[i]);
                    }

                    simplifiedTruthTable[row.Values.Count].Values.Add(1);
                }
            }

            SimplifiedTruthTable = simplifiedTruthTable;

            string hexCode = "";

            for (int i = simplifiedTruthTable.Last().Values.Count - 1; i >= 0; i--)
            {
                hexCode += simplifiedTruthTable.Last().Values[i];
            }

            return hexCode;
        }

        private void CheckIfRowsAreSiplified(Row firstRow, Row secondRow)
        {
            int differentValueCounter = 0;
            int differentValuePostition = 0;
            bool[] isSameValue = new bool[firstRow.Values.Count];

            for (int i = 0; i < firstRow.Values.Count; i++)
            {
                isSameValue[i] = firstRow.Values[i] == secondRow.Values[i];
            }

            for (int i = 0; i < isSameValue.Length; i++)
            {
                if (!isSameValue[i])
                {
                    differentValueCounter++;
                    differentValuePostition = i;
                }
            }

            if (differentValueCounter == 1)
            {
                if (firstRow.Values[differentValuePostition] == -1)
                {
                    secondRow.IsSimplified = true;
                }

                if (secondRow.Values[differentValuePostition] == -1)
                {
                    firstRow.IsSimplified = true;
                }
            }
        }

        /// <summary>
        /// Gets the disjuncitve from from the truth table
        /// </summary>
        /// <returns>String with the disjunctive form</returns>
        public string GetDisjunctiveForm(bool isSimplifiedTruthTable)
        {
            List<TruthTableColumn> truthTable = isSimplifiedTruthTable ? SimplifiedTruthTable : TruthTable; 
            string disjunctiveForm = "";

            for (int i = 0; i < truthTable[truthTable.Count - 1].Values.Count; i++)
            {
                if (truthTable[truthTable.Count - 1].Values[i] == 1)
                {
                    if (i != truthTable[truthTable.Count - 1].Values.Count - 2)
                    {
                        disjunctiveForm += "|";
                    }

                    for (int j = 0; j < truthTable.Count; j++)
                    {
                        if (truthTable[j] != truthTable.Last())
                        {
                            if (truthTable[j].Values[i] != -1)
                            {
                                if (j < truthTable.Count - 2)
                                {
                                    disjunctiveForm += "&";
                                }

                                if (truthTable[j].Values[i] == 0)
                                {
                                    disjunctiveForm += "~";
                                }

                                disjunctiveForm += TruthTable[j].Variable;
                            }
                        }
                    }
                }
            }

            Debug.WriteLine(disjunctiveForm);
            return disjunctiveForm;
        }

        /// <summary>
        /// Creade nandify form from the current tree
        /// </summary>
        /// <returns>String with the nandify form</returns>
        public string GetNandifyForm()
        {
            string nandify = Root.Nandify();

            return nandify;
        }

        /// <summary>
        /// Does an in order traversal on the tree
        /// </summary>
        public void InOrderTraversal()
        {
            if (Root != null)
            {
                Root.InOrderTraversal();
            }
        }

        /// <summary>
        /// Does a pre order traversal on the tree
        /// </summary>
        public void PreOrderTraversal()
        {
            if (Root != null)
            {
                Root.PreOrderTraversal();
            }
        }

        /// <summary>
        /// Using breadthfirstsearch for find all variables
        /// </summary>
        /// <returns>Returns a sorted list of all unique variables</returns>
        public List<char> BreadthFirstSearchVariables()
        {
            List<char> bfs = new List<char>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();

                if (currentNode == null)
                    continue;

                queue.Enqueue(currentNode.LeftChild);
                queue.Enqueue(currentNode.RightChild);

                if ((currentNode.Data >= 65 && currentNode.Data <= 90) ||
                    (currentNode.Data >= 97 && currentNode.Data <= 122))
                {
                    bfs.Add(currentNode.Data);
                }
            }
            
            bfs = bfs.Distinct().ToList();
            bfs.Sort();
            return bfs;
        }

        private Row CompareRows(Row firstRow, Row secondRow)
        {
            Row newRow = null; 
            int differentValueCounter = 0;
            int differentValuePostition = 0;
            bool[] isSameValue = new bool[firstRow.Values.Count];

            for (int i = 0; i < firstRow.Values.Count; i++)
            {
                isSameValue[i] = firstRow.Values[i] == secondRow.Values[i];
            }

            for (int i = 0; i < isSameValue.Length; i++)
            {
                if (!isSameValue[i])
                {
                    differentValueCounter++;
                    differentValuePostition = i;
                }
            }

            if (differentValueCounter == 1)
            {
                newRow = new Row(firstRow.Values);
                newRow.Values[differentValuePostition] = -1;
            }

            return newRow;
        }
    }
}
