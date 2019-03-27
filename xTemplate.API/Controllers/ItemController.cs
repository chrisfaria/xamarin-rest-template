using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xTemplate.API.Models;

namespace xTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;


            if (_context.Items.Count() == 0)
            {
                // Creates new SubItems if the collection is empty to be inserted into the Items
                SubItem s1a = new SubItem { Name = "SubItem1a", IsComplete = true };
                SubItem s1b = new SubItem { Name = "SubItem1b", IsComplete = false };
                SubItem s1c = new SubItem { Name = "SubItem1c", IsComplete = false };

                SubItem s2a = new SubItem { Name = "SubItem2a", IsComplete = true };

                SubItem s3a = new SubItem { Name = "SubItem3a", IsComplete = true };
                SubItem s3b = new SubItem { Name = "SubItem3b", IsComplete = true };
                SubItem s3c = new SubItem { Name = "SubItem3c", IsComplete = false };
                SubItem s3d = new SubItem { Name = "SubItem3d", IsComplete = true };

                _context.SubItems.Add(s1a);
                _context.SubItems.Add(s1b);
                _context.SubItems.Add(s1c);
                _context.SubItems.Add(s2a);
                _context.SubItems.Add(s3a);
                _context.SubItems.Add(s3b);
                _context.SubItems.Add(s3c);
                _context.SubItems.Add(s3d);
                // Creates new Items if collection is empty,
                // which means you can't delete all Items.
                _context.Items.Add(new Item
                {
                    Name = "Item1",
                    Desc = "This is the first item",
                    SubItems = new List<SubItem> { s1a, s1b, s1c }
                });
                _context.Items.Add(new Item
                {
                    Name = "Item2",
                    Desc = "This is the second item",
                    SubItems = new List<SubItem> { s2a }
                });
                _context.Items.Add(new Item
                {
                    Name = "Item3",
                    Desc = "This is the third item",
                    SubItems = new List<SubItem> { s3a, s3b, s3c, s3d }
                });

                /*_context.Items.Add(new Item { 
                    Name = "Item1", 
                    Desc = "This is the first item",
                    SubItems = new List<SubItem> { new SubItem { Name = "SubItem1a", IsComplete = true },
                                                   new SubItem { Name = "SubItem1b", IsComplete = false },
                                                   new SubItem { Name = "SubItem1c", IsComplete = false } }
                });
                _context.Items.Add(new Item
                {
                    Name = "Item2",
                    Desc = "This is the second item",
                    SubItems = new List<SubItem> { new SubItem { Name = "SubItem2a", IsComplete = true } }
                });
                _context.Items.Add(new Item
                {
                    Name = "Item3",
                    Desc = "This is the third item",
                    SubItems = new List<SubItem> { new SubItem { Name = "SubItem3a", IsComplete = true },
                                                   new SubItem { Name = "SubItem3b", IsComplete = true },
                                                   new SubItem { Name = "SubItem3c", IsComplete = false },
                                                   new SubItem { Name = "SubItem3d", IsComplete = true } }
                });*/
                _context.SaveChanges();
            }
        }
       
        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Item/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var todoItem = await _context.Items.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
