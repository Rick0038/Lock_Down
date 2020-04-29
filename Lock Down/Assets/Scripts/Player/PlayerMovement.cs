using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Direction currentDir;												// direction class object to hold the value of the current facing direction of the player   
    Vector2 input;														// to take input from the player as vector movement from keyboard on (x,y) axcis
    bool isMoving = false;												// to move along the grid we need to stop moving
    Vector3 startPos;													// to mark the start position
    Vector3 endPos;														// to mark the end position
    float t;															// to mark the time

    public Sprite northSprite;											// to set the facing to north sprite
    public Sprite southSprite;											// to set the facing to south sprite
    public Sprite eastSprite;											// to set the facing to east sprite
    public Sprite westSprite;											// to set the facing to west sprite

    public float walkSpeed = 3f;										// to mark the walking speed of the player

    public bool isAllowedToMove = true;									// to allow the player to move 

    void Start()														// starting the movement via start function
    {
        isAllowedToMove = true;
    }

	void Update () { 

        if(!isMoving && isAllowedToMove)								// to cheak if input is prerssd and if we are allowed to move
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
																		// making a vector2 object to store the virtical and horizontal input 
            
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))				// this if statement is to stop from making digonal movement 
																		// if the x cord move is greater than y we take y cor movement=0
                input.y = 0;
            else
                input.x = 0;											// if the y cord move is greater than y we take x cor movement=0

            if(input != Vector2.zero)									// to see if the input is zero or not we only move if the input is not 0
            {

                if (input.y > 0)										// to set the player faceing direction to north
                {
                    currentDir = Direction.North;
                }
                if(input.y < 0)											// to set the player faceing direction to south
                {
                    currentDir = Direction.South;
                }
                if(input.x > 0)											// to set the player faceing direction to east
                {
                    currentDir = Direction.East;
                }
                if(input.x < 0)											// to set the player faceing direction to west
                {
                    currentDir = Direction.West;
                }

                
                switch(currentDir)										// to set the player facing animaton based on the movement 
                {
                    case Direction.North:								
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;											// to render the north sprite when north (y+) 
                    case Direction.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;											// to render the north sprite when south (y-) 
                    case Direction.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;											// to render the north sprite when east (x+) 
                    case Direction.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;											// to render the north sprite when west (x-) 
                }

                StartCoroutine(Move(transform));
            }

        }

	}

    public IEnumerator Move(Transform entity)							// function to move the player object  
    {
        isMoving = true;												// movement started ,so bool is true
        startPos = entity.position;										// to set the start position in current entity position
        t = 0;															// time is zero ,we are resetting the time for movement everytime we take input

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);
																		// to set the end position after processing the input

        while (t < 1f)													//
        {
            t += Time.deltaTime * walkSpeed;							// time fo forward when movement is processed with the multiplier of movement speed
            entity.position = Vector3.Lerp(startPos, endPos, t);		// set entity position from start to end position in "t" amount of time 
            yield return null;											// end the loop
        }

        isMoving = false;												// movement stopped,so bool is false 
																		// between the ismoving ture & false key presses will not be processed
        yield return 0;													// no return from function
    }
}

enum Direction															// to set direction for the player 
{
    North,																// north is up in y cord (y+)
    South,																// south is down in y cord (y-)
    East,																// east is right in x cord (x+)
    West																// south is left in x cord (x-)
}
