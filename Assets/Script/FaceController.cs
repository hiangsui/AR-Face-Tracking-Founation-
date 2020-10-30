using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceController : MonoBehaviour
{
    ARFaceManager arFaceManager;
    public Material[] faceMaterials;

    int swapCounter = 0;

    void Awake()
    {
        arFaceManager = FindObjectOfType<ARFaceManager>();

        if (arFaceManager != null)
        {
            arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = faceMaterials[0];
        }
    }


    public void ButtonChangeFace()
    {
        swapCounter = swapCounter == faceMaterials.Length - 1 ? 0 : swapCounter + 1;

        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = faceMaterials[swapCounter];
        }

        //rendFacePrefab.material = faceMaterials[swapCounter]; // กดแล้วไม่เปลี่ยนทันที จะเปลี่ยนต่อเมื่อ เอาออกจากหน้า แล้วส่องใหม่
    }



    // ฝากไว้ ปิดไว้ก่อน การ Convert Texture //

    /*

    Texture tex = faceMaterials[i].mainTexture;

    // Convert Texture to Texture 2D //

    Texture2D tex2d = (Texture2D)tex;

    newFaceFilter.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(tex2d, new Rect(0.0f, 0.0f, tex2d.width, tex2d.height), new Vector2(0.5f, 0.5f), 100f);

    */
}
