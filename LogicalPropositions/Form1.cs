using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicalPropositions
{   
    public partial class Form1 : Form
    {
        //Static values used in the whole solution
        public static List<char> validPrepositions = new List<char>()
        {
            '>',
            '=',
            '&',
            '|',
        };
        public static List<char> letters;
        public static string inOrderTraversal = "";
        public static string preOrderTraversal = "";

        private PrepositionTree prepostionTree;
        private bool treeGenerated = false;


        public Form1()
        {
            InitializeComponent();
            InitializeLetters();

            prepostionTree = new PrepositionTree();
        }

        /// <summary>
        /// Used in order for the test to work
        /// </summary>
        public static void InitializeLetters()
        {
            letters = new List<char>();

            for (int i = 65; i <= 90; i++)
            {
                letters.Add((char)i);
            }

            for (int i = 97; i <= 122; i++)
            {
                letters.Add((char)i);
            }
        }

        private void btnVariables_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            prepostionTree.InOrderTraversal();   
            List<char> bfs = prepostionTree.BreadthFirstSearchVariables();
            string b = "";

            foreach (char c in bfs)
            {
                b += c;
            }

            lbVariables.Text = b;
        }

        private void btnGenerateTree_Click(object sender, EventArgs e)
        {
            if (treeGenerated)
            {
                DeletTree();
            }

            GenerateTree();
        }

        private void DeletTree()
        {
            prepostionTree = new PrepositionTree();
        }

        private void tbLogicalPrepostion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (treeGenerated)
                {
                    DeletTree();
                }

                GenerateTree();
            }
        }

        private void btnTruthTable_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            if (prepostionTree != null)
            {
                prepostionTree.CreateTruthTable();
                ShowTruthTable(prepostionTree.TruthTable, dgvTruthTable);
                btnSimplifiyTruthTable.Enabled = true;
                dgvSimplifiedTable.Enabled = true;
                btnDisjunctiveFrom.Enabled = true;
                lbDisjunctiveForm.Enabled = true;
            }
        }

        private void ShowTruthTable(List<TruthTableColumn> truthTable, DataGridView dgvTable)
        {
            dgvTable.Rows.Clear();
            dgvTable.Refresh();
            dgvTable.ColumnCount = truthTable.Count;

            for (int i = 0; i < truthTable[truthTable.Count - 1].Values.Count; i++)
            {
                string[] row = new string[truthTable[truthTable.Count - 1].Values.Count];

                for (int j = 0; j < truthTable.Count; j++)
                {
                    if (i == 0)
                    {
                        if (truthTable[j].Variable != '-')
                        {
                            dgvTable.Columns[j].Name = truthTable[j].Variable.ToString();
                        }
                        else
                        {
                            preOrderTraversal = "";
                            prepostionTree.PreOrderTraversal();
                            dgvTable.Columns[j].Name = preOrderTraversal;
                        }
                    }

                    row[j] = truthTable[j].Values[i].ToString();
                }

                dgvTable.Rows.Add(row);
            }
        }

        private void btnDisjunctiveFrom_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            lbDisjunctiveForm.UseMnemonic = false;
            lbDisjunctiveForm.Text = prepostionTree.GetDisjunctiveForm(false);
        }

        private void btnSimplifiyTruthTable_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            if (prepostionTree != null)
            {
                prepostionTree.SimplifyThurthTable();
                ShowTruthTable(prepostionTree.SimplifiedTruthTable, dgvSimplifiedTable);
                btnSimplifiedDisjunctive.Enabled = true;
                lbSimplifiyDisjunctiveForm.Enabled = true;
            }
        }

        private void btnNandifyFrom_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            lbNandifyForm.Text = prepostionTree.GetNandifyForm();
        }

        private void btnSimplifiedDisjunctive_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            lbSimplifiyDisjunctiveForm.UseMnemonic = false;
            lbSimplifiyDisjunctiveForm.Text = prepostionTree.GetDisjunctiveForm(true);
        }

        private void GenerateTree()
        {
            lbError.Text = "";
            char[] charsToTrim = { '(', ')', ' ', ',' };
            string logicalPreposition = tbLogicalPrepostion.Text;

            foreach (char c in charsToTrim)
            {
                logicalPreposition = logicalPreposition.Replace(c.ToString(), string.Empty);
            }

            try
            {
                foreach (char c in logicalPreposition)
                {
                    prepostionTree.Insert(c);
                }

                pnControlls.Show();
                treeGenerated = true;
            }
            catch (Exception ex)
            {
                if (ex is WrongInputException || ex is StackOverflowException)
                {
                    lbError.Text = "Wrong input";
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
