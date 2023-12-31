﻿using Microsoft.AspNetCore.Mvc;
using PackIt.Shared.Abstractions.Commands;
using PackIt.Shared.Abstractions.Queries;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackIT.Api.Controllers
{
    public class PackingListController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public PackingListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
        [HttpGet("test/{fromRoute:guid}")]
        public async Task<ActionResult> GetTest([FromRoute] Guid fromRoute)
        {
            return Ok(fromRoute);
        }
    }
}
