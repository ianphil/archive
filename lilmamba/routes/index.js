var express = require('express');
var redisService = require('../services/redisService');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  redisService.get('ipStat', function(reply){
    res.render('index', { title: reply });
  });
});

module.exports = router;
