
const express = require('express');
const app = express();

class Character {
    constructor(level, sport, url) {
      this.level = level;
      this.sport = sport;
      this.url = url;
    }
}

const characters =[
    new Character(1, "basketball", "https://ipfs.io/ipfs/QmeagtLJpQR7kEC5FNFT2iWPp2ENFboPfCirevt9iT2UXZ?filename=spock.zip"),
    new Character(2, "football", "https://www.google.ca")
]

app.get('/characters', (req, res) => {
    res.send(JSON.stringify(characters))
});



// app.get('/gears')






app.listen(3000, function () {
    console.log("Server started...");
});
