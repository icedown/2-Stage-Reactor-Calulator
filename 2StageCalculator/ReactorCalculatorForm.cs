// --------------------------------------------------------------------------------------------------------------------
//  Copyright (C) 2019 Jason Brooks
//
//    This file is part of 2 Stage Reactor Calculator.
//
//    2 Stage Reactor Calculator is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    2 Stage Reactor Calculator is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with 2 Stage Reactor Calculator.  If not, see<https://www.gnu.org/licenses/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2StageCalculator
{
    public partial class ReactorCalculatorForm : Form
    {

        private ConfigData config;

        public ReactorCalculatorForm()
        {
            InitializeComponent();
            config = new ConfigData();

            cbHeatExchanger.Items.Clear();
            cbHeatExchanger.Items.Add("Copper");
            cbHeatExchanger.Items.Add("Hard Carbon");
            cbHeatExchanger.Items.Add("Thermoconducting Alloy");

            tbHeatGeneration.Text = "0";
            tbCooling.Text = "0";
            tbEfficiency.Text = "0";

            cbHeatExchanger.SelectedIndex = 0;

            //DEBUG SETUP
            cbHeatExchanger.SelectedIndex = 1;
            tbHeatGeneration.Text = "3520";
            tbCooling.Text = "5920";
            tbEfficiency.Text = "233";
            lbCoolant.Items.Add("Lapis");
            lbHeaters.Items.Add("8");
            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigurationForm cForm = new ConfigurationForm(config);
            cForm.ShowDialog();
            if (cForm.isConfigUpdated())
            {
                this.config = cForm.getUpdatedConfig();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbCoolant_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbHeaters.SelectedIndex = lbCoolant.SelectedIndex;
        }

        private void lbHeaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCoolant.SelectedIndex = lbHeaters.SelectedIndex;
        }

        private void btnAddCoolant_Click(object sender, EventArgs e)
        {
            CoolantSelForm csf = new CoolantSelForm(config);
            csf.ShowDialog();
            if (csf.IsAddCoolant())
            {
                lbCoolant.Items.Add(csf.GetCoolant());
                lbHeaters.Items.Add(csf.GetHeaters());
            }
        }

        private void btnHeaterCount_Click(object sender, EventArgs e)
        {
            if (lbCoolant.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a heater type!");
                return;
            }

            CoolantSelForm csf = new CoolantSelForm(config, lbCoolant.Items[lbCoolant.SelectedIndex].ToString(), double.Parse(lbHeaters.Items[lbHeaters.SelectedIndex].ToString()));
            csf.ShowDialog();
            if (csf.IsAddCoolant())
            {
                int index = lbCoolant.SelectedIndex;
                lbCoolant.Items.RemoveAt(index);
                lbHeaters.Items.RemoveAt(index);
                lbCoolant.Items.Insert(index, csf.GetCoolant());
                lbHeaters.Items.Insert(index, csf.GetHeaters());
            }
        }

        private void btnRemoveCoolant_Click(object sender, EventArgs e)
        {
            if (lbCoolant.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a heater type!");
                return;
            }
            int index = lbCoolant.SelectedIndex;
            lbCoolant.Items.RemoveAt(index);
            lbHeaters.Items.RemoveAt(index);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> coolants = new Dictionary<string, double>();
            for(int i = 0; i < lbCoolant.Items.Count; i++)
            {
                coolants.Add(lbCoolant.Items[i].ToString(), double.Parse(lbHeaters.Items[i].ToString()));
            }
            ReactorReportForm rrf = new ReactorReportForm(config, double.Parse(tbCoolingEfficiency.Text), cbHeatExchanger.SelectedItem.ToString(), ckbPreheatedWater.Checked,
                coolants, double.Parse(tbHeatGeneration.Text), double.Parse(tbCooling.Text), double.Parse(tbEfficiency.Text));
            rrf.ShowDialog();
        }

        private void tbHeatGeneration_TextChanged(object sender, EventArgs e)
        {
            UpdateCoolingEfficiency();
        }

        private void tbCooling_TextChanged(object sender, EventArgs e)
        {
            UpdateCoolingEfficiency();
        }

        private void tbEfficiency_TextChanged(object sender, EventArgs e)
        {
            UpdateCoolingEfficiency();
        }

        private void UpdateCoolingEfficiency()
        {
            bool bHG = ValidateDouble(tbHeatGeneration);
            bool bC = ValidateDouble(tbCooling);
            bool bE = ValidateDouble(tbEfficiency);

            if (bHG && bC && bE)
            {
                double dHG = double.Parse(tbHeatGeneration.Text);
                double dC = double.Parse(tbCooling.Text);
                double dE = double.Parse(tbEfficiency.Text);

                double dCE = dHG / dC * (dE / 100.0);

                if (dCE != double.NaN)
                {
                    tbCoolingEfficiency.Text = dCE.ToString();
                }
                else
                {
                    tbCoolingEfficiency.Text = "";
                }
            }
            else
            {
                tbCoolingEfficiency.Text = "";
            }
            


        }

        private bool ValidateDouble(TextBox tb)
        {
            double output;
            if(double.TryParse(tb.Text, out output))
            {
                tb.BackColor = Color.White;
                return true;
            }
            else
            {
                tb.BackColor = Color.Red;
                return false;
            }
        }
    }
}
