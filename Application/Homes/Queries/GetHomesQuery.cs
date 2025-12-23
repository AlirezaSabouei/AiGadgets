using Application.Common.Data;
using Domain.Homes.Entities;
using MediatR;

namespace Application.Homes.Queries;

public class GetHomesQuery : IRequest<List<Home>>
{
    public string? Name { get; set; }
    public Guid UserId { get; set; }
}

public class GetHomesQueryHandler(IDocumentStore<Home> documentStore) : IRequestHandler<GetHomesQuery, List<Home>>
{
    public async Task<List<Home>> Handle(GetHomesQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return await documentStore
                .GetAsync(a => a.UserId == request.UserId, cancellationToken);
        }
        return await documentStore
            .GetAsync(a => a.Name == request.Name && a.UserId == request.UserId, cancellationToken);
    }
}
