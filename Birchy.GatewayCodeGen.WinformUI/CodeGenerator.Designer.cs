namespace Birchy.GatewayCodeGen.WinformUI
{
    partial class CodeGenerator
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
            this.GenerateSqlCk = new System.Windows.Forms.CheckBox();
            this.GenerateDtosCk = new System.Windows.Forms.CheckBox();
            this.ConnectionStringBox = new System.Windows.Forms.TextBox();
            this.ConnStringLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExcludeSchemasBox = new System.Windows.Forms.TextBox();
            this.IncludeTablesBox = new System.Windows.Forms.TextBox();
            this.WhereToSave = new System.Windows.Forms.TextBox();
            this.WhereToSaveLabel = new System.Windows.Forms.Label();
            this.GenerateCodeButton = new System.Windows.Forms.Button();
            this.CoreNamespaceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DBNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateSqlCk
            // 
            this.GenerateSqlCk.AutoSize = true;
            this.GenerateSqlCk.Location = new System.Drawing.Point(37, 197);
            this.GenerateSqlCk.Name = "GenerateSqlCk";
            this.GenerateSqlCk.Size = new System.Drawing.Size(85, 17);
            this.GenerateSqlCk.TabIndex = 0;
            this.GenerateSqlCk.Text = "GenerateSql";
            this.GenerateSqlCk.UseVisualStyleBackColor = true;
            // 
            // GenerateDtosCk
            // 
            this.GenerateDtosCk.AutoSize = true;
            this.GenerateDtosCk.Location = new System.Drawing.Point(167, 197);
            this.GenerateDtosCk.Name = "GenerateDtosCk";
            this.GenerateDtosCk.Size = new System.Drawing.Size(92, 17);
            this.GenerateDtosCk.TabIndex = 1;
            this.GenerateDtosCk.Text = "GenerateDtos";
            this.GenerateDtosCk.UseVisualStyleBackColor = true;
            // 
            // ConnectionStringBox
            // 
            this.ConnectionStringBox.Location = new System.Drawing.Point(37, 119);
            this.ConnectionStringBox.Name = "ConnectionStringBox";
            this.ConnectionStringBox.Size = new System.Drawing.Size(100, 20);
            this.ConnectionStringBox.TabIndex = 2;
            this.ConnectionStringBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ConnStringLabel
            // 
            this.ConnStringLabel.AutoSize = true;
            this.ConnStringLabel.Location = new System.Drawing.Point(34, 103);
            this.ConnStringLabel.Name = "ConnStringLabel";
            this.ConnStringLabel.Size = new System.Drawing.Size(91, 13);
            this.ConnStringLabel.TabIndex = 3;
            this.ConnStringLabel.Text = "ConnectionString:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Exclude Schemas: (CSV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Include Tables (CSV):";
            // 
            // ExcludeSchemasBox
            // 
            this.ExcludeSchemasBox.Location = new System.Drawing.Point(166, 161);
            this.ExcludeSchemasBox.Name = "ExcludeSchemasBox";
            this.ExcludeSchemasBox.Size = new System.Drawing.Size(100, 20);
            this.ExcludeSchemasBox.TabIndex = 6;
            // 
            // IncludeTablesBox
            // 
            this.IncludeTablesBox.Location = new System.Drawing.Point(37, 161);
            this.IncludeTablesBox.Name = "IncludeTablesBox";
            this.IncludeTablesBox.Size = new System.Drawing.Size(100, 20);
            this.IncludeTablesBox.TabIndex = 7;
            // 
            // WhereToSave
            // 
            this.WhereToSave.Location = new System.Drawing.Point(37, 80);
            this.WhereToSave.Name = "WhereToSave";
            this.WhereToSave.Size = new System.Drawing.Size(100, 20);
            this.WhereToSave.TabIndex = 8;
            // 
            // WhereToSaveLabel
            // 
            this.WhereToSaveLabel.AutoSize = true;
            this.WhereToSaveLabel.Location = new System.Drawing.Point(34, 64);
            this.WhereToSaveLabel.Name = "WhereToSaveLabel";
            this.WhereToSaveLabel.Size = new System.Drawing.Size(82, 13);
            this.WhereToSaveLabel.TabIndex = 9;
            this.WhereToSaveLabel.Text = "Where to Save:";
            // 
            // GenerateCodeButton
            // 
            this.GenerateCodeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.GenerateCodeButton.Location = new System.Drawing.Point(118, 12);
            this.GenerateCodeButton.Name = "GenerateCodeButton";
            this.GenerateCodeButton.Size = new System.Drawing.Size(75, 40);
            this.GenerateCodeButton.TabIndex = 10;
            this.GenerateCodeButton.Text = "Generate Code";
            this.GenerateCodeButton.UseVisualStyleBackColor = false;
            this.GenerateCodeButton.Click += new System.EventHandler(this.GenerateCodeButton_Click);
            // 
            // CoreNamespaceBox
            // 
            this.CoreNamespaceBox.Location = new System.Drawing.Point(166, 119);
            this.CoreNamespaceBox.Name = "CoreNamespaceBox";
            this.CoreNamespaceBox.Size = new System.Drawing.Size(100, 20);
            this.CoreNamespaceBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Core Namespace:";
            // 
            // DBNameBox
            // 
            this.DBNameBox.Location = new System.Drawing.Point(166, 80);
            this.DBNameBox.Name = "DBNameBox";
            this.DBNameBox.Size = new System.Drawing.Size(100, 20);
            this.DBNameBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Database Name:";
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 248);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DBNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CoreNamespaceBox);
            this.Controls.Add(this.GenerateCodeButton);
            this.Controls.Add(this.WhereToSaveLabel);
            this.Controls.Add(this.WhereToSave);
            this.Controls.Add(this.IncludeTablesBox);
            this.Controls.Add(this.ExcludeSchemasBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnStringLabel);
            this.Controls.Add(this.ConnectionStringBox);
            this.Controls.Add(this.GenerateDtosCk);
            this.Controls.Add(this.GenerateSqlCk);
            this.Name = "CodeGenerator";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CodeGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox GenerateSqlCk;
        private System.Windows.Forms.CheckBox GenerateDtosCk;
        private System.Windows.Forms.TextBox ConnectionStringBox;
        private System.Windows.Forms.Label ConnStringLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExcludeSchemasBox;
        private System.Windows.Forms.TextBox IncludeTablesBox;
        private System.Windows.Forms.TextBox WhereToSave;
        private System.Windows.Forms.Label WhereToSaveLabel;
        private System.Windows.Forms.Button GenerateCodeButton;
        private System.Windows.Forms.TextBox CoreNamespaceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DBNameBox;
        private System.Windows.Forms.Label label4;
    }
}

