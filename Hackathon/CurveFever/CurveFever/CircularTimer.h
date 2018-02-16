#pragma once

#include <SFML/Graphics.hpp>
#include "Utility.h"
#include "ThickLine.h"

using namespace std ;
using namespace sf ;

class CircularTimer : public ThickLine
{
public:
	CircularTimer();
	CircularTimer(Vector2f const& _position, float const& _radius, float const& _time);

	void setposition(Vector2f const& _position) ;

	void update() ;
	void draw(RenderWindow &window) ;

private:
	Vector2f position ;
	Clock timer ;
	float time ;
	int pointNumber ;
	float radius ;
};

