﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) UnityEngine.Application.Quit();
    }
}
