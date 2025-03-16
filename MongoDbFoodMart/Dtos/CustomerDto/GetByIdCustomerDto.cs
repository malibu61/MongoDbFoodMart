namespace MongoDbFoodMart.Dtos.CustomerDto
{
    public class GetByIdCustomerDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string DepartmentId { get; set; }
    }
}
