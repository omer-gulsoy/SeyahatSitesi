﻿using DataAccessLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
				Name = values.Name,
                Status = values.Status,
				Description = values.Description,
                Description2 = values.Description2,
                TwitterUrl= values.TwitterUrl,
                InstagramUrl= values.InstagramUrl,
                Image= values.Image,
                GuideListImage= values.GuideListImage,
            };
        }
    }
}