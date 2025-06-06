﻿using ProjectPrn222.Models;
using ProjectPrn222.Models.DTO;

namespace ProjectPrn222.Service.Iterface
{
    public interface IProductService
    {
        int AddProduct(Product product);
        void AddPriceForProduct(ProductPrice productPrice);
        void DeleteProduct(Product product);
        void EditProduct(Product product);
        IQueryable<ProductViewModel> GetAllProducts();
        ProductViewModel? GetProductById(int id);
        Product? GetProductModelById(int id);
        IQueryable<ProductViewModel>? SearchProduct(string keyword);
        IQueryable<Category> GetAllCategories();
        bool HasProductName(string productName, int productId);
    }
}
