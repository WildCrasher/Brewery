﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        List<IBeer> getBeers();
        List<IProducent> getProducents();
        void AddNewBeer(IBeer beer);
        void AddNewProducent(IProducent beer);
        IBeer GetNewBeer();
        IProducent GetNewProducent();
    }
}
