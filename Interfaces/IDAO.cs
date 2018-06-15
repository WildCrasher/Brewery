using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        List<IBeer> GetBeers();
        IBeer GetNewBeer();
        void AddNewBeer(IBeer beer);
        void EditBeer(IBeer beer, int index);
        void RemoveBeer(int SelectedIndex);

        List<IProducent> GetProducents();
        IProducent GetNewProducent();
        void AddNewProducent(IProducent beer);
        void EditProducent(IProducent producent, int index);
        void RemoveProducent(int SelectedIndex);
    }
}
