#include "CircularTimer.h"

CircularTimer::CircularTimer()
{
	position = Vector2f(0,0) ;
	radius = 20 ;
	setThickness(5) ;
	setColor = Color::White ;
	time = 5 ;
}
CircularTimer::CircularTimer(Vector2f const& _position, float const& _radius, float const& _time)
{
	position = _position ;
	radius = _radius ;
	line = ThickLine(5, Color::White) ;
	time = _time ;
}

void CircularTimer::setposition(Vector2f const& _position)
{
	for(int i(0) ; i < line.getSize() ; i++)
	{
		line[i].
	}
	position = _position ;
}

void CircularTimer::update()
{
	if(timer.getElapsedTime().asSeconds() <= time+0.1) 
	{
		line.addPoint(position + Vector2f(radius*cos(2*PI*timer.getElapsedTime().asSeconds()/time), radius*sin(2*PI*timer.getElapsedTime().asSeconds()/time))) ;
	}
}
void CircularTimer::draw(RenderWindow &window)
{
	line.draw(window) ;
}