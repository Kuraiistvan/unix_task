using System.Linq.Expressions;

namespace Core.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }

    Expression<Func<T, object>>? OrderBy { get; }

    Expression<Func<T, object>>? OrderByDesc { get; }

    Expression<Func<T, bool>>? PriceBetween { get; }

    IQueryable<T> ApplyCriteria(IQueryable<T> query);

    int Take { get; }

    int Skip { get; }

    bool IsPagingEnabled { get; }
}