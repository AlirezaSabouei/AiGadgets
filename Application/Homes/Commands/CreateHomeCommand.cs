using Application.Common.Data;
using Application.Homes.Queries;
using Domain.Homes.Entities;
using Domain.Homes.Exceptions;
using MediatR;

namespace Application.Homes.Commands;

public record CreateHomeCommand : IRequest<Home>
{
    public required Home Home { get; set; }
}

public class CreateHomeCommandHandler(
    IRequestHandler<GetHomesQuery, List<Home>> getHomesQueryHandler,
    IDocumentStore<Home> documentStore) : IRequestHandler<CreateHomeCommand, Home>
{
    public async Task<Home> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
    {
        await ValidateHomeNameToBeUnique(request.Home);
        await documentStore.InsertAsync(request.Home);
        return request.Home;
    }

    private async Task ValidateHomeNameToBeUnique(Home home)
    {
        List<Home> existingHomes = await GetExistingUserHomes(home.UserId, home.Name);
        if (existingHomes.Any())
        {
            throw new HomeNameIsNotUniqueException(home.Name);
        }
    }

    private async Task<List<Home>> GetExistingUserHomes(Guid userId, string name)
    {
        var query = new GetHomesQuery
        {
            UserId = userId,
            Name = name
        };
        return await getHomesQueryHandler.Handle(query, CancellationToken.None);
    }
}
