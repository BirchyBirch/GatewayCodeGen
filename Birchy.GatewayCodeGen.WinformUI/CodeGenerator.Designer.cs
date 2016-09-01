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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenerator));
            this.GenerateSqlCk = new System.Windows.Forms.CheckBox();
            this.GenerateDtosCk = new System.Windows.Forms.CheckBox();
            this.ServerNameBox = new System.Windows.Forms.TextBox();
            this.ServerNameLabel = new System.Windows.Forms.Label();
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
            this.GenerateSqlCk.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateSqlCk.Location = new System.Drawing.Point(37, 167);
            this.GenerateSqlCk.Name = "GenerateSqlCk";
            this.GenerateSqlCk.Size = new System.Drawing.Size(83, 15);
            this.GenerateSqlCk.TabIndex = 6;
            this.GenerateSqlCk.Text = "GenerateSql";
            this.GenerateSqlCk.UseVisualStyleBackColor = true;
            // 
            // GenerateDtosCk
            // 
            this.GenerateDtosCk.AutoSize = true;
            this.GenerateDtosCk.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateDtosCk.Location = new System.Drawing.Point(167, 167);
            this.GenerateDtosCk.Name = "GenerateDtosCk";
            this.GenerateDtosCk.Size = new System.Drawing.Size(89, 15);
            this.GenerateDtosCk.TabIndex = 7;
            this.GenerateDtosCk.Text = "GenerateDtos";
            this.GenerateDtosCk.UseVisualStyleBackColor = true;
            // 
            // ServerNameBox
            // 
            this.ServerNameBox.Location = new System.Drawing.Point(37, 101);
            this.ServerNameBox.Name = "ServerNameBox";
            this.ServerNameBox.Size = new System.Drawing.Size(100, 19);
            this.ServerNameBox.TabIndex = 2;
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameLabel.Location = new System.Drawing.Point(40, 88);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(68, 11);
            this.ServerNameLabel.TabIndex = 3;
            this.ServerNameLabel.Text = "Server Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 11);
            this.label1.TabIndex = 4;
            this.label1.Text = "Exclude Schemas: (CSV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 11);
            this.label2.TabIndex = 5;
            this.label2.Text = "Include Tables (CSV):";
            // 
            // ExcludeSchemasBox
            // 
            this.ExcludeSchemasBox.Location = new System.Drawing.Point(166, 136);
            this.ExcludeSchemasBox.Name = "ExcludeSchemasBox";
            this.ExcludeSchemasBox.Size = new System.Drawing.Size(100, 19);
            this.ExcludeSchemasBox.TabIndex = 5;
            // 
            // IncludeTablesBox
            // 
            this.IncludeTablesBox.Location = new System.Drawing.Point(37, 136);
            this.IncludeTablesBox.Name = "IncludeTablesBox";
            this.IncludeTablesBox.Size = new System.Drawing.Size(100, 19);
            this.IncludeTablesBox.TabIndex = 4;
            // 
            // WhereToSave
            // 
            this.WhereToSave.Location = new System.Drawing.Point(37, 68);
            this.WhereToSave.Name = "WhereToSave";
            this.WhereToSave.Size = new System.Drawing.Size(100, 19);
            this.WhereToSave.TabIndex = 0;
            // 
            // WhereToSaveLabel
            // 
            this.WhereToSaveLabel.AutoSize = true;
            this.WhereToSaveLabel.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhereToSaveLabel.Location = new System.Drawing.Point(40, 53);
            this.WhereToSaveLabel.Name = "WhereToSaveLabel";
            this.WhereToSaveLabel.Size = new System.Drawing.Size(77, 11);
            this.WhereToSaveLabel.TabIndex = 9;
            this.WhereToSaveLabel.Text = "Where to Save:";
            // 
            // GenerateCodeButton
            // 
            this.GenerateCodeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.GenerateCodeButton.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateCodeButton.Location = new System.Drawing.Point(118, 10);
            this.GenerateCodeButton.Name = "GenerateCodeButton";
            this.GenerateCodeButton.Size = new System.Drawing.Size(75, 34);
            this.GenerateCodeButton.TabIndex = 8;
            this.GenerateCodeButton.Text = "Generate Code";
            this.GenerateCodeButton.UseVisualStyleBackColor = false;
            this.GenerateCodeButton.Click += new System.EventHandler(this.GenerateCodeButton_Click);
            // 
            // CoreNamespaceBox
            // 
            this.CoreNamespaceBox.Location = new System.Drawing.Point(166, 101);
            this.CoreNamespaceBox.Name = "CoreNamespaceBox";
            this.CoreNamespaceBox.Size = new System.Drawing.Size(100, 19);
            this.CoreNamespaceBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 11);
            this.label3.TabIndex = 12;
            this.label3.Text = "Core Namespace:";
            // 
            // DBNameBox
            // 
            this.DBNameBox.Location = new System.Drawing.Point(166, 68);
            this.DBNameBox.Name = "DBNameBox";
            this.DBNameBox.Size = new System.Drawing.Size(100, 19);
            this.DBNameBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(169, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 11);
            this.label4.TabIndex = 14;
            this.label4.Text = "Database Name:";
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 197);
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
            this.Controls.Add(this.ServerNameLabel);
            this.Controls.Add(this.ServerNameBox);
            this.Controls.Add(this.GenerateDtosCk);
            this.Controls.Add(this.GenerateSqlCk);
            this.Font = new System.Drawing.Font("Miriam", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeGenerator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AutoDalGen";
            this.Load += new System.EventHandler(this.CodeGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox GenerateSqlCk;
        private System.Windows.Forms.CheckBox GenerateDtosCk;
        private System.Windows.Forms.TextBox ServerNameBox;
        private System.Windows.Forms.Label ServerNameLabel;
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

