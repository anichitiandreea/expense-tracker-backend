﻿using expense_tracker_backend.Domain;
using expense_tracker_backend.Services.Interfaces;
using expense_tracker_backend.Transfer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace expense_tracker_backend.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("accounts")]
        public async Task<ActionResult> GetAllAsync()
        {
            var accounts = await accountService.GetAllAsync();

            if (accounts is null)
            {
                return NotFound();
            }

            return Ok(accounts);
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var account = await accountService.GetByIdAsync(id);

            if (account is null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        [Route("accounts")]
        public async Task<ActionResult> CreateAsync([FromBody] AccountRequest accountRequest)
        {
            if (accountRequest is null)
            {
                return BadRequest();
            }

            var account = new Account
            {
                Name = accountRequest.Name,
                Icon = accountRequest.Icon,
                IconColor = accountRequest.IconColor,
                Amount = Convert.ToDouble(accountRequest.Amount),
                CurrencyId = accountRequest.CurrencyId
            };

            await accountService.CreateAsync(account);

            return StatusCode(201, account);
        }
    }
}