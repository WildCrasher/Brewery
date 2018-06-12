using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Reflection;
using System.Collections;

namespace BusinessLogic
{
    public class BL : IBL
    {
        public IDAO Dao { get; set; }
        public BL()
        {
            string libraryPath = System.Configuration.ConfigurationManager.AppSettings["Library"];
            Assembly library = Assembly.UnsafeLoadFrom(@"../../../" + libraryPath);
            Type[] daoTypes = library.GetTypes();
            ConstructorInfo daoConstructor = null;
         
            foreach (var daoType in daoTypes)
            {
                if(daoType.GetConstructor( Type.EmptyTypes ) != null)
                {
                    daoConstructor = daoType.GetConstructor(Type.EmptyTypes);
                    break;
                }
            }
                
            Dao = (IDAO)daoConstructor?.Invoke(new object[] { });
            
        }

        public IDAO getData()
        {
            return Dao;
        }
    }
}
