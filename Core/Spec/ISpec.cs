using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Spec
{
    public interface ISpec<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Includes {get;}
        
    }
}