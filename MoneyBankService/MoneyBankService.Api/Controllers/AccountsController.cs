using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyBankService.Application.Dtos;
using MoneyBankService.Application.Interfaces.Services;
using MoneyBankService.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyBankService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> Get()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(_mapper.Map<List<Account>, List<AccountDto>>(accounts));
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> GetAccounts([FromQuery] string accountNumber = null!)
        {
            var accounts = await _accountService.GetAccountsByAccountNumberAsync(accountNumber);
            return Ok(_mapper.Map<List<Account>, List<AccountDto>>(accounts));
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int accountid)
        {
            var account = await _accountService.GetAccountByIdAsync(accountid);
            return Ok(_mapper.Map<Account, AccountDto>(account));
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<AccountDto>> Post([FromBody] AccountDto accountDto)
        {
            var newAccount = await _accountService.CreateAccountAsync(_mapper.Map<AccountDto, Account>(accountDto));

            return Ok(_mapper.Map<Account, AccountDto>(newAccount));
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AccountDto accountDto)
        {
            await _accountService.UpdateAccount(id, _mapper.Map<AccountDto, Account>(accountDto));

            return NoContent();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _accountService.DeleteAccountAsync(id);

            return NoContent();
        }
    }
}
