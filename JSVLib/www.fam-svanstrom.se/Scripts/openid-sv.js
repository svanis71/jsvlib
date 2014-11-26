/*
	Simple OpenID Plugin
	http://code.google.com/p/openid-selector/
	
	This code is licensed under the New BSD License.
*/

var providers_large = {
};

var providers_small = {
    google: {
        name: 'Google',
        url: 'https://www.google.com/accounts/o8/id'
    },
    yahoo: {
        name: 'Yahoo',
        url: 'http://me.yahoo.com/'
    },
    blogger: {
        name: 'Blogger',
        label: 'Namn på ditt bloggerkonto',
        url: 'http://{username}.blogspot.com/'
    },
    verisign: {
        name: 'Verisign',
        label: 'Ditt användarid hos versign',
        url: 'http://{username}.pip.verisignlabs.com/'
    }
};

openid.locale = 'sv';
openid.sprite = 'sv'; // reused in german& japan localization
openid.demo_text = 'Demoläge, normalt skulle ett open id skickats:';
openid.signin_text = '';
openid.image_title = 'Logga in med {provider}';
