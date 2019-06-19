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
    public partial class ReactorReportForm : Form
    {
        private ConfigData config;
        private double msrCE;
        private string strHeatExchangerType;
        private bool bUsingPHWater;
        private Dictionary<string, double> CoolantList;
        private string html;
        public ReactorReportForm(ConfigData nConfig, double msrCoolingEfficiency, string strHEType, bool bPreheatedWater, Dictionary<string, double> coolants,
            double heatGen, double cooling, double efficiency)
        {
            InitializeComponent();
            config = nConfig;
            msrCE = msrCoolingEfficiency;
            strHeatExchangerType = strHEType;
            bUsingPHWater = bPreheatedWater;
            CoolantList = coolants;

            double wbcr = (bUsingPHWater) ? config.preheatedWaterBaseCoolingProvided : config.waterBaseCoolingProvided;
            double wbhr = (bUsingPHWater) ? config.preheatedWaterBaseHeatingRequired : config.waterBaseHeatingRequired;

            double HEConductivity = config.heatExchangerTubeConductivity[strHeatExchangerType];

            Dictionary<string, HotCoolantSplitRatio> HCSR = new Dictionary<string, HotCoolantSplitRatio>();
            Dictionary<string, HotCoolantToWater> HCTW = new Dictionary<string, HotCoolantToWater>();
            Dictionary<string, HPSteamToLPSteam> HSTLS = new Dictionary<string, HPSteamToLPSteam>();
            Dictionary<string, LPSteamToCondensateWater> LSTCW = new Dictionary<string, LPSteamToCondensateWater>();
            Dictionary<string, CondensateWaterToHotCoolant> CWTHC = new Dictionary<string, CondensateWaterToHotCoolant>();
            double waterTotalRate = 0.0;
            double hpSteamTotalRate = 0.0;
            double lpSteamTotatRate = 0.0;
            double condensateWaterTotalRate = 0.0;
            double coolantTotalPreheatingLoopRate = 0.0;
            double cwNumberContacts = 0.0;
            double powerProduced = 0.0;

            foreach (string key in CoolantList.Keys)
            {
                HotCoolantSplitRatio hcsr = new HotCoolantSplitRatio();
                hcsr.coolantTotalIntermediateLoopRate = (24000.0 * HEConductivity * config.coolantPerRecipe * msrCE * CoolantList[key] * HEConductivity) /
                    (HEConductivity * HEConductivity * HEConductivity * wbcr * wbhr + 4800000.0 * HEConductivity * HEConductivity + 320000.0 * HEConductivity * HEConductivity);

                hcsr.coolantTotalPreheatingLoopRate = (16000 * config.coolantPerRecipe * HEConductivity * msrCE * CoolantList[key] * HEConductivity) /
                    (HEConductivity * HEConductivity * HEConductivity * wbcr * wbhr + 4800000.0 * HEConductivity * HEConductivity + 320000.0 * HEConductivity * HEConductivity);

                HCSR.Add(key, hcsr);

                HotCoolantToWater hctw = new HotCoolantToWater();
                hctw.coolantTotalPrimaryRate = config.coolantPerRecipe / 20.0 * msrCE * CoolantList[key] - hcsr.coolantTotalIntermediateLoopRate - hcsr.coolantTotalPreheatingLoopRate;
                hctw.coolantBaseCoolingRequired = config.coolantHeatMultiplier * config.msrBaseCoolingRate[key] * HEConductivity;
                hctw.coolantTotalCoolingRequired = hctw.coolantTotalPrimaryRate * hctw.coolantBaseCoolingRequired / config.coolantPerRecipe;
                hctw.numberCoolantWaterContacts = hctw.coolantTotalCoolingRequired / wbcr;
                hctw.waterTotalRate = 200.0 * hctw.numberCoolantWaterContacts * HEConductivity * 400.0 / wbhr;
                hctw.hpSteamTotalRate = hctw.waterTotalRate * 1000.0 / 200.0;

                HCTW.Add(key, hctw);

                waterTotalRate += hctw.waterTotalRate;
                hpSteamTotalRate += hctw.hpSteamTotalRate;

                HPSteamToLPSteam hstls = new HPSteamToLPSteam();
                hstls.exhaustSteamTotalRate = hctw.hpSteamTotalRate * 4.0;
                hstls.exhaustSteamTotalHeatingRequired = hstls.exhaustSteamTotalRate * 4000.0 / (1000.0 * HEConductivity);
                hstls.numberExhaustSteamCoolantContacts = hstls.exhaustSteamTotalHeatingRequired / 400.0;
                hstls.coolantTotalIntermediateLoopRate = config.coolantPerRecipe * hstls.numberExhaustSteamCoolantContacts * 300.0 / (config.msrBaseCoolingRate[key] * HEConductivity);

                HSTLS.Add(key, hstls);

                lpSteamTotatRate += hstls.exhaustSteamTotalRate;

                LPSteamToCondensateWater lstcw = new LPSteamToCondensateWater();
                lstcw.lqSteamTotalRate = hstls.exhaustSteamTotalRate * 2.0;
                lstcw.numberLqSteamCondenserContacts = lstcw.lqSteamTotalRate * 20.0 / (1000.0 * HEConductivity * (1.0 + Math.Log(350.0 / config.condenserSurroundingTemperatur)));
                lstcw.condensateWaterTotalRate = hstls.exhaustSteamTotalRate * 25.0 / 1000.0;

                condensateWaterTotalRate += lstcw.condensateWaterTotalRate;

                LSTCW.Add(key, lstcw);

                CondensateWaterToHotCoolant cwthc = new CondensateWaterToHotCoolant();
                cwthc.condensateWaterTotalHeatingRequired = lstcw.condensateWaterTotalRate * 32000.0 / (1000.0 * HEConductivity);
                cwthc.numberCondensateWaterCoolantContacts = cwthc.condensateWaterTotalHeatingRequired / 400.0;
                cwthc.coolantToatlPreheatingLoopRate = config.coolantPerRecipe * cwthc.numberCondensateWaterCoolantContacts * 100.0 / (config.msrBaseCoolingRate[key] * HEConductivity);
                cwNumberContacts += cwthc.numberCondensateWaterCoolantContacts;
                CWTHC.Add(key, cwthc);

                coolantTotalPreheatingLoopRate += cwthc.coolantToatlPreheatingLoopRate;
            }

            powerProduced = hpSteamTotalRate * 16.0 + lpSteamTotatRate * 4.0;





            html = "<HTML><HEAD><TITLE>2-Stage Molten Salt Reactor Calculation</TITLE></HEAD><BODY>\n";

            AddLine("<H1>2-Stage Molten Salt Reator Calculation</H1>", false);
            AddLine("<H3>Configuration Data</H3>", false);
            AddLine("<H4>" + nbsp(4) + "Reactor Data</H4>", false);
            int iHeatGen = (int)heatGen;
            int iCooling = (int)cooling;

            AddLine(nbsp(8) + "Heat Generation: " + iHeatGen, true);
            AddLine(nbsp(8) + "Cooling: " + iCooling, true);
            AddLine(nbsp(8) + "Cooling Efficiency: " + (msrCE * 100) + "%", true);
            if (bPreheatedWater)
            {
                AddLine(nbsp(8) + "Using Preheated Water: True", true);
            }
            else
            {
                AddLine(nbsp(8) + "Using Preheated Water: False", true);
            }

            AddLine(nbsp(8) + "Heat Exchanger Type: " + strHEType, true);
            AddLine("<H4>" + nbsp(4) + "Coolant Data</H4>", false);
            AddLine("<table style=\"margin-left: 30px; border: 1px solid black\"><tr><th>Coolant</th><th>Heaters</th><tr>", false);
            foreach (string key in CoolantList.Keys)
            {
                AddLine("<tr style=\"Border: 1px solid black\"><td>" + key + "</td><td align=\"right\">" + CoolantList[key] + "</td></tr>", false);
            }
            AddLine("</table><br>", true);

            AddLine("<H3>Heat Exchanger 1</H3>", false);
            foreach (string key in CoolantList.Keys)
            {
                AddLine(nbsp(4) + "Coolant: " + key, true);
                AddLine(nbsp(8) + "Number of Contacts: " + Math.Ceiling(HCTW[key].numberCoolantWaterContacts), true);
                AddLine(nbsp(8) + "HP Steam Total Rate: " + HCTW[key].hpSteamTotalRate + "mb/t", true);
            }
            AddLine("<table style=\"margin - left: 15px\" ><tr><td><b>Water Total Rate:</b></td><td align=\"right\">" + waterTotalRate + "mb/t</td></tr>", false);
            AddLine("<tr><td><b>HP Steam Total Rate:</b></td><td align=\"right\">" + hpSteamTotalRate + "mb/t</td></tr></table>", false);

            AddLine("<br>", true);
            AddLine("<H3>HP Turbine</H3>", false);
            AddLine(nbsp(4) + "Exhaust Steam Total Rate: " + hpSteamTotalRate * 4, true);
            AddLine(nbsp(4) + "Minimum Turbine Blades: " + Math.Ceiling(hpSteamTotalRate / 100), true);

            AddLine("<br>", true);

            AddLine("<H3>Heat Exchanger 2</H3>", false);
            foreach (string key in CoolantList.Keys)
            {
                AddLine(nbsp(4) + "Coolant: " + key, true);
                AddLine(nbsp(8) + "Number of Contacts: " + Math.Ceiling(HSTLS[key].numberExhaustSteamCoolantContacts), true);
                AddLine(nbsp(8) + "LP Steam Total Rate: " + HSTLS[key].exhaustSteamTotalRate + "mb/t", true);
            }
            AddLine(nbsp(4) + "LP Steam Total Rate: " + lpSteamTotatRate + "mb/t", true);

            AddLine("<br>", true);
            AddLine("<H3>LP Turbine</H3>", false);
            AddLine(nbsp(4) + "Lq Steam Total Rate: " + lpSteamTotatRate * 2, true);
            AddLine(nbsp(4) + "Minimum Turbine Blades: " + Math.Ceiling(lpSteamTotatRate / 100), true);

            AddLine("<br>", true);
            AddLine("<H3>Condenser</H3>", false);
            AddLine(nbsp(4) + "Number of Contacts: " + Math.Ceiling(cwNumberContacts), true);

            AddLine("<br>", true);
            AddLine("<H3>Heat Exchanger 3</H3>", false);
            foreach (string key in CoolantList.Keys)
            {
                AddLine(nbsp(4) + "Coolant: " + key, true);
                AddLine(nbsp(8) + "Number of Contacts: " + Math.Ceiling(CWTHC[key].numberCondensateWaterCoolantContacts), true);
                AddLine(nbsp(8) + "Preheated Water Total Rate: " + CWTHC[key].coolantToatlPreheatingLoopRate + "mb/t", true);
            }
            AddLine(nbsp(4) + "Preheated Water Total Rate: " + coolantTotalPreheatingLoopRate, true);

            AddLine("<br>", true);
            AddLine("<H3>Power Produced</H4>", false);
            AddLine("<H4>" + powerProduced + "rf/t", false);
            AddLine("</BODY></HTML>", false);
            WBReport.DocumentText = html;


        }
        private void AddLine(string line, bool br)
        {
            if (br)
            {
                html += "<br>";
            }
            html += line + "\n";
        }

        private string nbsp(int number)
        {
            string ret = "";
            for (int i = 0; i < number; i++)
            {
                ret += "&nbsp";
            }
            return ret;
        }
    }
    public struct HotCoolantSplitRatio
    {
        public double coolantTotalIntermediateLoopRate;
        public double coolantTotalPreheatingLoopRate;
    }

    public struct HotCoolantToWater
    {
        public double coolantTotalPrimaryRate;
        public double coolantBaseCoolingRequired;
        public double coolantTotalCoolingRequired;
        public double numberCoolantWaterContacts;
        public double waterTotalRate;
        public double hpSteamTotalRate;
    }

    public struct HPSteamToLPSteam
    {
        public double exhaustSteamTotalRate;
        public double exhaustSteamTotalHeatingRequired;
        public double numberExhaustSteamCoolantContacts;
        public double coolantTotalIntermediateLoopRate;
    }

    public struct LPSteamToCondensateWater
    {
        public double lqSteamTotalRate;
        public double numberLqSteamCondenserContacts;
        public double condensateWaterTotalRate;
    }

    public struct CondensateWaterToHotCoolant
    {
        public double condensateWaterTotalHeatingRequired;
        public double numberCondensateWaterCoolantContacts;
        public double coolantToatlPreheatingLoopRate;
    }
}
