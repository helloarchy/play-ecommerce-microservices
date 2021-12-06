﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> Items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow),
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return Items;
        }

        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            var item = Items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price,
                DateTimeOffset.UtcNow);
            Items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
        }
    }
}