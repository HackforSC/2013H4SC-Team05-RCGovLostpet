<?php

/**
 * HootSuite App Directory Demo App
 * 
 * For the sake of simplicity, we're simulating a db model
 * by storing data in the session.
 */

class db {
	
	function get($key) {
		return $_SESSION['simulated_db'][ $key ];
	}
	function put($key, $val) {
		$_SESSION['simulated_db'][ $key ] = $val;
	}
	function delete($key) {
		unset($_SESSION['simulated_db'][ $key ]);
	}
}
