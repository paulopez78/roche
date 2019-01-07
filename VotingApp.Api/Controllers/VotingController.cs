using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyWebSockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VotingApp.Lib;

namespace VotingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly Voting _voting;
        private readonly IWebSocketPublisher _wsPublisher;
        private readonly int _votingStep;
        private readonly ILogger<VotingController> _logger;

        public VotingController(Voting voting, IWebSocketPublisher webSocketPublisher, IOptions<VotingOptions> votingOptions, ILogger<VotingController> logger)
        {
            _voting = voting;
            _wsPublisher = webSocketPublisher;
            _votingStep = votingOptions.Value.VotingStep;
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            return _voting.GetState();
        }

        [HttpPost]
        public object Start([FromBody] string[] options)
        {
            _logger.LogWarning("Starting VOTING!");
            _voting.Start(options);
            var votingState = _voting.GetState();
            _wsPublisher.SendMessageToAllAsync(votingState);
            return votingState;
        }

        [HttpPut]
        public object Vote([FromBody] string option)
        {
            _voting.Vote(option, _votingStep);
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
