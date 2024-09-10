using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolPosition : MonoBehaviour
{
    public float timer = 0;
    public float skybox = 2f;

    float speed;
    float width;
    float height;

    private LuaPosition luaPosition;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        speed = .0308f;
        width = 200;
        height = 150;

        luaPosition = FindObjectOfType<LuaPosition>();
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.startarDia)
        {
            skybox -= Time.deltaTime * 0.04158f;
            timer += Time.deltaTime * speed;
            float x = Mathf.Cos(timer) * width;
            float y = Mathf.Sin(timer) * height;
            float z = -14;

            transform.position = new Vector3(x, y, z);      

            RenderSettings.skybox.SetFloat("_Exposure", (skybox));
            RenderSettings.skybox.SetFloat("_Rotation", Time.time*0.7f);

            if(timer >= 2.5f) luaPosition.luastart = true;
            if(timer >= 3) timer = 3;

            if(skybox <= 0) skybox = 0;
        }
                    //skybox = 2;
                    //luz sol = 40;
    }
}
