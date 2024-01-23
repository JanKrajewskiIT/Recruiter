﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Questions.Application.Command;
using Questions.Application.Models;
using Questions.Application.Queries;
using Questions.Domain.Enums;

namespace Questions.Api.Endopoints;

internal static class OfferEndpoints
{
    public static WebApplication MapOfferEndpoints( this WebApplication app )
    {
        var group = app
            .MapGroup( "/offers" )
            .WithOpenApi()
            .RequireAuthorization();

        group.MapGet( "/statuses", () => Enum.GetNames<OfferStatus>() )
            .WithName( "GetOfferStatuses" );

        group.MapGet( "/", async ( [FromQuery] OfferStatus status, IMediator mediator ) => 
                await mediator.Send( new GetOffersQuery( status ) ) )
            .WithName( "GetOffers" );

        group.MapPost( "/", async ( Offer offer, IMediator mediator ) =>
            await mediator.Publish( new AddOfferCommand( offer ) ) );

        return app;
    }
}
