
HootSuite App Directory Demo App

Simple Twitter-like stream demonstrating:
- Single Sign-On authentication
- infinite scrolling (auto-load more)
- unobtrusive stream reloading via hsp.bind()
- 3rd party authentication ("Connect your Demo App account")

To use within the HootSuite dashboard:
- place this directory on your webserver
- go to http://hootsuite.com/developers
  - set your app's Authentication Type to Single Sign-On
  - enter a random string as the Shared Secret
  - create a new stream
    - enter a title
    - point the "<iframe>d URL" to index.php on your webserver
    - the other fields can be left blank
- open application/config.inc.php and set auth_secret to your Shared Secret

Then install your app and add the new stream to a tab.

If you have any questions, please check the App Directory Developer's Forum at
http://groups.google.com/group/hootsuite-app-developers