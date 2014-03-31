#pragma strict

static var tempsLache:float;
static var delai:float = 0.5;
static var objetEnMain = false;

static function attraper() {
	objetEnMain = true;
}

static function lacher() {
	tempsLache = Time.time;
	objetEnMain = false;
}

static function tirPossible() : boolean {
	var tempsCourant:float = Time.time;
	var possible:boolean = !objetEnMain && (tempsCourant > (tempsLache + delai));
	return possible;
}