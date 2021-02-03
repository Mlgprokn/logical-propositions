namespace LogicalPropositions
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLogicalPrepostion = new System.Windows.Forms.TextBox();
            this.btnGenerateTree = new System.Windows.Forms.Button();
            this.lbVariables = new System.Windows.Forms.Label();
            this.btnVariables = new System.Windows.Forms.Button();
            this.pnControlls = new System.Windows.Forms.Panel();
            this.btnSimplifiedDisjunctive = new System.Windows.Forms.Button();
            this.lbSimplifiyDisjunctiveForm = new System.Windows.Forms.Label();
            this.btnDisjunctiveFrom = new System.Windows.Forms.Button();
            this.lbDisjunctiveForm = new System.Windows.Forms.Label();
            this.btnNandifyFrom = new System.Windows.Forms.Button();
            this.lbNandifyForm = new System.Windows.Forms.Label();
            this.dgvSimplifiedTable = new System.Windows.Forms.DataGridView();
            this.btnSimplifiyTruthTable = new System.Windows.Forms.Button();
            this.dgvTruthTable = new System.Windows.Forms.DataGridView();
            this.btnTruthTable = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.pnControlls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimplifiedTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruthTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLogicalPrepostion
            // 
            this.tbLogicalPrepostion.Location = new System.Drawing.Point(14, 16);
            this.tbLogicalPrepostion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbLogicalPrepostion.Name = "tbLogicalPrepostion";
            this.tbLogicalPrepostion.Size = new System.Drawing.Size(431, 25);
            this.tbLogicalPrepostion.TabIndex = 2;
            this.tbLogicalPrepostion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogicalPrepostion_KeyPress);
            // 
            // btnGenerateTree
            // 
            this.btnGenerateTree.Location = new System.Drawing.Point(451, 13);
            this.btnGenerateTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerateTree.Name = "btnGenerateTree";
            this.btnGenerateTree.Size = new System.Drawing.Size(159, 30);
            this.btnGenerateTree.TabIndex = 3;
            this.btnGenerateTree.Text = "Generate tree";
            this.btnGenerateTree.UseVisualStyleBackColor = true;
            this.btnGenerateTree.Click += new System.EventHandler(this.btnGenerateTree_Click);
            // 
            // lbVariables
            // 
            this.lbVariables.AutoSize = true;
            this.lbVariables.Location = new System.Drawing.Point(179, 22);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.Size = new System.Drawing.Size(100, 17);
            this.lbVariables.TabIndex = 0;
            this.lbVariables.Text = "                       ";
            // 
            // btnVariables
            // 
            this.btnVariables.Location = new System.Drawing.Point(14, 15);
            this.btnVariables.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(159, 30);
            this.btnVariables.TabIndex = 1;
            this.btnVariables.Text = "Show Variables";
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.btnVariables_Click);
            // 
            // pnControlls
            // 
            this.pnControlls.Controls.Add(this.btnSimplifiedDisjunctive);
            this.pnControlls.Controls.Add(this.lbSimplifiyDisjunctiveForm);
            this.pnControlls.Controls.Add(this.btnDisjunctiveFrom);
            this.pnControlls.Controls.Add(this.lbDisjunctiveForm);
            this.pnControlls.Controls.Add(this.btnNandifyFrom);
            this.pnControlls.Controls.Add(this.lbNandifyForm);
            this.pnControlls.Controls.Add(this.dgvSimplifiedTable);
            this.pnControlls.Controls.Add(this.btnSimplifiyTruthTable);
            this.pnControlls.Controls.Add(this.dgvTruthTable);
            this.pnControlls.Controls.Add(this.btnTruthTable);
            this.pnControlls.Controls.Add(this.btnVariables);
            this.pnControlls.Controls.Add(this.lbVariables);
            this.pnControlls.Location = new System.Drawing.Point(14, 59);
            this.pnControlls.Name = "pnControlls";
            this.pnControlls.Size = new System.Drawing.Size(1182, 338);
            this.pnControlls.TabIndex = 2;
            this.pnControlls.Visible = false;
            // 
            // btnSimplifiedDisjunctive
            // 
            this.btnSimplifiedDisjunctive.Enabled = false;
            this.btnSimplifiedDisjunctive.Location = new System.Drawing.Point(596, 299);
            this.btnSimplifiedDisjunctive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSimplifiedDisjunctive.Name = "btnSimplifiedDisjunctive";
            this.btnSimplifiedDisjunctive.Size = new System.Drawing.Size(159, 30);
            this.btnSimplifiedDisjunctive.TabIndex = 11;
            this.btnSimplifiedDisjunctive.Text = "Disjunctive Form";
            this.btnSimplifiedDisjunctive.UseVisualStyleBackColor = true;
            this.btnSimplifiedDisjunctive.Click += new System.EventHandler(this.btnSimplifiedDisjunctive_Click);
            // 
            // lbSimplifiyDisjunctiveForm
            // 
            this.lbSimplifiyDisjunctiveForm.AutoSize = true;
            this.lbSimplifiyDisjunctiveForm.Enabled = false;
            this.lbSimplifiyDisjunctiveForm.Location = new System.Drawing.Point(761, 306);
            this.lbSimplifiyDisjunctiveForm.Name = "lbSimplifiyDisjunctiveForm";
            this.lbSimplifiyDisjunctiveForm.Size = new System.Drawing.Size(100, 17);
            this.lbSimplifiyDisjunctiveForm.TabIndex = 10;
            this.lbSimplifiyDisjunctiveForm.Text = "                       ";
            // 
            // btnDisjunctiveFrom
            // 
            this.btnDisjunctiveFrom.Enabled = false;
            this.btnDisjunctiveFrom.Location = new System.Drawing.Point(14, 299);
            this.btnDisjunctiveFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisjunctiveFrom.Name = "btnDisjunctiveFrom";
            this.btnDisjunctiveFrom.Size = new System.Drawing.Size(159, 30);
            this.btnDisjunctiveFrom.TabIndex = 9;
            this.btnDisjunctiveFrom.Text = "Disjunctive Form";
            this.btnDisjunctiveFrom.UseVisualStyleBackColor = true;
            this.btnDisjunctiveFrom.Click += new System.EventHandler(this.btnDisjunctiveFrom_Click);
            // 
            // lbDisjunctiveForm
            // 
            this.lbDisjunctiveForm.AutoSize = true;
            this.lbDisjunctiveForm.Enabled = false;
            this.lbDisjunctiveForm.Location = new System.Drawing.Point(179, 306);
            this.lbDisjunctiveForm.Name = "lbDisjunctiveForm";
            this.lbDisjunctiveForm.Size = new System.Drawing.Size(100, 17);
            this.lbDisjunctiveForm.TabIndex = 8;
            this.lbDisjunctiveForm.Text = "                       ";
            // 
            // btnNandifyFrom
            // 
            this.btnNandifyFrom.Location = new System.Drawing.Point(596, 15);
            this.btnNandifyFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNandifyFrom.Name = "btnNandifyFrom";
            this.btnNandifyFrom.Size = new System.Drawing.Size(159, 30);
            this.btnNandifyFrom.TabIndex = 7;
            this.btnNandifyFrom.Text = "Nandify Form";
            this.btnNandifyFrom.UseVisualStyleBackColor = true;
            this.btnNandifyFrom.Click += new System.EventHandler(this.btnNandifyFrom_Click);
            // 
            // lbNandifyForm
            // 
            this.lbNandifyForm.AutoSize = true;
            this.lbNandifyForm.Location = new System.Drawing.Point(761, 22);
            this.lbNandifyForm.Name = "lbNandifyForm";
            this.lbNandifyForm.Size = new System.Drawing.Size(100, 17);
            this.lbNandifyForm.TabIndex = 6;
            this.lbNandifyForm.Text = "                       ";
            // 
            // dgvSimplifiedTable
            // 
            this.dgvSimplifiedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimplifiedTable.Enabled = false;
            this.dgvSimplifiedTable.Location = new System.Drawing.Point(761, 53);
            this.dgvSimplifiedTable.Name = "dgvSimplifiedTable";
            this.dgvSimplifiedTable.Size = new System.Drawing.Size(402, 243);
            this.dgvSimplifiedTable.TabIndex = 5;
            // 
            // btnSimplifiyTruthTable
            // 
            this.btnSimplifiyTruthTable.Enabled = false;
            this.btnSimplifiyTruthTable.Location = new System.Drawing.Point(596, 53);
            this.btnSimplifiyTruthTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSimplifiyTruthTable.Name = "btnSimplifiyTruthTable";
            this.btnSimplifiyTruthTable.Size = new System.Drawing.Size(159, 30);
            this.btnSimplifiyTruthTable.TabIndex = 4;
            this.btnSimplifiyTruthTable.Text = "Simplify Truth Table";
            this.btnSimplifiyTruthTable.UseVisualStyleBackColor = true;
            this.btnSimplifiyTruthTable.Click += new System.EventHandler(this.btnSimplifiyTruthTable_Click);
            // 
            // dgvTruthTable
            // 
            this.dgvTruthTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTruthTable.Location = new System.Drawing.Point(182, 53);
            this.dgvTruthTable.Name = "dgvTruthTable";
            this.dgvTruthTable.Size = new System.Drawing.Size(402, 243);
            this.dgvTruthTable.TabIndex = 3;
            // 
            // btnTruthTable
            // 
            this.btnTruthTable.Location = new System.Drawing.Point(14, 53);
            this.btnTruthTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTruthTable.Name = "btnTruthTable";
            this.btnTruthTable.Size = new System.Drawing.Size(159, 30);
            this.btnTruthTable.TabIndex = 2;
            this.btnTruthTable.Text = "Create Truth Table";
            this.btnTruthTable.UseVisualStyleBackColor = true;
            this.btnTruthTable.Click += new System.EventHandler(this.btnTruthTable_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(617, 16);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(64, 17);
            this.lbError.TabIndex = 4;
            this.lbError.Text = "              ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 409);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.pnControlls);
            this.Controls.Add(this.btnGenerateTree);
            this.Controls.Add(this.tbLogicalPrepostion);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnControlls.ResumeLayout(false);
            this.pnControlls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimplifiedTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruthTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbLogicalPrepostion;
        private System.Windows.Forms.Button btnGenerateTree;
        private System.Windows.Forms.Label lbVariables;
        private System.Windows.Forms.Button btnVariables;
        private System.Windows.Forms.Panel pnControlls;
        private System.Windows.Forms.Button btnTruthTable;
        private System.Windows.Forms.DataGridView dgvTruthTable;
        private System.Windows.Forms.Button btnSimplifiyTruthTable;
        private System.Windows.Forms.DataGridView dgvSimplifiedTable;
        private System.Windows.Forms.Button btnNandifyFrom;
        private System.Windows.Forms.Label lbNandifyForm;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnSimplifiedDisjunctive;
        private System.Windows.Forms.Label lbSimplifiyDisjunctiveForm;
        private System.Windows.Forms.Button btnDisjunctiveFrom;
        private System.Windows.Forms.Label lbDisjunctiveForm;
    }
}

