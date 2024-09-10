using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaPosition : MonoBehaviour
{
    public float timer = 0;

    float speed;
    float width;
    float height;

    public bool luastart;

    public GameObject lua;
    // Start is called before the first frame update
    void Start()
    {
        speed = .06f;
        width = 200;
        height = 150;
        
        lua.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(luastart)
        {
            lua.SetActive(true);
            timer += Time.deltaTime * speed;
            float x = Mathf.Cos(timer) * width;
            float y = Mathf.Sin(timer) * height;
            float z = 20;

            transform.position = new Vector3(x, y, z);

            if(timer >= 1.5f) timer = 1.5f;
        }
    
    }
}
