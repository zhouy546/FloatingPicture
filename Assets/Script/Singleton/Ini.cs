using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ini : MonoBehaviour {
    ReadJson readJson;

    ImportAsserts importAsserts;

    ScreenPortectGenerator screenPortectGenerator;
	// Use this for initialization
	void Start () {
        StartCoroutine(initialization());
	}

    IEnumerator initialization() {
        readJson = FindObjectOfType<ReadJson>();

        importAsserts = FindObjectOfType<ImportAsserts>();

        screenPortectGenerator = FindObjectOfType<ScreenPortectGenerator>();

        //ini
        // yield return StartCoroutine(readJson.initialization());

        yield return StartCoroutine( importAsserts.initialization());

        screenPortectGenerator.initialization();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
