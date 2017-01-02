using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace fatmamba.Common
{
    public class RedisHelper
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisHelper()
        {
            _redis = ConnectionMultiplexer.Connect(ConfigHelper.AzureCache);
            _db = _redis.GetDatabase();
        }

        public int GetDatabase()
        {
            return _db.Database;
        }

        public bool UserExist(string userId)
        {
            return _db.KeyExists(userId);
        }

        public void AddOrUpdateUser(string userId, int voteWeight)
        {
            _db.StringSet(userId, voteWeight);
        }

        public int GetUserVoteWeight(string userId)
        {
            return Convert.ToInt32(_db.StringGet(userId));
        }

        public void AddVoteForArtist(string artistId, int voteWeight)
        {
            _db.SetAdd(artistId, voteWeight);
        }

        public void AddOrUpdateArtist(Artist artist)
        {
            var data = JsonConvert.SerializeObject(artist);
            
            if (String.IsNullOrEmpty(artist.ArtistId))
            {
                var rand = new Random();
                artist.ArtistId = rand.Next(1, 1000).ToString();
                AddToArtistSet(artist.ArtistId);
            }

            _db.StringSet(artist.ArtistId, data);
        }

        public void AddToArtistSet(string artistId)
        {
            _db.SetAdd(ConfigHelper.ArtisitList, artistId);
        }

        public List<string> GetArtistSet()
        {
            List<string> artistList = new List<string>();
            var artists = _db.SetMembers(ConfigHelper.ArtisitList);

            foreach (var artist in artists)
                artistList.Add(artist);

            return artistList;
        }

        public Artist GetArtist(string artistId)
        {
            return JsonConvert.DeserializeObject<Artist>(_db.StringGet(artistId));
        }
    }
}