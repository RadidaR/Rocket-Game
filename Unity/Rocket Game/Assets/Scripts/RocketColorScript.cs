using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketColorScript : MonoBehaviour
{
    public GameData gameData;
    public ColorLibrary colorLibrary;
    public SpriteRenderer[] renderers;
    private void Awake()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        if (gameObject.tag == "Broken Rocket")
        {
            SetColors();
        }
        else
        {
            gameData.currentColors = 0;
            SetColors();
        }
    }

    public void SetRandomColors()
    {
        int random = Random.Range(0, colorLibrary.rocketBodyColors.Length);
        gameData.currentColors = random;

        //SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.gameObject.tag == "Body")
            {
                renderer.color = colorLibrary.rocketBodyColors[gameData.currentColors];
            }
            else if (renderer.gameObject.tag == "Part")
            {
                renderer.color = colorLibrary.rocketPartsColors[gameData.currentColors];
            }
            else if (renderer.gameObject.tag == "Sludge")
            {
                renderer.color = colorLibrary.rocketSludgeColors[gameData.currentColors];
            }
        }

    }

    public void SetColors()
    {
        //SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.gameObject.tag == "Body")
            {
                renderer.color = colorLibrary.rocketBodyColors[gameData.currentColors];
            }
            else if (renderer.gameObject.tag == "Part")
            {
                renderer.color = colorLibrary.rocketPartsColors[gameData.currentColors];
            }
            else if (renderer.gameObject.tag == "Sludge")
            {
                renderer.color = colorLibrary.rocketSludgeColors[gameData.currentColors];
            }
        }
    }
}
