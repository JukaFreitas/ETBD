namespace ETBDApp.Pages.MyNutritionStatistics
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            
        }
    }
}
