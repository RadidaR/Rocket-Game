using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class ChangeSprite : MonoBehaviour
{
    public SpriteLibrary spriteLibrary;
    public SpriteResolver spriteResolver;

    public string targetCategory;

    public enum TestEnum { One, Two, Three, Five}

    public SpriteLibraryAsset libraryAsset => spriteLibrary.spriteLibraryAsset;
    public void ChangeSpriteFunction()
    {
        //string[] labels = libraryAsset.GetCategoryLabelNames(targetCategory).ToArray();
        //int random = Random.Range(1, 2);
        int random = Random.Range(3, 8);
        Debug.Log(spriteResolver.GetLabel());
        //Debug.Log(random.ToString());
        //Debug.Log("Planet " + random.ToString());
        spriteResolver.SetCategoryAndLabel("Random Planets", "Planet " + random.ToString());
    }

    
}
