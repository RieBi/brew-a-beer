﻿using Application.DTOs;
using Application.Queries.BrewerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrewerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [Route("{id}/Beers")]
    public async Task<IList<BeerDto>?> Beers(string id)
    {
        var beers = await _mediator.Send(new GetAllBeersByBrewerQuery(id));

        return beers;
    }
}