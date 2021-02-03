using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LogicalPropositions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicalPropositions.UnitTests
{
    [TestClass]
    public class PrepositionTreeTests
    {
        [TestMethod]
        public void Insert_GivenSimpleProposition_ValidTreeIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "=|A~B&~A~B";
            string expected = "A|B~=A~&B~";
            Form1.InitializeLetters();
            Form1.inOrderTraversal = "";

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            prepositionTree.InOrderTraversal();

            Assert.AreEqual(expected, Form1.inOrderTraversal);
        }

        [TestMethod]
        public void Insert_GivenComplexProposition_ValidTreeIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "|~>AB&A>CB";
            string expected = "A>B~|A&C>B";
            Form1.InitializeLetters();
            Form1.inOrderTraversal = "";

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            prepositionTree.InOrderTraversal();

            Assert.AreEqual(expected, Form1.inOrderTraversal);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInputException))]
        public void Insert_GivenWrongInput_ExceptionIsTrown()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "=|A~B&~A:B";
            Form1.InitializeLetters();
            Form1.inOrderTraversal = "";

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }
        }

        [TestMethod]
        public void CreateTruthTable_GivenTree_ValidTruthTableIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "||ABC";
            string expected = "01111111";
            string actual;
            Form1.InitializeLetters();
            Form1.inOrderTraversal = "";

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            actual = prepositionTree.CreateTruthTable();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplifyTruthTable_GivenTruthTable_ValidSimplifiedTableIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "|~>AB&A>CB";
            string expected = "10000";
            Form1.InitializeLetters();

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            prepositionTree.CreateTruthTable();
            string actual = prepositionTree.SimplifyThurthTable();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OuputVariables_GivenTree_ReturnCharListWhichContainsNoDublicatesAndSorted()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "||CB|aA";
            string expected = "ABCa";

            //Generating a tree

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            //Getting the variables
            List<char> bfs = prepositionTree.BreadthFirstSearchVariables();
            string variables = "";

            foreach (char c in bfs)
            {
                variables += c;
            }

            //Assert
            Assert.AreEqual(expected, variables);
        }

        [TestMethod]
        public void GenerateDisjunctiveForm_GivenTruthTable_ValidDisjunctiveFormIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "=~AB|A~B";
            string expected, actual;
            Form1.InitializeLetters();

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            expected = prepositionTree.CreateTruthTable();
            string disjunctiveFrom = prepositionTree.GetDisjunctiveForm();
            PrepositionTree disjunctivePrepostionTree = new PrepositionTree();
            foreach (char c in disjunctiveFrom)
            {
                disjunctivePrepostionTree.Insert(c);
            }

            actual = disjunctivePrepostionTree.CreateTruthTable();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateNANDForm_GivenTree_ValidNANDFormIsCreated()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "=~AB|A~B";
            string expected = "%%%%AA%AA%BB%%AAB";
            Form1.InitializeLetters();

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            string actual = prepositionTree.GetNandifyForm();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InOrderTraversel_GivenTree_NodesAreReturnedInRightOrder()
        {
            PrepositionTree prepositionTree = new PrepositionTree();
            string logicalPreposition = "=&~AB|A~B";
            string expected = "A~&B=A|B~";
            Form1.InitializeLetters();
            Form1.inOrderTraversal = "";

            foreach (char c in logicalPreposition)
            {
                prepositionTree.Insert(c);
            }

            prepositionTree.InOrderTraversal();

            Assert.AreEqual(expected, Form1.inOrderTraversal);
        }
    }
}
