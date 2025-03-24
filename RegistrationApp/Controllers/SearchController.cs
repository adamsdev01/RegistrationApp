using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationApp.Controllers
{
    public class SearchController : Controller
    {
        // Replace with your actual data model
        public class SearchResult
        {
            public string Name { get; set; }
            public string AccountNumber { get; set; }
            // Add other properties as needed
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchForm()
        {
            return PartialView("_SearchForm");
        }

        [HttpPost]
        public ActionResult PerformSearch(string firstName, string lastName, string accountNumber)
        {
            try
            {
                // Simulate database search (replace with your actual data access logic)
                List<SearchResult> results = new List<SearchResult>();
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    //search by name
                    results = SimulateSearchByName(firstName, lastName);
                }
                else if (!string.IsNullOrEmpty(accountNumber))
                {
                    //search by acccount
                    results = SimulateSearchByAccountNumber(accountNumber);
                }
                if (results.Any())
                {
                    return PartialView("_SearchResults", results);
                }
                else
                {
                    return Content("<p>No results found.</p>");
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (log, etc.)
                // Return an error message or empty results
                Console.WriteLine(ex.Message);
                return Content("<p>There was an error processing your request.</p>");
            }
        }

        // Simulate search functions, in a real app you would replace it with database access logic
        private List<SearchResult> SimulateSearchByName(string firstName, string lastName)
        {
            List<SearchResult> results = new List<SearchResult>();
            if (firstName.ToLower() == "john" && lastName.ToLower() == "doe")
            {
                results.Add(new SearchResult { Name = "John Doe", AccountNumber = "12345" });
            }
            if (firstName.ToLower() == "jane" && lastName.ToLower() == "doe")
            {
                results.Add(new SearchResult { Name = "Jane Doe", AccountNumber = "67890" });
            }

            return results;
        }
        private List<SearchResult> SimulateSearchByAccountNumber(string accountNumber)
        {
            List<SearchResult> results = new List<SearchResult>();
            if (accountNumber == "12345")
            {
                results.Add(new SearchResult { Name = "John Doe", AccountNumber = "12345" });
            }
            if (accountNumber == "67890")
            {
                results.Add(new SearchResult { Name = "Jane Doe", AccountNumber = "67890" });
            }
            if (accountNumber == "99999")
            {
                results.Add(new SearchResult { Name = "Test user", AccountNumber = "99999" });
            }

            return results;
        }
    }
}