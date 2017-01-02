// redisService.js
var redis = require("redis");
var config = require('../config');
var client = redis.createClient(6380, config.redisUrl, 
    {auth_pass: config.redisPass, tls: {servername: config.redisUrl}});

module.exports = {
    add: function(document){
        console.log("redisService add was called");
    },
    get: function(key, callback){
        client.get(key, function(err, reply){
            console.log("ipStat key: " + reply);
            callback(reply);
        });
    }
}