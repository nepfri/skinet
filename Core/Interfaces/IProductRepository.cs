﻿using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIDAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductType>> GetTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
    }
}
