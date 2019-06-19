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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2StageCalculator
{
    public class ConfigData
    {
        //Configuration Variables   

        //I:salt_fission_cooling_max_rate
        public double coolantPerRecipe = 20;

        //D:heat_exchanger_coolant_mult
        public double coolantHeatMultiplier = 125;

        //D:salt_fission_cooling_rate
        public Dictionary<string, double> msrBaseCoolingRate;

        //D:heat_exchanger_conductivity
        public Dictionary<string, double> heatExchangerTubeConductivity;

        public double waterBaseCoolingProvided = 900.0;

        public double waterBaseHeatingRequired = 32000.0;

        public double preheatedWaterBaseCoolingProvided = 800.0;

        public double preheatedWaterBaseHeatingRequired = 16000.0;

        //D:salt_fission_power
        public double msrPowerMultiplier = 5.0;

        //D:salt_fission_heat_generation
        public double msrHeatMultiplier = 1.0;

        public double condenserSurroundingTemperatur = 4.0;


        public ConfigData()
        {

            msrBaseCoolingRate = new Dictionary<string, double>();
            msrBaseCoolingRate.Add("Base", 240.0);
            msrBaseCoolingRate.Add("Redstone", 360.0);
            msrBaseCoolingRate.Add("Quartz", 360.0);
            msrBaseCoolingRate.Add("Gold", 480.0);
            msrBaseCoolingRate.Add("Glowstone", 520.0);
            msrBaseCoolingRate.Add("Lapis", 480.0);
            msrBaseCoolingRate.Add("Diamond", 600.0);
            msrBaseCoolingRate.Add("Liquid Helium", 560.0);
            msrBaseCoolingRate.Add("Ender", 480.0);
            msrBaseCoolingRate.Add("Cryotheum", 640.0);
            msrBaseCoolingRate.Add("Iron", 320.0);
            msrBaseCoolingRate.Add("Emerald", 640.0);
            msrBaseCoolingRate.Add("Copper", 320.0);
            msrBaseCoolingRate.Add("Tin", 480.0);
            msrBaseCoolingRate.Add("Magnesium", 440.0);

            heatExchangerTubeConductivity = new Dictionary<string, double>();
            heatExchangerTubeConductivity.Add("Copper", 1.0);
            heatExchangerTubeConductivity.Add("Hard Carbon", 1.1);
            heatExchangerTubeConductivity.Add("Thermoconducting Alloy", 1.25);
        }
    }
}
