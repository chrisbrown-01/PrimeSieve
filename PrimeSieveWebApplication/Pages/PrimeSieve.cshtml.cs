using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrimeSieveWebApplication.Pages
{
    public class PrimeSieveModel : PageModel
    {
        private readonly ILogger<PrimeSieveModel> _logger;

        public PrimeSieveModel(ILogger<PrimeSieveModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}