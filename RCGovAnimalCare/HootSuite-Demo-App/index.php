<?php

/**
 * HootSuite App Directory Demo App
 * 
 * Simple Twitter-like stream demonstrating:
 * - Single Sign-On authentication
 * - infinite scrolling (auto-load more)
 * - unobtrusive stream reloading via hsp.bind()
 * - 3rd party authentication ("Connect your Demo App account")
 * 
 * To use within the HootSuite dashboard:
 * - place this directory on your webserver
 * - go to http://hootsuite.com/developers
 *   - set your app's Authentication Type to Single Sign-On
 *   - enter a random string as the Shared Secret
 *   - create a new stream
 *     - enter a title
 *     - point the "<iframe>d URL" to this file (index.php) on your webserver
 *     - the other fields can be left blank
 * - open application/config.inc.php and set auth_secret to your Shared Secret
 * 
 * Then install your app and add the new stream to a tab.
 * 
 * If you have any questions, please check the App Directory Developer's Forum at
 * http://groups.google.com/group/hootsuite-app-developers
 */


/*
	get vars:
		[lang]     => en
		[theme]    => blue_steel
		[timezone] => 7200
		[pid]      => 1954 // stream placement id
		[uid]      => {user id}
		[i]        => {user id}
		[ts]       => 1313094352 // timestamp
		[token]    => {...} // sha1 hash
*/

error_reporting(E_ERROR | E_WARNING | E_PARSE);


// ============
// = includes =
// ============

require_once('application/config.inc.php');
require_once('application/db.class.php');


// =============
// = functions =
// =============

// Function to recompile the query string w/o specified parameters.
// 
function query_string_remove_vars($vars) {
	if(!is_array($vars)) {
		$vars = array($vars);
	}
	$return = array();
	foreach($_GET as $key => $val) {
		if(!in_array($key, $vars)) {
			$return[] = "{$key}={$val}";
		}
	}
	return implode('&', $return);
}


// ==================
// = initialization =
// ==================

session_start();

$_user = array(
	'authenticated'  => false, // HootSuite authentication
	'connected'      => false, // 3rd party authentication
);

// HootSuite Single-Sign On authentication
// 
if( sha1( $_GET['i'] . $_GET['ts'] . $_config['auth_secret'] ) == $_GET['token'] ) {
	$_user['authenticated'] = true;
}

// if authentication failed, redirect to HS dashboard
// 
if(!$_user['authenticated']) {
	header('Location: http://hootsuite.com/dashboard');
	exit();
}


// ============================
// = 3rd party authentication =
// ============================
// 
// Check if user has connected his 3rd party account. This can be either from your
// own user base or from an external service provider. For the sake of simplicity,
// this script simulates our own user base, and uses session vars instead of a data
// base (see "db" class above).
// 3rd party authentication is done per-Stream, ie. if you add this stream multiple
// times, you have to connect your 3rd party account in every stream individually.
// See https://sites.google.com/site/hootsuiteappdevelopers/authentication-process
// for further explanation.

// get account data
$account_data = db::get($_GET['uid'] .'-'. $_GET['pid']); // {user id}-{stream placement id}

if(is_array($account_data)) {
	
	// add account data to _user array
	$_user = array_merge($_user, $account_data);
	
	// consider user connected
	$_user['connected'] = true;
}


// disconnect account?
if(isset($_GET['disconnect'])) {
	
	// unset user data
	db::delete($_GET['uid'] .'-'. $_GET['pid']);
	
	// redirect to self w/o "disconnect" parameter
	header('Location: ?'. query_string_remove_vars('disconnect'));
	exit();
}


// If you are using an external service provider, this would be
// the spot to authenticate the connected account with it.
// 
// if(!empty($_user['access_token'])) {
// 	
// 	try {
// 		
// 		$consumer = new HTTP_OAuth_Consumer(..., ..., ..., ...);
// 		...
// 		
// 	} catch(... $e) {
// 		
// 		$_user['connected'] = false;
// 		...
// 	}
// }

?>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Demo App</title>
	
	<?php
	// different urls when using HTTPS
	if($_SERVER['HTTPS'] == 'on') {
		?>
		<script type="text/javascript" src="https://d2l6uygi1pgnys.cloudfront.net/jsapi/0-5/hsp.js"></script>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
		<?php
	} else {
		?>
		<script type="text/javascript" src="http://static.hootsuite.com/jsapi/0-5/hsp.js"></script>
	    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
		<?php
	}
	?>
	
	<script type="text/javascript" src="js/stream-controls.js"></script>
	
	
	<?php
	// own themed styles
	$theme = $_GET['theme'];
	if(empty($theme)) {
		$theme = 'blue_steel';
	}
	?>
	<link rel="stylesheet" href="css/<?php print $theme; ?>.css" type="text/css" media="screen" />
	
	
	<script src="js/script.js" type="text/javascript"></script>
	
	<script type="text/javascript">
	
	$(document).ready(function(){
    	
		// =======
		// = hsp =
		// =======
		
		var hsp_params = {
			apiKey: '6je2g403f4w0cckgkcwkows0c3i7nofc4p9',
			useTheme: true,
			subtitle: ' '
		};
		
		<?php
		// receiver path
		$protocol = ($_SERVER['HTTPS'] == 'on') ? 'https://' : 'http://';
		$receiver_path = $protocol . $_SERVER['HTTP_HOST'] . dirname($_SERVER['SCRIPT_NAME']) . '/app_receiver.html';
		print "hsp_params.receiverPath = '{$receiver_path}';";
		
		// stream subtitle: connected user name
		if($_user['connected']) {
			print "hsp_params.subtitle = '({$_user['connected_user_name']})';";
		}
		?>
		
		hsp.init(hsp_params);
		
		// hsp.bind needs receiverPath to be set
		hsp.bind('refresh', function() {
			appStream.refresh_stream();
		});
		
		
		// ===============
		// = Demo App JS =
		// ===============
		
		appStream.init( $('#app-stream'), {
			connected: <?php print (int) $_user['connected']; ?>,
			hs_params: <?php
				print json_encode(array(
					'uid'   => $_GET['uid'],
					'pid'   => $_GET['pid'],
					'i'     => $_GET['i'],
					'ts'    => $_GET['ts'],
					'token' => $_GET['token'],
					'theme' => $_GET['theme'],
				));
			?>
		});
		
		$('a.btn-connect').click(function(e) {
		    window.open('connect.php?<?php print $_SERVER['QUERY_STRING']; ?>', 'my_app_auth', 'width=600,height=380,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes');
			e.preventDefault();
		});
		
		
		// ==========================
		// = demo function handlers =
		// ==========================
		
		// "Write Message"
		$('.hs_topBar ._writeMessage a.send').click(function(e) {
			// ...
			e.preventDefault();
		});
		
		// "Search"
		var search = function() {
			var str = $('#search_text').val();
			if(str != '' && str != undefined && str != null) {
				appStream.search(str);
				$('.hs_topBar .hs_dropdown').hide();
				$('.hs_topBar .hs_controls a.active').removeClass('active');
				$(window).scrollTop(0);
			}
		}
		$('.hs_topBar a.search').click(function(e) {
			search();
		});
		$('#search_text').keypress(function(e) {
		    if(e.keyCode == 13) { // enter button
				search();
		    }
		});
		
		// "More"
		$('.hs_topBar ._menuList a').click(function(e) {
			
			// show heading
			$('#app-stream-heading').html( $(this).text() + ' clicked (<a href="#" class="refresh_stream">Clear</a>)');
			$('#app-stream-heading').show();
			
			// clear messages
			$('#app-stream').html('');
			
			// close dropdown
			$('.hs_topBar .hs_dropdown').hide();
			$('.hs_topBar .hs_controls a.active').removeClass('active');
			
			e.preventDefault();
		});
		
		
	});
	
	</script>
	
	
	<style type="text/css" media="screen">
	
	a {
		outline:none;
	}
	.clear {
		clear:both;
		height:0px;
		overflow:hidden;
	}
	
	/* some defaults */
	#demo-app strong {
		font-weight:bold;
	}
	#demo-app .hs_noMessage {
		text-align:center;
	}
	
	</style>

</head>

<body id="demo-app">
	
	<div class="hs_stream">
		
		
		<!-- Top Bar --> 
		<div class="hs_topBar">
			<div class="hs_content">
				<div class="hs_controls">
					<?php
					$dropdown_icons = array();
					
					// write message
					$dropdown_icons[] = '<a href="#" dropdown="_writeMessage" title="Write Message"><span class="icon-19 write"></span></a>';
					
					// search
					$dropdown_icons[] = '<a href="#" dropdown="_search" title="Search"><span class="icon-19 search"></span></a>';
					
					// settings
					$dropdown_icons[] = '<a href="#" dropdown="_settings" title="Settings"><span class="icon-19 settings"></span></a>';
					
					// more
					$dropdown_icons[] = '<a href="#" dropdown="_menuList" title="More"><span class="icon-19 dropdown"></span></a>';
					
					print implode($dropdown_icons);
					?>
				</div>
				<span id="stream-title"></span>
			</div>
			
			<!-- drodowns -->
			<div class="hs_dropdown">
				
				<!-- WRITE MESSAGE -->
				<div class="_writeMessage hs_btns-right">
					<textarea></textarea>
					<div class="hs_btns-right">
						<a class="hs_btn-cmt send" href="#">Send</a>
					</div>
				</div>
				
				<!-- SEARCH -->
				<div class="_search hs_btns-right">
					<input type="text" id="search_text" />&nbsp;<a class="hs_btn-cmt search">Search</a>
				</div>
				
				<!-- SETTINGS -->
				<div class="_settings hs_btns-right">
					<?php
					if(!$_user['connected']) {
						print '
							<a href="'. $_SERVER['REQUEST_URI'] .'&connect" class="hs_btn-cmt btn-connect">Connect your Demo App account</a>
						';
					} else {
						$query_string = query_string_remove_vars('connect');
						print '
							<strong>Connected account:</strong> '. $_user['connected_user_name'] .'
							&nbsp;<a href="?'. $query_string .'&disconnect" class="hs_btn-cmt" onclick="return confirm(\'Really disconnect your account?\');">Disconnect</a>
						';
					}
					?>
				</div>
				
				<!-- MENU LIST -->
				<div class="_menuList hs_btns-right">
					<a href="#">dropdown link 1</a>
					<hr />
					<a href="#">dropdown link 2</a>
					<hr />
					<a href="#">dropdown link 3</a>
				</div>
				
			</div>
		</div>
		<div class="hs_topBarSpace"></div>
		
		<div class="hs_noMessage" id="app-stream-heading" style="display:none;"></div>
		
		<div id="app-stream"></div>
	    
	</div>
	
</body>
</html>