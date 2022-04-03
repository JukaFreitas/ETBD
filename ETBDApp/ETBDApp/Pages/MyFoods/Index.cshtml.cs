namespace ETBDApp.Pages.MyFoods
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDDbContext context)
        {
            _context = context;
        }
        public List<Food> Foods { get; set; }

        [Display(Name = "Action")]
        public SelectList Actions { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }

        [BindProperty]
        public int SelectedActionId    { get; set; }



        public async Task OnGetAsync(int SelectedCategoryId, int SelectedActionId)
        {
            this.Actions = new SelectList(_context.Actions, "Id", "Name"); 
            this.Categories = new SelectList(_context.Categories, "Id", "Name");
            
            if(SelectedCategoryId!=0)
            {
                Foods = await _context.Foods.Where(f => f.Category.Id == SelectedCategoryId).ToListAsync(); 
            }
            else
            {
                Foods = await _context.Foods.Include(f => f.Category).ToListAsync();
            }

            if(SelectedActionId != 0)
            {
                var actionsFoodId = await _context.ActionFoods.Where(af => af.ActionId == SelectedActionId).Select(af => af.FoodId).ToListAsync();
                Foods = Foods.Where(f => actionsFoodId.Contains(f.Id)).ToList(); 
            }
            
           
        }
    }
}
