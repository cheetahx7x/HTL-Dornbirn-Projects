#pragma once

#include <SFML/Graphics.hpp>
#include "Utility.h"
#include "Snake.h"
using namespace std ;
using namespace sf ;

class Player : public Snake 
{
public:
	Player(Vector2f const& _position, Vector2f const& _forward, Color const& _color, Terrain *_terrain, Keyboard::Key const& _leftKey, Keyboard::Key const& _rightKey);
	
	virtual void reverseKeys() ;
	virtual void control(float const& dt) ;

private :
	Keyboard::Key leftKey ;
	Keyboard::Key rightKey ;
};

