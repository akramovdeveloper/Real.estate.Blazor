﻿using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.LocatedNearbies.Queries;
public class GetByIdLocatedNeardyQuery : IRequest<LocatedNearby>
{
    public Guid LocatedNeardyId { get; set; }
}

public class GetByIdLocatedNeardyQueryHandler : IRequestHandler<GetByIdLocatedNeardyQuery, LocatedNearby>
{
    private readonly IApplicationDbContext _context;

    public GetByIdLocatedNeardyQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<LocatedNearby> Handle(GetByIdLocatedNeardyQuery request, CancellationToken cancellationToken)
    {
        var locatedNearby = await _context.LocatedNearbies.FindAsync(new object[] { request.LocatedNeardyId }, cancellationToken);
        if (locatedNearby is null)
            throw new NotFoundException();
        
        return locatedNearby;
    }
}
