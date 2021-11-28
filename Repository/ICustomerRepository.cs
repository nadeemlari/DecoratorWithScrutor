namespace DecoratorWithScrutor.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid id);
    }

    class CustomerRepository : ICustomerRepository
    {
        private readonly List<CustomerDto> _customer = new List<CustomerDto>
        {
            new CustomerDto
            {
                Id = Guid.Parse("F060264A-13BA-41B7-A1A0-D98D3A2BE8DC"),
                Name = "Nadeem"
            } ,
            new CustomerDto
            {
                Id = Guid.Parse("61DA9361-B7C4-4F42-BE6F-227D155FB988"),
                Name = "Izaan"
            }
        };
        public Task<CustomerDto> GetCustomerAsync(Guid id)
        {
            return Task.FromResult(_customer.SingleOrDefault(x => x.Id == id));
        }
    }
}
