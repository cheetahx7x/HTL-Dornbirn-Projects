#include "AI.h"

AI::AI(Vector2f const& _position, Vector2f const& _forward, Color const& _color, Terrain *_terrain) : 
	Snake(_position, _forward, _color, _terrain) 
{

}

void AI::control(float const& dt)
{
	for(int i(0) ; i < rayCastNumber ; i++)
	{
		
	}
}