function solve(songsData) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    let numberOfSongs = songsData.shift();

    for (let i = 0; i < numberOfSongs; i++) {
        let [typeList, name, time] = songsData.shift().split('_');
        let currentSong = new Song(typeList, name, time);
        
        songs.push(currentSong);
    }

    let playlistToPlay = songsData.shift();

    if (playlistToPlay == 'all') {
        for (let song of songs) {
            console.log(song.name);
        }        

    } else {
        for (let song of songs) {
            if(song.typeList == playlistToPlay) {
                console.log(song.name);
            }
        }
    }   
}


solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']);

solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    );