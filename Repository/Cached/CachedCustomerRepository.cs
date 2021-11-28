using System.Collections.Concurrent;

namespace DecoratorWithScrutor.Repository.Cached
{
    public class CachedCustomerRepository :ICustomerRepository
    {
        private readonly ICustomerRepository _repository;
        private readonly ConcurrentDictionary<Guid, CustomerDto> _cache = new();
        public CachedCustomerRepository(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerDto> GetCustomerAsync(Guid id)
        {
            if (_cache.ContainsKey(id))
                return _cache[id];

            CustomerDto customer = await _repository.GetCustomerAsync(id);
            _cache.TryAdd(id, customer);
            return customer;
        }
    }
}
