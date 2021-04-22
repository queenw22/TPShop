using System;
using System.Linq.Expressions;
using Core.Entity;

namespace Core.Spec
{
    public class ServiceWithTypeSpec : BaseSpec<Service>
    {
        public ServiceWithTypeSpec()
        {
            AddInclude(x => x.ServiceType);
            AddInclude(x => x.CommType);
            AddInclude(x => x.DesignOptions);
        }

        public ServiceWithTypeSpec(int id) 
        : base(x => x.Id == id)
        {
            AddInclude(x => x.ServiceType);
            AddInclude(x => x.CommType);
            AddInclude(x => x.DesignOptions);
        }
    }
}