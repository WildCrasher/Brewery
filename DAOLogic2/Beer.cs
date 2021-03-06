﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Interfaces;

namespace DAOLogic
{
    public class Beer: IBeer
    {
        public Race Race { get; set; }
        public Speciality Speciality { get; set; }
        public IProducent Producent { get; set; }
        public Double AlcoholPercent { get; set; }
        public int IBU { get; set; }
        public int EBC { get; set; }
        public int ServingTemperature { get; set; }
        public Double BLG { get; set; }
        public DateTime BestBefore { get; set; }
        public String SeaStory { get; set; }
        public String Ingredients { get; set; }

        public Beer()
        {
        
        }

        public Beer(Race _race, Speciality _speciality, IProducent _producent, Double _alcoholPercent, int _IBU, int _EBC, int _servingTemperature,
                                                            Double _BLG, DateTime _bestBefore, String _seaStory, String _ingredients )
        {
            Race = _race;
            Speciality = _speciality;
            Producent = _producent;
            AlcoholPercent = _alcoholPercent;
            IBU = _IBU;
            EBC = _EBC;
            ServingTemperature = _servingTemperature;
            BLG = _BLG;
            BestBefore = _bestBefore;
            SeaStory = _seaStory;
            Ingredients = _ingredients;
        }
    }
}
