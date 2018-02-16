#include "Player.h"


Player::Player(Vector2f const& _position, Vector2f const& _forward, Color const& _color, Terrain *_terrain, Keyboard::Key const& _leftKey, Keyboard::Key const& _rightKey) :
		Snake(_position, _forward, _color, _terrain) 
{
	leftKey = _leftKey ;
	rightKey = _rightKey ;
}

void Player::reverseKeys()
{
	Keyboard::Key buffer = leftKey ;
	leftKey = rightKey ;
	rightKey = buffer ;
}
void Player::control(float const& dt)
{
	left = Keyboard::isKeyPressed(leftKey) ;
	right = Keyboard::isKeyPressed(rightKey) ;

	if(left) forward += Vector2f(forward.y, -forward.x)*turnSpeed*dt ;
	if(right) forward -= Vector2f(forward.y, -forward.x)*turnSpeed*dt ;

	forward /= Norm(forward) ;
		
	if(alive)
		position += forward*speed*dt ;
	endCircle.setPosition(position) ;
}
