using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool hasBeenVisible;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   private void Update()
    {
        if(hasBeenVisible == false && spriteRenderer .isVisible)
        {
            hasBeenVisible = true;
        }
        if(hasBeenVisible == false)
        {
            return;
        }

        //Get would position of the object and convert to screen space
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
       //A new positiong to wrap to
        Vector2 newScreenPos = screenPos;

        if(screenPos.x < 0 ) // if we move off the left hand side
        {
            newScreenPos.x = Screen.width; 
        }
        else if(screenPos.x > Screen.width)  //moved off the right hand side
        {
            newScreenPos.x = 0;        
        }    
        if(screenPos.y < 0)
        {
            newScreenPos.y = Screen.height;
        }
        else if(screenPos.y > Screen.height)
        {
            newScreenPos.y = 0;
        }

        if (newScreenPos != screenPos)
        {

            Vector2 newWorldPos = Camera.main.ScreenToWorldPoint(newScreenPos);
            transform.position = newWorldPos;
        } 
    }




}
