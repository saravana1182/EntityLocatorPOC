using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.Reflection;


namespace EnitityLocator
{
    public class Locator
    {

        private static Locator _locator;

        private static Dictionary<string, Type> setupCodes = new Dictionary<string, Type>();

        private Locator()
        {
            setupCodes.Add("CC", typeof(CourtCode));
        }

        public static Locator Instance {
            get {

                if (_locator == null)
                {
                    _locator = new Locator();
                }
                return _locator;
               
            } }


        public Type Locate(string CategoryCode)
        {

            Type type = typeof(ISetupEntityCode);
            IEnumerable<Type> lookupTypes = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName == "EntityLocator.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                .SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)).ToList();

           // var entity=lookupTypes.SelectMany(x=> x.GetProperty("CategoryType"))
            return setupCodes.Where(x => x.Key == CategoryCode).FirstOrDefault().Value;
            
        }

    }
}