using Newtonsoft.Json;

namespace Project.MVCUI.Models.ShoppingTools
{
    [Serializable]
    public class Cart
    {
        readonly new Dictionary<int, CartItem> _myCart;
        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();
        }
        public List<CartItem> CartItems
        {
            get
            { 
                return _myCart.Values.ToList();
            }
        }
        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                _myCart[item.ID].Amount++;
                return;
            }
            _myCart.Add(item.ID, item);
        }
        public void Decrease(int id)
        {
            _myCart[id].Amount--;
            if (_myCart[id].Amount == 0) _myCart.Remove(id);
        }
        public void RemoveFromCart(int id)
        {
            _myCart.Remove(id);
        }
        [JsonProperty("TotalPrice")]
        public decimal TotalPrice 
        {
            get
            {
                return _myCart.Values.Sum(x =>x.SubTotal);
            }
        }
    }
}
