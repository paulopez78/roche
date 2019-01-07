using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyWebSockets;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Lib;

namespace VotingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly Voting _voting;
        private readonly IWebSocketPublisher _wsPublisher;

        public VotingController(Voting voting, IWebSocketPublisher webSocketPublisher)
        {
            _voting = voting;
            _wsPublisher = webSocketPublisher;
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
            var votingState = _voting.GetState();
            _wsPublisher.SendMessageToAllAsync(votingState);
            return votingState;
        }

        [HttpPut]
        public object Vote([FromBody] string option)
        {
            _voting.Vote(option);
            var votingState = _voting.GetState();
            _wsPublisher.SendMessageToAllAsync(votingState);
            return votingState;
        }

        [HttpDelete]
        public object Finish()
        {
            _voting.Finish();
            var votingState = _voting.GetState();
            _wsPublisher.SendMessageToAllAsync(votingState);
            return votingState;
        }
    }
}
