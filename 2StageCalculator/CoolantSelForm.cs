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
