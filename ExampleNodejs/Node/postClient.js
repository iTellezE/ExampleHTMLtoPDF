
var root = 'https://jsonplaceholder.typicode.com';
var axios = require('axios');

module.exports = function (callback, page) {
    var commentsUrl = root + '/posts/' + page.toString();
    console.log("Calling Url :" + commentsUrl);
    axios.get(commentsUrl)
        .then(function (response) {
            callback(null, response.data);
        }).catch(function (err) {
            callback(err, null);
        });
};