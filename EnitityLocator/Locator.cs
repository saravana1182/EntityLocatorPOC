using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.Reflection;


namespace EnitityLocator
{
    public class SetupCodeEntityResolver
    {

        private static SetupCodeEntityResolver _SetupCodeEntityResolver;

       

        public static SetupCodeEntityResolver Instance {
            get {

                if (_SetupCodeEntityResolver == null)
                {
                    _SetupCodeEntityResolver = new SetupCodeEntityResolver();
                }
                return _SetupCodeEntityResolver;
               
            } }


        public Type Resolve(string CategoryCode)
        {

            Type type = typeof(ISetupEntityCode);
            IEnumerable<Type> lookupTypes = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName == "EntityLocator.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                .SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)).ToList();


            foreach (var entity in lookupTypes)
            {


                var property= entity.GetProperty("CategoryType");

                if (property.GetValue(entity,null).ToString() == CategoryCode)
                {
                    return entity;
                }

                

            }

            return null;
            
        }

    }
}