module.exports = {
    configure: function (app, express, os, server) {
        getMappings(app, express);
        start(os, server);
    }
};

function getMappings(app, express) {
    var currentPlatform = process.platform;
    var dirSeparator = currentPlatform === 'win32' ? '\\' : '/';
    var applicationRootDir = __dirname.replace(dirSeparator + 'server', '');
        
    // create virtual dir mappings
    // serve index.html on root requests
    app.get('/', function (req, res) {
        res.sendFile(applicationRootDir + dirSeparator + 'index.html');
    });

    // serve content subdir
    app.use('/content/', express.static(applicationRootDir + dirSeparator + 'content'));

    // serve the whole client/assets subdir
    app.use('/client/assets', express.static(applicationRootDir + dirSeparator + 'client' + dirSeparator + 'assets'));

    // serve phaser
    app.get('/lib/phaser.js', function (req, res) {
        res.sendFile(applicationRootDir + dirSeparator + 'lib' + dirSeparator + 'phaser.js');
    });
    
    // serve phaser compat
    app.get('/lib/phaser-compat-2.4.js', function (req, res) {
        res.sendFile(applicationRootDir + dirSeparator + 'lib' + dirSeparator + 'phaser-compat-2.4.js');
    });
    
    // serve phaserUI
    app.get('/lib/EZGUI.js', function (req, res) {
        res.sendFile(applicationRootDir + dirSeparator + 'lib' + dirSeparator + 'EZGUI.js');
    });

    // serve jquery
    app.get('/lib/jquery-1.11.3.min.js', function (req, res) {
        res.sendFile(applicationRootDir + dirSeparator + 'lib' + dirSeparator + 'jquery-1.11.3.min.js');
    });

    // serve compiled *.js and *.js.map files
    app.use('/build/', express.static(applicationRootDir + dirSeparator + 'build'));
};

function start(os, server) {
    var networkInterfaces = os.networkInterfaces();

    var ip = null;
    if (networkInterfaces['wlan0']) {
        ip = networkInterfaces['wlan0'][0]['address'];
    } else if (networkInterfaces['eth0']) {
        ip = networkInterfaces['eth0'][0]['address'];
    }

    var port = process.env.PORT || 3000;

    server.listen(port, function () {
        console.log('Server is running.. [ADDRESS: ' + ip + ':' + port + ']');
    });
};
