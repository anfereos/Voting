namespace Voting.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Voting.Web.Data;
    using Voting.Web.Data.Entities;

    public class EventsController : Controller
    {
        //19-3-19 reemplace el DataContext _context por el repositorio
        //private readonly DataContext _context;
        private readonly IRepository repository;

        public EventsController(IRepository repository)
        {
            //_context = context;
            this.repository = repository;
        }

        // GET: Events
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //return View(await repository.Events.ToListAsync());
            return View(this.repository.GetEvents());
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            var @event = this.repository.GetEvent(id.Value);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,StarDate,EndDate")] Event @event)
        public async Task<IActionResult> Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(@event);
                this.repository.AddEvent(@event);
                //await _context.SaveChangesAsync();
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var @event = await _context.Events.FindAsync(id);
            var @event = this.repository.GetEvent(id.Value);

            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event @event)
        {
            //if (id != @event.Id)
            if (ModelState.IsValid)
            {
                //return NotFound();
                try
                {
                    this.repository.UpdateEvent(@event);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            /*if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);*/
            return View(@event);
        }

        // GET: Events/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var @event = await _context.Events
            //.FirstOrDefaultAsync(m => m.Id == id);
            var @event = this.repository.GetEvent(id.Value);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var @event = await _context.Events.FindAsync(id);
            var @event = this.repository.GetEvent(id);
            //_context.Events.Remove(@event);
            this.repository.RemoveEvent(@event);
            //await _context.SaveChangesAsync();
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

        /*private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }*/
    }
}
