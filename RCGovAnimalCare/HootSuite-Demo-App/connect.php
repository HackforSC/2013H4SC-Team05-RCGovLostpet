<?php

/**
 * HootSuite App Directory Demo App
 *
 * This is the "Login to Demo App" popup.
 */

error_reporting(E_ERROR | E_WARNING | E_PARSE);


// ============
// = includes =
// ============

require_once('application/config.inc.php');
require_once('application/db.class.php');


// ==================
// = initialization =
// ==================

session_start();


// HootSuite Single-Sign On authentication
// 
// Allow only authenticated requests to connect a 3rd party account
// with this stream.
// 
if( sha1( $_GET['i'] . $_GET['ts'] . $_config['auth_secret'] ) != $_GET['token'] ) {
	
	// not authorized, just close window.
	
	?>
	<html>
	<head>
		<title>Login</title>
	</head>
	<body>
		<script type="text/javascript">
		window.close();
		</script>
	</body>
	</html>
	<?php
	exit();
}


// ======================
// = process login form =
// ======================

/*
	If you are using an external service provider with OAuth, this would be
	the spot to exchange the Request Token for an Access Token and store it
	in your database:

	if(
		isset($_GET['oauth_verifier'])
		&& isset($_SESSION['request_token'])
	) {
	
		// user just authorized app, get and store access token
	
		try {
		
			$consumer = new HTTP_OAuth_Consumer(key, secret, $_SESSION['request_token']['token'], $_SESSION['request_token']['secret']);
			$consumer->getAccessToken(url, $_GET['oauth_verifier']);
		
			$access_token        = $consumer->getToken();
			$access_token_secret = $consumer->getTokenSecret();
		
			// save access token
			...
		
			unset($_SESSION['request_token']);
		
			// close popup, reload app stream
			...
		
		} catch(HTTP_OAuth_Exception $e) {
			print_r($e);
			die();
		}
	}
*/

if(!empty($_POST['username'])) {
	
	// check user account credentials here.
	// this demo app accepts any user/pass combination.
	
	// store account data
	$account_data = array(
		'connected_user_name' => $_POST['username']
	);
	db::put($_GET['uid'] .'-'. $_GET['pid'], $account_data); // {user id}-{stream placement id}

} else {
	
	// get account data
	$account_data = db::get($_GET['uid'] .'-'. $_GET['pid']); // {user id}-{stream placement id}
}

?>
<html>
<head>
	<title>Login</title>
	
	<style type="text/css">
		body {
			background-color: #eff1f4;
			font-family: Arial, Helvetica, sans-serif;
			font-size: 14px;
			padding:10px;
		}
	</style>
</head>
<body>
	
	<?php
	if(is_array($account_data)) {
		
		// user account is connected, close window and reload parent
		?>
		
		<script type="text/javascript">
		window.opener.location.reload();
		window.close();
		</script>
		
		<?php
		
	} else {
		
		// user account is not connected, show login form
		?>
		
		<h1>Login to Demo App</h1>
		<p>
			This is a dummy login form. Any username and password will be considered valid.
		</p>
		<p>
			If you are using an external service provider, this would be the spot to trigger
			authentication with it. For example, if they offer OAuth, instead of showing this
			login form, you would get an OAuth Request Token and redirect the user to the service
			provider's login/authorization page; When the user is being redirected back here after
			authorizing your app, you exchange the Request Token for an Access Token, store it in
			your database, and use it in the app stream to authenticate with the external service
			provider (on each page view).
		</p>
		<p>
			Once the user has logged in, this popup gets closed and the parent window
			(app stream) gets reloaded to reflect the "connected" state.
		</p>
		<form method="post">
			<label>Username: <input type="text" name="username" /></label>
			<label>Password: <input type="password" name="password" /></label>
			<p><input type="submit" value="Login" /></p>
		</form>
		
		<?php
		
	}
	?>
	
</body>
</html>