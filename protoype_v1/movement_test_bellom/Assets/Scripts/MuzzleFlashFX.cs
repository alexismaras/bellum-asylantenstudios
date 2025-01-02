using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashFX : MonoBehaviour
{
    SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableRenderer()
    {
        var sprite_direction_list = new List<float> {-2, 2};
        int random_sprite_direction = Random.Range(0, sprite_direction_list.Count);
        transform.localScale = new Vector3(transform.localScale.x, sprite_direction_list[random_sprite_direction], transform.localScale.z);
        spriteR.enabled = true;    
    }
    public void DisableRenderer()
    {
        spriteR.enabled = false;    
    }
}
