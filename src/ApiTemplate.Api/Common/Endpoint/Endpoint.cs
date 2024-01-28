using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Api.Common.Endpoint;

public sealed class Endpoint
{
    public abstract class WithRequest<TRequest> : EndpointBase
    { 
        protected WithRequest(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        
        public abstract void AddRoute(IEndpointRouteBuilder app);

        public abstract Task<IResult> HandleAsync(
            ISender mediator,
            IMapper mapper,
            TRequest request,
            CancellationToken ct = default);
    }

    public abstract class WithoutRequest : EndpointBase
    {
        protected WithoutRequest(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public abstract Task<ActionResult> HandleAsync(
            ISender mediator,
            IMapper mapper,
            CancellationToken cancellationToken = default);
    }
}