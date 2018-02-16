#pragma once

#include <SFML/Graphics.hpp>
#include "Utility.h"
#include "Snake.h"

using namespace std ;
using namespace sf ;

class AI : public Snake
{
public:
	AI(Vector2f const& _position, Vector2f const& _forward, Color const& _color, Terrain *_terrain) ;

	virtual void control(float const& dt) ;
private :
	int rayCastNumber ;
};

