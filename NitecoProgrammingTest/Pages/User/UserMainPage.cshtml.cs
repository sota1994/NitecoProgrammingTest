using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NitecoProgrammingTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoProgrammingTest.Pages.User
{
    public class UserMainPageModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserMainPageModel> _logger;

        public UserMainPageModel(AppDbContext context, ILogger<UserMainPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }
        public List<Order> AllOrderList { get; set; }
        public List<SelectListItem> ProductNameListItem { get; set; }

        public List<SelectListItem> CustomerNameListItem { get; set; }
        public void OnGet()
        {
            AllOrderList = _context.Orders
                                   .Include(o => o.Customer)
                                   .Include(o => o.Product)
                                   .ThenInclude(o => o.Category)
                                   .ToList();
            ProductNameListItem = _context.Products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            }).ToList();

            CustomerNameListItem = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();

        }
        public List<Order> GetAllOrders(string categoryName = null)
        {
            if (categoryName != null)
            {
                return _context.Orders
                            .Include(o => o.Customer)
                            .Include(o => o.Product)
                            .ThenInclude(o => o.Category)
                            .Where(o => o.Product.Category.Name.ToLower().Contains(categoryName.ToLower()))
                            .ToList();
            }
            else
            {
                return _context.Orders
                            .Include(o => o.Customer)
                            .Include(o => o.Product)
                            .ThenInclude(o => o.Category)
                            .ToList();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            AllOrderList = GetAllOrders();
            ProductNameListItem = _context.Products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            }).ToList();

            CustomerNameListItem = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();


            if (ModelState.IsValid)
            {

                var product = _context.Products.Find(Order.ProductId);
                if (Order.Amount <= product.Quantity)
                {
                    try
                    {
                        //Order.Id = _context.Orders.Count();
                        await _context.Orders.AddAsync(Order);
                        var result = await _context.SaveChangesAsync();
                        return RedirectToPage("./UserMainPage");
                    }
                    catch (DbUpdateException ex)
                    {
                        _logger.LogError(ex.Message);
                        ErrorMessage = ex.Message;
                    }
                }
                else
                {
                    ErrorMessage = "The amount of the order is greater than the quantity of the product";
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostFindOrdersByCategoryAsync()
        {
            var categoryName = Request.Form["categoryName"].ToString();
            AllOrderList = GetAllOrders(categoryName);
            ProductNameListItem = _context.Products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            }).ToList();

            CustomerNameListItem = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
            //Debug.WriteLine("here");
            return Page();
        }
    }
}
