﻿using PackIt.Domain.Events;
using PackIt.Domain.Exceptions;
using PackIt.Domain.ValueObject;
using PackIt.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.Entities
{
    public class PackingList : AggregateRoot<PackingListId>
    {
        public PackingListId Id { get; private set; }
        private PackingListName _name;
        private Localization _localization;
        private readonly LinkedList<PackingItem> _items = new();
        private PackingList()
        {
            
        }
        public PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
            :this(id, name, localization)
        {
            _items = items;
        }
        public PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }
        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(i => i.Name == item.Name);
            if (alreadyExists)
            {
                throw new PackingItemAlreadyExistsException(_name, item.Name);
            }
            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }
        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }
        
        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };

            _items.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this, item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }
        private PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);
            if (item == null)
            {
                throw new PackingItemNotFoundException(itemName);
            }

            return item;
        }
    }
}
