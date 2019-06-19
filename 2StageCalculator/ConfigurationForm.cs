using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2StageCalculator
{
    public partial class ConfigurationForm : Form
    {
        private ConfigData config;
        private Dictionary<TextBox, string> tbNames;

        private bool bUpdated = false;
        public ConfigurationForm(ConfigData nConfig)
        {
            InitializeComponent();
            config = nConfig;

            tbNames = new Dictionary<TextBox, string>();

            tbNames.Add(tbCoolantPerRecipe, "Coolant per Recipe");
            tbNames.Add(tbCoolantHeatMultiplier, "Coolant Heat Multiplier");
            tbNames.Add(tbBaseCoolingRequired, "Water Base Cooling Provided");
            tbNames.Add(tbBaseHeatingRequired, "Water Base Heating Required");
            tbNames.Add(tbPHCoolingRquired, "Preheated Water Base Cooling Provided");
            tbNames.Add(tbPHHeatingRequired, "Preheated Water Base Heating Required");
            tbNames.Add(tbPowerMultiplier, "MSR Power Multiplier");
            tbNames.Add(tbHeatMultiplier, "MSR Heat Multiplier");
            tbNames.Add(tbCoolantSurroundingTemp, "Coolant Surrounding Temperature");

            tbNames.Add(tbCBase, "Coolant: Base");
            tbNames.Add(tbCRedstone, "Coolant: Redstone");
            tbNames.Add(tbCQuartz, "Coolant: Quartz");
            tbNames.Add(tbCGold, "Coolant: Gold");
            tbNames.Add(tbCGlowstone, "Coolant: Glowstone");
            tbNames.Add(tbCLapis, "Coolant: Lapis");
            tbNames.Add(tbCDiamond, "Coolant: Diamond");
            tbNames.Add(tbCLqHelium, "Coolant: Liquid Helium");
            tbNames.Add(tbCEnder, "Coolant: Ender");
            tbNames.Add(tbCCryotheum, "Coolant: Cryotheum");
            tbNames.Add(tbCIron, "Coolant: Iron");
            tbNames.Add(tbCEmerald, "Coolant: Emerald");
            tbNames.Add(tbCCopper, "Coolant: Copper");
            tbNames.Add(tbCTin, "Coolant: Tin");
            tbNames.Add(tbCMagnesium, "Coolant: Magnesium");

            tbNames.Add(tbHECCopper, "Heat Exchanger: Copper");
            tbNames.Add(tbHECHardCarbon, "Heat Exchanger: Hard Carbon");
            tbNames.Add(tbHECTCAlloy, "Heat Exchanger: Thermoconducting Alloy");

            UpdateConfigWindow();
        }

        private bool ValidateInput()
        {
            bool errorFound = false;
            TextBox errorTb = null;
            foreach(TextBox key in tbNames.Keys)
            {
                double output;
                if (!double.TryParse(key.Text, out output))
                {
                    if(!errorFound)
                    {
                        errorFound = true;
                        errorTb = key;
                    }
                    key.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    key.BackColor = System.Drawing.Color.White;
                }
            }
            if(errorFound)
            {
                MessageBox.Show("Invalid Input: " + tbNames[errorTb]);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateConfig()
        {
            config.coolantPerRecipe = double.Parse(tbCoolantPerRecipe.Text);
            config.coolantHeatMultiplier = double.Parse(tbCoolantHeatMultiplier.Text);
            config.waterBaseCoolingProvided = double.Parse(tbBaseCoolingRequired.Text);
            config.waterBaseHeatingRequired = double.Parse(tbBaseHeatingRequired.Text);
            config.preheatedWaterBaseCoolingProvided = double.Parse(tbPHCoolingRquired.Text);
            config.preheatedWaterBaseHeatingRequired = double.Parse(tbPHHeatingRequired.Text);
            config.msrPowerMultiplier = double.Parse(tbPowerMultiplier.Text);
            config.msrHeatMultiplier = double.Parse(tbHeatMultiplier.Text);
            config.condenserSurroundingTemperatur = double.Parse(tbCoolantSurroundingTemp.Text);

            config.msrBaseCoolingRate["Base"] = double.Parse(tbCBase.Text);
            config.msrBaseCoolingRate["Redstone"] = double.Parse(tbCRedstone.Text);
            config.msrBaseCoolingRate["Quartz"] = double.Parse(tbCQuartz.Text);
            config.msrBaseCoolingRate["Gold"] = double.Parse(tbCGold.Text);
            config.msrBaseCoolingRate["Glowstone"] = double.Parse(tbCGlowstone.Text);
            config.msrBaseCoolingRate["Lapis"] = double.Parse(tbCLapis.Text);
            config.msrBaseCoolingRate["Diamond"] = double.Parse(tbCDiamond.Text);
            config.msrBaseCoolingRate["Liquid Helium"] = double.Parse(tbCLqHelium.Text);
            config.msrBaseCoolingRate["Ender"] = double.Parse(tbCEnder.Text);
            config.msrBaseCoolingRate["Cryotheum"] = double.Parse(tbCCryotheum.Text);
            config.msrBaseCoolingRate["Iron"] = double.Parse(tbCIron.Text);
            config.msrBaseCoolingRate["Emerald"] = double.Parse(tbCEmerald.Text);
            config.msrBaseCoolingRate["Copper"] = double.Parse(tbCCopper.Text);
            config.msrBaseCoolingRate["Tin"] = double.Parse(tbCTin.Text);
            config.msrBaseCoolingRate["Magnesium"] = double.Parse(tbCMagnesium.Text);

            config.heatExchangerTubeConductivity["Copper"] = double.Parse(tbHECCopper.Text);
            config.heatExchangerTubeConductivity["Hard Carbon"] = double.Parse(tbHECHardCarbon.Text);
            config.heatExchangerTubeConductivity["Thermoconducting Alloy"] = double.Parse(tbHECTCAlloy.Text);
        }

        private void UpdateConfigWindow()
        {
            tbCoolantPerRecipe.Text = config.coolantPerRecipe.ToString();
            tbCoolantHeatMultiplier.Text = config.coolantHeatMultiplier.ToString();
            tbBaseCoolingRequired.Text = config.waterBaseCoolingProvided.ToString();
            tbBaseHeatingRequired.Text = config.waterBaseHeatingRequired.ToString();
            tbPHCoolingRquired.Text = config.preheatedWaterBaseCoolingProvided.ToString();
            tbPHHeatingRequired.Text = config.preheatedWaterBaseHeatingRequired.ToString();
            tbPowerMultiplier.Text = config.msrPowerMultiplier.ToString();
            tbHeatMultiplier.Text = config.msrHeatMultiplier.ToString();
            tbCoolantSurroundingTemp.Text = config.condenserSurroundingTemperatur.ToString();

            tbCBase.Text = config.msrBaseCoolingRate["Base"].ToString();
            tbCRedstone.Text = config.msrBaseCoolingRate["Redstone"].ToString();
            tbCQuartz.Text = config.msrBaseCoolingRate["Quartz"].ToString();
            tbCGold.Text = config.msrBaseCoolingRate["Gold"].ToString();
            tbCGlowstone.Text = config.msrBaseCoolingRate["Glowstone"].ToString();
            tbCLapis.Text = config.msrBaseCoolingRate["Lapis"].ToString();
            tbCDiamond.Text = config.msrBaseCoolingRate["Diamond"].ToString();
            tbCLqHelium.Text = config.msrBaseCoolingRate["Liquid Helium"].ToString();
            tbCEnder.Text = config.msrBaseCoolingRate["Ender"].ToString();
            tbCCryotheum.Text = config.msrBaseCoolingRate["Cryotheum"].ToString();
            tbCIron.Text = config.msrBaseCoolingRate["Iron"].ToString();
            tbCEmerald.Text = config.msrBaseCoolingRate["Emerald"].ToString();
            tbCCopper.Text = config.msrBaseCoolingRate["Copper"].ToString();
            tbCTin.Text = config.msrBaseCoolingRate["Tin"].ToString();
            tbCMagnesium.Text = config.msrBaseCoolingRate["Magnesium"].ToString();

            tbHECCopper.Text = config.heatExchangerTubeConductivity["Copper"].ToString();
            tbHECHardCarbon.Text = config.heatExchangerTubeConductivity["Hard Carbon"].ToString();
            tbHECTCAlloy.Text = config.heatExchangerTubeConductivity["Thermoconducting Alloy"].ToString();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        public ConfigData getUpdatedConfig()
        {
            return config;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bUpdated = true;
                UpdateConfig();
                this.Close();
            }
        }

        public bool isConfigUpdated()
        {
            return bUpdated;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bUpdated = false;
            this.Close();
        }
    }

}
