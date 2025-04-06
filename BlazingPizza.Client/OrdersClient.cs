using System.Net.Http.Json;

namespace BlazingPizza.Client
{
    public class OrdersClient
    {
        private readonly HttpClient httpClient;

        public OrdersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderWithStatus>> GetOrdersAsync() =>
            await httpClient.GetFromJsonAsync("orders", OrderContext.Default.ListOrderWithStatus) ?? new();

        public async Task<OrderWithStatus> GetOrderAsync(int orderId) =>
            await httpClient.GetFromJsonAsync($"orders/{orderId}", OrderContext.Default.OrderWithStatus) ?? new();

        public async Task<int> PlaceOrderAsync(Order order)
        {
            var response = await httpClient.PostAsJsonAsync("orders", order, OrderContext.Default.Order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }
    }
}
