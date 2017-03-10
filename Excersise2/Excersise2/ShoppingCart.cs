using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersise2
{
    public class ShoppingCart
    {
        private List<Discount> _discounts = new List<Discount>();
        private List<Item> _items = new List<Item>();

        public decimal Total => CalculateTotal();

        public void AddDiscount(decimal minimumAmount, decimal discountPercentage)
        {
            _discounts.Add(new Discount(minimumAmount, discountPercentage));
        }

        public void AddItem(decimal price, int quantity)
        {
            _items.Add(new Item(price, quantity));
        }

        private decimal CalculateTotal()
        {
            var total = _items.Sum(item => item.Price * item.Quantity);
            var discountToApply =
                _discounts.Where(discount => discount.MinimumAmount < total)
                    .OrderByDescending(discount => discount.MinimumAmount)
                    .FirstOrDefault();

            if (discountToApply != null)
            {
                total -= total * discountToApply.DiscountPercentage / 100;
            }

            return total;
        }
    }

    internal class Item
    {
        public decimal Price { get; }

        public int Quantity { get; }

        public Item(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }

    internal class Discount
    {
        public decimal MinimumAmount { get; }
        public decimal DiscountPercentage { get; }

        public Discount(decimal minimumAmount, decimal discount)
        {
            MinimumAmount = minimumAmount;
            DiscountPercentage = discount;
        }
    }
}
