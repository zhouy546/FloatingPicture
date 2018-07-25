using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPortectGenerator : MonoBehaviour {
    public GameObject Image;

    public List<NImage> ImagePool = new List<NImage>();

    // Use this for initialization
    public void initialization() {

        foreach (var item in ImportAsserts.instance.ScreenProtectImages)
        {
            CreateObjects(item);
        }


	}

    void CreateObjects(Sprite sprite) {
        GameObject _gameObject = Instantiate(Image);

        _gameObject.transform.SetParent(this.transform);

        _gameObject.transform.localScale = Vector3.one;

        NImage nImage = _gameObject.GetComponent<NImage>();

        //nImage.OnCompleteEvent += NImage_OnCompleteEvent;

        nImage.image.sprite = sprite;

        MoveImage(nImage);

        ImagePool.Add(nImage);

    }

    //private void NImage_OnCompleteEvent(NImage nImage)
    //{
    //    MoveImage(nImage);
    //}

    void MoveImage(NImage nImage) {

        nImage.transform.localPosition = new Vector3(UnityEngine.Random.Range(-Screen.width / 2, Screen.width/2), ValueSheet.FloatingIMG_Minium_Y, UnityEngine.Random.Range(-500, 0));

        float time = UnityEngine.Random.Range(5f, 20f);

        Vector3 target = new Vector3(nImage.transform.localPosition.x, ValueSheet.FloatingIMG_Maxmiun_Y = Screen.height / 2 + 400, nImage.transform.localPosition.z);

        nImage.SetLocation(target, time, LeanTweenType.easeInOutQuart,()=> MoveImage(nImage));
    }

	// Update is called once per frame
	void Update () {
		
	}
}
