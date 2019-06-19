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
    public partial class CoolantSelForm : Form
    {
        private bool bSave = false;
        private string strCooler;
        private double heaters;
        public CoolantSelForm(ConfigData config)
        {
            InitializeComponent();

            cbCoolant.Items.Clear();
            foreach(string key in config.msrBaseCoolingRate.Keys)
            {
                cbCoolant.Items.Add(key);
            }

            
        }

        public CoolantSelForm(ConfigData config, string curSel, double curHeat)
        {
            InitializeComponent();

            cbCoolant.Items.Clear();
            foreach (string key in config.msrBaseCoolingRate.Keys)
            {
                cbCoolant.Items.Add(key);
            }
            cbCoolant.SelectedItem = curSel;
            nudHeaters.Value = (decimal)curHeat;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bSave = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bSave = true;
            strCooler = cbCoolant.Items[cbCoolant.SelectedIndex].ToString();
            heaters = (double)nudHeaters.Value;
            this.Close();
        }

        public bool IsAddCoolant()
        {
            return bSave;
        }

        public string GetCoolant()
        {
            return strCooler;
        }

        public double GetHeaters()
        {
            return heaters;
        }
    }
}
