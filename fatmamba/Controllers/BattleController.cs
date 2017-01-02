using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using fatmamba.Models;
using fatmamba.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fatmamba.Controllers
{
    [Route("api/[controller]")]
    public class BattleController : Controller
    {
        // POST api/values/getstatus
        [HttpPost("getstatus")]
        public IActionResult GetStatus()
        {
            string requestData = String.Empty;
            using(var reader = new StreamReader(Request.Body))
            {
                requestData = reader.ReadToEnd();
            }

            Passcode passcode = JsonConvert.DeserializeObject<Passcode>(requestData);

            if (passcode.Code != ConfigHelper.Passcode)
            {
                return Unauthorized();
            }

            //TODO: Get Data from Redis
            Battle battle = new Battle();
            battle.BattleStatus = Status.battle;
            battle.BattleName = "Battle One";
            battle.TimeLeft = new TimeSpan(0, 14, 32);

            return Json(battle);
        }

        // POST api/values/getstatus
        [HttpPost("vote")]
        public IActionResult Vote()
        {
            // Read data from request
            string requestData = String.Empty;
            using(var reader = new StreamReader(Request.Body))
            {
                requestData = reader.ReadToEnd();
            }

            // Request data has to be formed to match Vote
            Vote vote = JsonConvert.DeserializeObject<Vote>(requestData);

            // Simple Passcode check...
            if (vote.Passcode.Code != ConfigHelper.Passcode)
            {
                return Unauthorized(); //401
            }

            var db = new RedisHelper();
            int userVoteWeight;

            //Add User if not exist w/ vote count
            if (db.UserExist(vote.UserId))
            {
                userVoteWeight = 100;
                db.AddOrUpdateUser(vote.UserId, userVoteWeight);
            }
            else
            {
                userVoteWeight = db.GetUserVoteWeight(vote.UserId);
            }

            if (userVoteWeight != 1)
            {
                //Add Vote
                db.AddVoteForArtist(vote.ArtistId, userVoteWeight);

                //Decrement user vote, stops at 1
                userVoteWeight--;
                db.AddOrUpdateUser(vote.UserId, userVoteWeight);

                //TODO: Error decrement or vote
            }
            else 
            {
                //Add Vote of 1
                db.AddVoteForArtist(vote.ArtistId, userVoteWeight);
            }

            //Vote Was Successful
            return Ok(); //200
        }
    }
}