using Dapper;
using MyDapper.Context;
using MyDapper.Dtos.CategoryDtos;
using MyDapper.Dtos.ProductDtos;

namespace MyDapper.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "insert into Products (ProductName, ProductStock, ProductPrice) values (@productName,@productStock, @productPrice)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", createProductDto.ProductName);
            parameters.Add("@productStock", createProductDto.ProductStock);
            parameters.Add("@productPrice", createProductDto.ProductPrice);
            var connection= _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "Delete From Products Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDto>> GetallProductAsync()
        {
            string query = "Select * From Products";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            string query = "Select * From Products Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, parameters);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            string query = "update Products set ProductName=@productName, ProductStock=@productStock, ProductPrice=@productPrice where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", updateProductDto.ProductName);
            parameters.Add("@productStock", updateProductDto.ProductStock);
            parameters.Add("@productPrice", updateProductDto.ProductPrice);
            parameters.Add("@productId", updateProductDto.ProductId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
