namespace _2StageCalculator
{
    partial class ReactorCalculatorForm
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
            this.btnConfig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHeatGeneration = new System.Windows.Forms.TextBox();
            this.tbCooling = new System.Windows.Forms.TextBox();
            this.tbEfficiency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCoolant = new System.Windows.Forms.ListBox();
            this.lbHeaters = new System.Windows.Forms.ListBox();
            this.btnAddCoolant = new System.Windows.Forms.Button();
            this.btnHeaterCount = new System.Windows.Forms.Button();
            this.btnRemoveCoolant = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ckbPreheatedWater = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHeatExchanger = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCoolingEfficiency = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(13, 13);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(103, 23);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configuration";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCoolingEfficiency);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbHeatExchanger);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ckbPreheatedWater);
            this.groupBox1.Controls.Add(this.btnRemoveCoolant);
            this.groupBox1.Controls.Add(this.btnHeaterCount);
            this.groupBox1.Controls.Add(this.btnAddCoolant);
            this.groupBox1.Controls.Add(this.lbHeaters);
            this.groupBox1.Controls.Add(this.lbCoolant);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbEfficiency);
            this.groupBox1.Controls.Add(this.tbCooling);
            this.groupBox1.Controls.Add(this.tbHeatGeneration);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reactor Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heat Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cooling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Efficiency";
            // 
            // tbHeatGeneration
            // 
            this.tbHeatGeneration.Location = new System.Drawing.Point(111, 20);
            this.tbHeatGeneration.Name = "tbHeatGeneration";
            this.tbHeatGeneration.Size = new System.Drawing.Size(100, 20);
            this.tbHeatGeneration.TabIndex = 3;
            this.tbHeatGeneration.TextChanged += new System.EventHandler(this.tbHeatGeneration_TextChanged);
            // 
            // tbCooling
            // 
            this.tbCooling.Location = new System.Drawing.Point(111, 47);
            this.tbCooling.Name = "tbCooling";
            this.tbCooling.Size = new System.Drawing.Size(100, 20);
            this.tbCooling.TabIndex = 4;
            this.tbCooling.TextChanged += new System.EventHandler(this.tbCooling_TextChanged);
            // 
            // tbEfficiency
            // 
            this.tbEfficiency.Location = new System.Drawing.Point(111, 73);
            this.tbEfficiency.Name = "tbEfficiency";
            this.tbEfficiency.Size = new System.Drawing.Size(100, 20);
            this.tbEfficiency.TabIndex = 5;
            this.tbEfficiency.TextChanged += new System.EventHandler(this.tbEfficiency_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Coolants";
            // 
            // lbCoolant
            // 
            this.lbCoolant.FormattingEnabled = true;
            this.lbCoolant.Location = new System.Drawing.Point(282, 37);
            this.lbCoolant.Name = "lbCoolant";
            this.lbCoolant.Size = new System.Drawing.Size(120, 95);
            this.lbCoolant.TabIndex = 7;
            this.lbCoolant.SelectedIndexChanged += new System.EventHandler(this.lbCoolant_SelectedIndexChanged);
            // 
            // lbHeaters
            // 
            this.lbHeaters.FormattingEnabled = true;
            this.lbHeaters.Location = new System.Drawing.Point(408, 37);
            this.lbHeaters.Name = "lbHeaters";
            this.lbHeaters.Size = new System.Drawing.Size(42, 95);
            this.lbHeaters.TabIndex = 8;
            this.lbHeaters.SelectedIndexChanged += new System.EventHandler(this.lbHeaters_SelectedIndexChanged);
            // 
            // btnAddCoolant
            // 
            this.btnAddCoolant.Location = new System.Drawing.Point(456, 18);
            this.btnAddCoolant.Name = "btnAddCoolant";
            this.btnAddCoolant.Size = new System.Drawing.Size(101, 23);
            this.btnAddCoolant.TabIndex = 9;
            this.btnAddCoolant.Text = "Add Coolant";
            this.btnAddCoolant.UseVisualStyleBackColor = true;
            this.btnAddCoolant.Click += new System.EventHandler(this.btnAddCoolant_Click);
            // 
            // btnHeaterCount
            // 
            this.btnHeaterCount.Location = new System.Drawing.Point(456, 47);
            this.btnHeaterCount.Name = "btnHeaterCount";
            this.btnHeaterCount.Size = new System.Drawing.Size(101, 23);
            this.btnHeaterCount.TabIndex = 10;
            this.btnHeaterCount.Text = "Heater Count";
            this.btnHeaterCount.UseVisualStyleBackColor = true;
            this.btnHeaterCount.Click += new System.EventHandler(this.btnHeaterCount_Click);
            // 
            // btnRemoveCoolant
            // 
            this.btnRemoveCoolant.Location = new System.Drawing.Point(456, 76);
            this.btnRemoveCoolant.Name = "btnRemoveCoolant";
            this.btnRemoveCoolant.Size = new System.Drawing.Size(101, 23);
            this.btnRemoveCoolant.TabIndex = 11;
            this.btnRemoveCoolant.Text = "Remove Coolant";
            this.btnRemoveCoolant.UseVisualStyleBackColor = true;
            this.btnRemoveCoolant.Click += new System.EventHandler(this.btnRemoveCoolant_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(495, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(459, 245);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(111, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ckbPreheatedWater
            // 
            this.ckbPreheatedWater.AutoSize = true;
            this.ckbPreheatedWater.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbPreheatedWater.Checked = true;
            this.ckbPreheatedWater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPreheatedWater.Location = new System.Drawing.Point(23, 125);
            this.ckbPreheatedWater.Name = "ckbPreheatedWater";
            this.ckbPreheatedWater.Size = new System.Drawing.Size(107, 17);
            this.ckbPreheatedWater.TabIndex = 12;
            this.ckbPreheatedWater.Text = "Preheated Water";
            this.ckbPreheatedWater.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Heat Exhanger Type";
            // 
            // cbHeatExchanger
            // 
            this.cbHeatExchanger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeatExchanger.FormattingEnabled = true;
            this.cbHeatExchanger.Location = new System.Drawing.Point(111, 148);
            this.cbHeatExchanger.Name = "cbHeatExchanger";
            this.cbHeatExchanger.Size = new System.Drawing.Size(141, 21);
            this.cbHeatExchanger.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Heaters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cooling Efficiency";
            // 
            // tbCoolingEfficiency
            // 
            this.tbCoolingEfficiency.Location = new System.Drawing.Point(111, 99);
            this.tbCoolingEfficiency.Name = "tbCoolingEfficiency";
            this.tbCoolingEfficiency.ReadOnly = true;
            this.tbCoolingEfficiency.Size = new System.Drawing.Size(100, 20);
            this.tbCoolingEfficiency.TabIndex = 17;
            // 
            // ReactorCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 280);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfig);
            this.Name = "ReactorCalculatorForm";
            this.Text = "2-Stage Turbine Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveCoolant;
        private System.Windows.Forms.Button btnHeaterCount;
        private System.Windows.Forms.Button btnAddCoolant;
        private System.Windows.Forms.ListBox lbHeaters;
        private System.Windows.Forms.ListBox lbCoolant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEfficiency;
        private System.Windows.Forms.TextBox tbCooling;
        private System.Windows.Forms.TextBox tbHeatGeneration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox ckbPreheatedWater;
        private System.Windows.Forms.ComboBox cbHeatExchanger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCoolingEfficiency;
    }
}

