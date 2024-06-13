using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get;} // where Criteria = predicate  
        List<Expression<Func<T, object>>> includes { get;}
    }
}
