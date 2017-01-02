var Twitter = require('twitter');

var client = new Twitter({
  consumer_key: 'jfZ2SH51lrZvLnMFAzkiCpy6m',
  consumer_secret: 'EMmxNiMljAKQCS4xg9StZN5IKa9CoFeOz4dZbvaGrjfphKc2Iw',
  access_token_key: '6543672-TXOxUNLBFlEEBA6js0jjGdL8UkMYroUVbQRtZoKo4B',
  access_token_secret: 'x8LYi7QcB0santBYoH28Vk9KDfkr6P3BXx9MWcvQiz6aU'
});

// var params = {screen_name: 'nodejs'};
// client.get('statuses/user_timeline', params, function(error, tweets, response) {
//   if (!error) {
//     console.log(tweets);
//   }
// });

// Load your image
var data = require('fs').readFileSync('nerd_logo.png');

if (data instanceof Buffer) console.log("Data is a buffer");

// Make post request on media endpoint. Pass file data as media parameter
// client.post('media/upload', {media: data}, function(error, media, response) {

//   if (!error) {

//     // If successful, a media object will be returned.
//     console.log(media);

//     // Lets tweet it
//     var status = {
//       status: 'I am a tweet',
//       media_ids: media.media_id_string // Pass the media id string
//     }

//     client.post('statuses/update', status, function(error, tweet, response) {
//       if (!error) {
//         console.log(tweet);
//       }
//     });

//   }
// });