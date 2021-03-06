﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Commands
{
    public class UpdateContact : IRequest
    {
        public UpdateContact(Guid contactId, string firstName, string lastName, string phone, string email)
        {

            ContactId = contactId; ;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        public Guid ContactId { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public string Phone { get; }

        public string Email { get; }

    }

}
