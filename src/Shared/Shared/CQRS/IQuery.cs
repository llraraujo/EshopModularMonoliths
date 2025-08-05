
using MediatR;

namespace Shared.CQRS
{

    public interface IQuery: IQuery<Unit>
    {
    }

    public interface IQuery<out TResponse>: IRequest<TResponse>
    {
    }
}
