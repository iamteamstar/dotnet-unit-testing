using Microsoft.AspNetCore.Mvc;
using xUnitTestWithMVC.Models;
using xUnitTestWithMVC.Repository;

namespace xUnitTestWithMVC.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IRepository<Product> _productRepository;//iamteamstar: buradaki iþlemleri product üzerinde gerçekleþtireceðiz

		public ProductsController(IRepository<Product> productRepository)//iamteamstar: di uyguulanýyor. sen eðer IProductRepository ile karþýlaþýrsan, repositoty sýnýfýndan bir nesne örneði oluþtur 
		{
			_productRepository = productRepository;
		}

		// GET: Products
		public async Task<IActionResult> Index()
		{
			return View(await _productRepository.GetAllAsync());
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productRepository.GetByID((int)id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock,Color")] Product product)
		{
			if (ModelState.IsValid)
			{
				await _productRepository.Create(product);
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productRepository.GetByID((int)id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("Id,Name,Price,Stock,Color")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}
			if(ModelState.IsValid)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productRepository.GetByID((int)id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _productRepository.GetByID(id);
			if (product != null)
			{
				_productRepository.Delete(product);
			}
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			var product=_productRepository.GetByID(id).Result;
			if (product == null)
			{
				return false;
			}
			else
				return true;
		}
	}
}
