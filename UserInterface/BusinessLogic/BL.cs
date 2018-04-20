using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
//using DAOLogic;
using System.Reflection;
using System.Collections;

namespace BusinessLogic
{
    public class BL : IBL
    {
        public IDAO dao { get; set; }
        public BL()
        {
            string libraryPath = System.Configuration.ConfigurationManager.AppSettings["Library"];
            Console.WriteLine(libraryPath);
            Assembly library = Assembly.LoadFrom(@"" + libraryPath);
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
                
            dao = (IDAO)daoConstructor?.Invoke(new object[] { });
            
                  //IEnumerable<ConstructorInfo> ctorInfo = item.GetConstructors().Where(ctor => { Console.WriteLine(ctor.GetParameters()); return ctor.GetParameters() == null;  }) ;
        }
        public IDAO getData()
        {
            return dao;
        }
    }
}
