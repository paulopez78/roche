using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Lib;

namespace VotingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly Voting _voting;

        public VotingController(Voting voting)
        {
            _voting = voting;
        }

        [HttpGet]
        public object Get()
        {
            return _voting.GetState();
        }

        [HttpPost]
        public object Start([FromBody] string[] options)
        {
            _voting.Start(options);
            return _voting.GetState();
        }

        [HttpPut]
        public object Vote([FromBody] string option)
        {
            _voting.Vote(option);
            return _voting.GetState();
        }

        [HttpDelete]
        public object Finish()
        {
            _voting.Finish();
            return _voting.GetState();
        }
    }
}
