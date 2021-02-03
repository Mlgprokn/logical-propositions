using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicalPropositions
{
    public class TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prepostion">Node prepostion</param>
        public TreeNode(char prepostion, TreeNode parent)
        {
            Data = prepostion;
            Parent = parent;
        }

        /// <summary>
        /// Data stored in the node
        /// </summary>
        public char Data { get; set; }

        /// <summary>
        /// Right child of the node
        /// </summary>
        public TreeNode Parent { get; set; }

        /// <summary>
        /// Right child of the node
        /// </summary>
        public TreeNode RightChild { get; set; }

        /// <summary>
        /// Left child of the node
        /// </summary>
        public TreeNode LeftChild { get; set; }

        /// <summary>
        /// Inserts a prepostion
        /// </summary>
        /// <param name="preposition">Preposition that is inserter</param>
        public void Insert(char preposition)
        {
            if (Form1.letters.Contains(preposition) || Form1.validPrepositions.Contains(preposition) || preposition == '~')
            {
                if (LeftChild == null)
                {
                    LeftChild = new TreeNode(preposition, this);
                }
                else if (LeftChild != null && !LeftChild.IsFilled())
                {
                    LeftChild.Insert(preposition);
                }
                else if (LeftChild.IsFilled())
                {
                    if (RightChild == null)
                    {
                        RightChild = new TreeNode(preposition, this);
                    }
                    else
                    {
                        RightChild.Insert(preposition);
                    }
                }
            }
            else
            {
                throw new WrongInputException();
            }
        }

        /// <summary>
        /// Checks if the branch is filled with variables
        /// </summary>
        /// <returns>Returns a boolean wheter the current branch is filled</returns>
        public bool IsFilled()
        {
            if (Form1.letters.Contains(Data))
            {
                return true;
            }

            if (Form1.validPrepositions.Contains(Data))
            {
                if (LeftChild != null && RightChild != null)
                {
                    return LeftChild.IsFilled() && RightChild.IsFilled();
                }
            }

            if (Data == '~')
            {
                if (LeftChild != null)
                {
                    return LeftChild.IsFilled();
                }
            }

            return false;
        }

        /// <summary>
        /// Generates the truth table results
        /// </summary>
        /// <param name="truthValues">Truth table</param>
        /// <param name="row">Current row</param>
        /// <returns>Boolean with the result of the row</returns>
        public bool GenerateResults(List<TruthTableColumn> truthValues, int row)
        {
            if (Form1.validPrepositions.Contains(Data) || Data == '~')
            {
                if (LeftChild != null && RightChild != null)
                {
                    switch (Data)
                    {
                        case '&':
                            return LeftChild.GenerateResults(truthValues, row) && RightChild.GenerateResults(truthValues, row);
                        case '|':
                            return LeftChild.GenerateResults(truthValues, row) || RightChild.GenerateResults(truthValues, row);
                        case '>':
                            return !LeftChild.GenerateResults(truthValues, row) || RightChild.GenerateResults(truthValues, row);
                        case '=':
                            return LeftChild.GenerateResults(truthValues, row) == RightChild.GenerateResults(truthValues, row);
                    }
                }
                else if (LeftChild != null && RightChild == null && Data == '~')
                {
                    return !LeftChild.GenerateResults(truthValues, row);
                }
            }
            else
            {
                foreach (TruthTableColumn column in truthValues)
                {
                    if (column.Variable == Data)
                    {
                        return column.Values[row] != 0;
                    }
                }
            }

            return false;
        }

        public string Nandify()
        {
            string nandify = "";

            if (Form1.validPrepositions.Contains(Data) || Data == '~')
            {
                if (LeftChild != null && RightChild != null)
                {
                    switch (Data)
                    {
                        case '&':
                            return "%%" + LeftChild.Nandify() + RightChild.Nandify() + "%" + LeftChild.Nandify() + RightChild.Nandify();
                        case '|':
                            return "%%" + LeftChild.Nandify() + LeftChild.Nandify() + "%" + RightChild.Nandify() + RightChild.Nandify();
                        case '>':
                            return "%" + LeftChild.Nandify() + "%" + RightChild.Nandify() + RightChild.Nandify();
                        case '=':
                            return "%%%" + LeftChild.Nandify() + LeftChild.Nandify() + "%" + RightChild.Nandify() + RightChild.Nandify() + "%" +
                                LeftChild.Nandify() + RightChild.Nandify();
                    }
                }
                else if (LeftChild != null && RightChild == null && Data == '~')
                {
                    return "%" + LeftChild.Nandify() + LeftChild.Nandify();
                }
            }
            else
            {
                return Data.ToString();
            }

            return nandify;
        }

        /// <summary>
        /// Returns the nodes using in order traversal algorithum
        /// </summary>
        public void InOrderTraversal()
        {
            if (LeftChild != null)
            {
                LeftChild.InOrderTraversal();
            }

            Form1.inOrderTraversal += Data;

            if (RightChild != null)
            {
                RightChild.InOrderTraversal();
            }
        }


        /// <summary>
        /// Returns the nodes using pre order traversal algorithum
        /// </summary>
        public void PreOrderTraversal()
        {
            Form1.preOrderTraversal += Data;
            if (LeftChild != null)
            {
                LeftChild.PreOrderTraversal();
            }

            if (RightChild != null)
            {
                RightChild.PreOrderTraversal();
            }
        }
    }
}
