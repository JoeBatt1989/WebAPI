using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Data;
using WebAPI.Models;
using static WebAPI.Enums.Enums;

namespace WebAPI.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly List<Client> clients;

        private readonly List<Address> addresses;

        private readonly List<Car> cars;

        public ClientController(InitData initData)
        {
            this.clients = initData.clients;

            this.addresses = initData.addresses;

            this.cars = initData.cars;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult Get(Guid id)
        {
            var client = clients.Find(c => c.Id.Equals(id));

            if (client.Id != null)
            {
                return Ok(client);
            }
            else
            {
                return NotFound("Client not found");
            }
        }

        [HttpPost]
        public IActionResult PostClient([FromBody] ClientRequest request)
        {
            var requestError = IsRequestValid(request);

            if (requestError == null)
            {
                var client = this.CreateClient(request);
                this.clients.Add(client);
                return Ok(client);
            }
            else
            {
                return requestError;
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutClient(Guid id, [FromBody] ClientRequest request)
        {
            var requestError = IsRequestValid(request);

            if (requestError == null)
            {
                var client = clients.Find(c => c.Id.Equals(id));
                client.FirstName = request.FirstName;
                client.LastName = request.LastName;
                client.Email = request.Email;
                return Ok(client);
            }
            else
            {
                return requestError;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            var client = clients.Find(c => c.Id.Equals(id));

            if (client.Id != null)
            {
                clients.RemoveAll(c => c.Id == id);
                addresses.RemoveAll(a => a.ClientId == id);
                cars.RemoveAll(c => c.ClientId == id);
                return Ok("Client deleted successfully");
            }
            else
            {
                return NotFound("Client not found");
            }
        }

        private IActionResult IsRequestValid(ClientRequest request)
        {
            if (request.FirstName == null || request.LastName == null || request.Email == null)
            {
                return BadRequest("Please enter all mandatory details for client");
            }

            if (!Enum.IsDefined(typeof(Title), request.Title))
            {
                return BadRequest("Title is not valid");
            }

            ContactDetails contactDetails = new ContactDetails()
            {
                PhoneType = request.ContactDetails.PhoneType,
                PhoneNumber = request.ContactDetails.PhoneNumber
            };

            if (contactDetails.PhoneNumber == null)
            {
                return BadRequest("Please enter all mandatory details for client");
            }

            if (!Enum.IsDefined(typeof(PhoneType), contactDetails.PhoneType))
            {
                return BadRequest("Phone type is not valid");
            }

            if (!IsValidEmailAddress(request.Email))
            {
                return BadRequest("Email Address is not valid");
            }

            return null;
        }

        private bool IsValidEmailAddress(string email) => email != null && new EmailAddressAttribute().IsValid(email);

        private Client CreateClient(ClientRequest request)
        {
            Client client = new Client();
            client.Id = Guid.NewGuid();
            client.Title = request.Title;
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Email = request.Email;

            ContactDetails contactDetails = new ContactDetails()
            {
                PhoneType = request.ContactDetails.PhoneType,
                PhoneNumber = request.ContactDetails.PhoneNumber
            };

            client.ContactDetails = contactDetails;
            return client;
        }
    }
}
