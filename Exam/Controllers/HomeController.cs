using Exam.Context;
using Exam.Models;
using Exam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var customer = db.Customers.FirstOrDefault(x => userName == x.Login);

            var UserTickets = new UserTicketsModel { Name = customer.Name, Surname = customer.Surname, Balance = customer.Balance };

            UserTickets.UserTickets = db.Tickets.Where(x => x.CustomersID == customer.ID)
                .Include(y => y.Place).Include(z => z.Trip).ToList();
            return View(UserTickets);
        }

        [Authorize]
        public IActionResult GetAllPlaces() 
        {
            var Places = db.Places;
            return View(Places);
        }

        [Authorize]
        public IActionResult Buy(Place place)
        {
            var Place = db.Places.FirstOrDefault(x => x.ID == place.ID);
            var Ticket = new TicketModel { ID = Place.ID, Number = Place.Number,
                Status = Place.Status, TrainID = Place.TrainID, Type = Place.Type};
            Ticket.price = Ticket.Type ? 1000 : 500;
            return View(Ticket);
        }

        [Authorize]
        public IActionResult BuyConfirmed(TicketModel ticketModel) 
        {
            var userName = User.Identity.Name;
            var customer = db.Customers.FirstOrDefault(x => userName == x.Login);
            if (customer.Balance >= ticketModel.price)
            {
                customer.Balance -= ticketModel.price;
                db.Customers.Update(customer);
                
                var Ticket = new Ticket
                {
                    Customer = customer,
                    CustomersID = customer.ID,
                    DateOfBuying = System.DateTime.Now,
                    Place = db.Places.FirstOrDefault(x => x.ID == ticketModel.ID),
                    PlaceID = ticketModel.ID,
                    Price = ticketModel.price,
                    Trip = db.Trips.FirstOrDefault(x => x.ID == 1),
                    TripID = 1
                };
                db.Tickets.Add(Ticket);

                var Place = db.Places.FirstOrDefault(x => x.ID == ticketModel.ID);
                Place.Status = "Придбано";
                db.Places.Update(Place);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ReturnTicket(Ticket ticket)
        {
            var Ticket = db.Tickets.Include(y => y.Place).FirstOrDefault(x => x.ID == ticket.ID);
            var TicketModel = new TicketModel
            {
                ID = Ticket.ID,
                Number = Ticket.PlaceID,
                Status = Ticket.Place.Status,
                Type = Ticket.Place.Type,
                price = Ticket.Price
            };
            return View(TicketModel);
        }

        [Authorize]
        public IActionResult ReturnComfirmed(TicketModel ticketModel)
        {
            var userName = User.Identity.Name;
            var customer = db.Customers.FirstOrDefault(x => userName == x.Login);
            customer.Balance += (ticketModel.price/2);
            db.Customers.Update(customer);

            db.Tickets.Remove(db.Tickets.FirstOrDefault(x => x.ID == ticketModel.ID));

            var Place = db.Places.FirstOrDefault(x => x.ID == ticketModel.Number);
            Place.Status = "Доступний";
            db.Places.Update(Place);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}