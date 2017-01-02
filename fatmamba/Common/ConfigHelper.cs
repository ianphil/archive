using System;

namespace fatmamba.Common
{
    public static class ConfigHelper
    {
        public const string ArtisitList = "ArtistList";
        public const string BattleList = "BattleList";
        public const string Passcode = "fatmamba";
        public const string BattleTimerUrl = "https://fatmamba.azurewebsites.net/api/BattleTimer?code=kDepyWcO5SSReQj6HXhDalDkEPW5MKWkjXHitFqQbKffUrIlBa6VTQ==&seconds=900";
        public const string IntermissionTimerUrl = "https://fatmamba.azurewebsites.net/api/BattleTimer?code=kDepyWcO5SSReQj6HXhDalDkEPW5MKWkjXHitFqQbKffUrIlBa6VTQ==&seconds=600";
        public const string AzureCache = "fatmamba.redis.cache.windows.net:6380,password=aYkC8TJsYHN7PjUgdVdzsovsIlJK2M3SBvf/LAsFIUo=,ssl=True,abortConnect=False";
    }
}