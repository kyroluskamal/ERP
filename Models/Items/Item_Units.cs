﻿namespace ERP.Models.Items
{
    public class Item_Units
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Units Units { get; set; }
        public int? UnitsId { get; set; }
    }
}
