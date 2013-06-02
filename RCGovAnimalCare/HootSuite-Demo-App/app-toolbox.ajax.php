<?php

/**
 * HootSuite App Directory Demo App
 * 
 * This is the internal script for all AJAX calls.
 * For the demo app, it only serves messages to be shown in the stream.
 * You could extend it to process all user actions (like posting comments) too.
 */

error_reporting(E_ERROR | E_WARNING | E_PARSE);


// delay execution to make async loading more easily visible.
usleep(1200000); // 1.2s


// ============
// = includes =
// ============

require_once('application/config.inc.php');
require_once('application/db.class.php');


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
// HootSuite authentication mechanism is used here as well;
// calling script has to send along all related vars via POST.
// 
if(
	empty($_POST['hs_params']['uid'])
	|| empty($_POST['hs_params']['i'])
	|| empty($_POST['hs_params']['ts'])
	|| empty($_POST['hs_params']['token'])
	|| empty($_POST['hs_params']['pid'])
) {
	die();
}

// authenticate
if( sha1( $_POST['hs_params']['i'] . $_POST['hs_params']['ts'] . $_config['auth_secret'] ) == $_POST['hs_params']['token'] ) {
	$_user['authenticated'] = true;
}

// if authentication failed, die.
if(!$_user['authenticated']) {
	die();
}


// ============================
// = 3rd party authentication =
// ============================

// (If needed)

// get account data
$account_data = db::get($_POST['hs_params']['uid'] .'-'. $_POST['hs_params']['pid']); // {user id}-{stream placement id}

if(is_array($account_data)) {
	
	// add account data to _user array
	$_user = array_merge($_user, $account_data);
	
	// consider user connected
	$_user['connected'] = true;
}


// ==============
// = dummy data =
// ==============

$dummy_tweets = array(
	'{"text":"Anatomy of a Perfect Tweet ~ Learn how @Palms & @MediaLeaders tracked social to sales in a #HootSuite #casestudy http:\/\/t.co\/N3fAibwi #roi","to_user_id":"","from_user":"HootSuite","id":"124839422352039937","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Fri Oct 14 13:30:12 +0000 2011","time":"1318599012"}',
	'{"text":"Put social media to work for your company. Publish, monitor & measure across social networks with #HootSuite http:\/\/t.co\/uKKegxJV","to_user_id":"","from_user":"HootSuite","id":"124546237012783104","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu Oct 13 18:05:11 +0000 2011","time":"1318529111"}',
	'{"text":"Like the song in the new #HootSuite #Geotoko video? It\'s by @TheRadii http:\/\/t.co\/9OHeJiut #hootgeo #acquisition","to_user_id":"","from_user":"HootSuite","id":"124144829805494275","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Wed Oct 12 15:30:08 +0000 2011","time":"1318433408"}',
	'{"text":"Check-in to this news: #HootSuite Acquires Location-Based Marketing Tool @Geotoko http:\/\/t.co\/A83jChfj #hootgeo #socmed","to_user_id":"","from_user":"HootSuite","id":"124107079073013760","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Wed Oct 12 13:00:08 +0000 2011","time":"1318424408"}',
	'{"text":"RT @invoker: Major @hootsuite acquisition announcement tomorrow cc @facebook @wsj @mashable @techcrunch @rww @nytimestech @venturebeat","to_user_id":"","from_user":"HootSuite","id":"123852601069547521","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue Oct 11 20:08:55 +0000 2011","time":"1318363735"}',
	'{"text":"RT @invoker: To clarify WSJ speculation (http:\/\/t.co\/Ea20UVSG), @facebook isn\'t buying @hootsuite anytime soon.","to_user_id":"","from_user":"HootSuite","id":"123500229654880257","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Mon Oct 10 20:48:43 +0000 2011","time":"1318279723"}',
	'{"text":"Be the bigger fish! Jump into the industry conversation with LinkedIn Groups, Pages & Profiles in HootSuite http:\/\/t.co\/Bco5Ngqk #HootLinked","to_user_id":"","from_user":"HootSuite","id":"121978178691538944","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu Oct 06 16:00:38 +0000 2011","time":"1317916838"}',
	'{"text":"HootSuite Named as #LinkedIn Certified Developer + adds Company Pages, Groups & Job Search http:\/\/t.co\/efyxotxd #HootLinked #connect11","to_user_id":"","from_user":"HootSuite","id":"121966229333348352","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu Oct 06 15:13:09 +0000 2011","time":"1317913989"}',
	'{"text":"RT @invoker: Rip SJ. You we\'re an inspiration.","to_user_id":"","from_user":"HootSuite","id":"121737130664919040","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu, 06 Oct 2011 00:02:48 +0000","time":"1317859368"}',
	'{"text":"What is the #Hootlet anyway? Learn how to use #HootSuite\'s bookmarklet in this handy #HootTip http:\/\/t.co\/K5cYHO8P","to_user_id":"","from_user":"HootSuite","id":"121585515366588416","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Wed Oct 05 14:00:20 +0000 2011","time":"1317823220"}',
	'{"text":"#HootSuite helps #SocMed Managers and Acquires @WhatTheTrend ~ Jumbo News Round-up http:\/\/t.co\/sxw7gach","to_user_id":"","from_user":"HootSuite","id":"121572872614445056","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Wed Oct 05 13:10:06 +0000 2011","time":"1317820206"}',
	'{"text":"Hoo wants a career? HootSuite seeks devs, sales, QA, support & more http:\/\/t.co\/ewNjbV99 Superstars only plz #vancouver #jobs","to_user_id":"","from_user":"HootSuite","id":"121260838316294144","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue Oct 04 16:30:11 +0000 2011","time":"1317745811"}',
	'{"text":"Watch, Learn &amp; Chat: Exclusive video about new #Facebook features for business from @HootSuite_U ft @MariSmith http:\/\/t.co\/h9s5PSla #hsuchat","to_user_id":"","from_user":"HootSuite","id":"121196633760333826","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue, 04 Oct 2011 12:15:03 +0000","time":"1317730503"}',
	'{"text":"New #HootSuite article on @HubSpot blog - \"How to Measure Your Social Media Lead Generation Efforts\" - http:\/\/t.co\/1DR38sYR","to_user_id":"","from_user":"HootSuite","id":"119823658519769088","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Fri, 30 Sep 2011 17:19:21 +0000","time":"1317403161"}',
	'{"text":"Another #HootSuite news round-up! This one features coverage of recent acquisition, 3 mil funding &amp; events http:\/\/t.co\/oaEAujkr","to_user_id":"","from_user":"HootSuite","id":"119773545202061312","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Fri, 30 Sep 2011 14:00:13 +0000","time":"1317391213"}',
	'{"text":"New #HootTip: Geo-Tagging and Check-ins on #HootSuite Mobile http:\/\/t.co\/fFHlk7s2 #iphone #blackberry #android","to_user_id":"","from_user":"HootSuite","id":"119480587101802498","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu, 29 Sep 2011 18:36:06 +0000","time":"1317321366"}',
	'{"text":"Fresh #HootTip: Use Geo-Tagging and Check-ins on #HootSuite Mobile http:\/\/t.co\/jETSmlVc #iphone #android #blackberry","to_user_id":"","from_user":"HootSuite","id":"119474585971326978","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Thu Sep 29 18:12:15 +0000 2011","time":"1317319935"}',
	'{"text":"#HootSuite Acquires \u201cWhat the Trend\u201d to Help Define & Understand Trending Twitter Topics http:\/\/t.co\/8yeh5YoB","to_user_id":"","from_user":"HootSuite","id":"118659916771766272","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue Sep 27 12:15:03 +0000 2011","time":"1317125703"}',
	'{"text":"Brilliant deductions from @HootSuite_UK ~ Say Hello to a new Owly for the British Isles http:\/\/t.co\/Kknnp51F","to_user_id":"","from_user":"HootSuite","id":"118366428062679041","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Mon, 26 Sep 2011 16:48:50 +0000","time":"1317055730"}',
	'{"text":"#HootSuite adds Linkedin to Android + autocomplete for Twitter usernames & hashtags  http:\/\/t.co\/4AUtUGyR @HootDroid","to_user_id":"","from_user":"HootSuite","id":"117317249764823040","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Fri Sep 23 19:19:46 +0000 2011","time":"1316805586"}',
	'{"text":"#HootSuite on Tour: Autumn Conference & Event Round-up http:\/\/t.co\/QiXgMivc ~ Owls on the road to share social media stories","to_user_id":"","from_user":"HootSuite","id":"116552813139591169","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Wed Sep 21 16:42:10 +0000 2011","time":"1316623330"}',
	'{"text":"#HootTip: How to Set-up an RSS Feed in #HootSuite http:\/\/t.co\/Y34VAdxv ~ A great way to save time!","to_user_id":"","from_user":"HootSuite","id":"116262414282010624","from_user_id":"17093617","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue Sep 20 21:28:14 +0000 2011","time":"1316554094"}',
	'{"text":"Increase your ROI: #HSUchat is starting at 15 min! Create your search stream &amp; follow @HootSuite_U to join the conversation.","to_user_id":"","from_user":"HootSuite","id":"116206269907476481","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue, 20 Sep 2011 17:45:08 +0000","time":"1316540708"}',
	'{"text":"Lunch &amp; Learn about Twitter ROI with #HSUchat &amp; @HootSuite_U today @ 2pm EST ~ Details at: http:\/\/t.co\/mHRzKwAl","to_user_id":"","from_user":"HootSuite","id":"116123254623707136","from_user_id":"4378755","iso_language_code":"en","source":"<a href=\"http:\/\/www.hootsuite.com\" rel=\"nofollow\">HootSuite<\/a>","profile_image_url":"http:\/\/a1.twimg.com\/profile_images\/541333937\/hootsuite-icon_normal.png","geo_type":"","geo_coordinates_0":"0","geo_coordinates_1":"0","created_at":"Tue, 20 Sep 2011 12:15:16 +0000","time":"1316520916"}'
);
foreach($dummy_tweets as $key => $val) {
	$dummy_tweets[ $key ] = json_decode($val);
	
	// remove html tags from source
	$dummy_tweets[ $key ]->source = strip_tags((string) $dummy_tweets[ $key ]->source);
	
	// parse tweet text
	$text = (string) $dummy_tweets[ $key ]->text;
	$text = preg_replace('@(https?://([\w-.]+)+(:\d+)?(/([\w/_.]*(\?\S+)?)?)?)@', '<a href="$1" target="_blank">$1</a>', $text); // links
    $text = preg_replace("/#(\w+)/", '#<a href="http://search.twitter.com/search?q=\1" target="_blank">\1</a>', $text); // #hashtags
    $text = preg_replace("/(^|[^\w]+)\@([a-zA-Z0-9_]{1,15}(\/[a-zA-Z0-9-_]+)*)/", '\1@<a href="http://twitter.com/\2" target="_blank">\2</a>', $text); // @users
    $dummy_tweets[ $key ]->text = $text;
}


// ===================
// = process request =
// ===================

$_POST['offset'] = (int) $_POST['offset'];

$_POST['limit'] = (int) $_POST['limit'];
if(empty($_POST['limit'])) {
	$_POST['limit'] = 15;
}

switch($_POST['action']) {
	
	
	case 'get_tweets':
		
		$result = array(
			'tweets' => array_slice($dummy_tweets, $_POST['offset'], $_POST['limit']),
		);
		print json_encode($result);
		
		break;
	
	
	case 'search':
		
		if(empty($_POST['search_str'])) {
			$result = array('tweets' => array());
			
		} else {
			
			$tweets = array(); // search result
			foreach($dummy_tweets as $tweet) {
				if(stristr((string) $tweet->text, $_POST['search_str']) !== false) {
					$tweets[] = $tweet;
				}
			}
			$result = array(
				'tweets' => array_slice($tweets, $_POST['offset'], $_POST['limit']),
			);
		}
		print json_encode($result);
		
		break;
	
	
	default:
		print json_encode(array('error' => 'Invalid value for parameter api_call'));
}
