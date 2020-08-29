﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話區域")]
    public GameObject paneldialog;
    [Header("說話者")]
    public Text textName;
    [Header("說話內容")]
    public Text textContent;
    [Header("打字速度"), Range(0.1f, 1)]
    public float printSpeed = 0.2f ;
    [Header("打字音效")]
    public AudioClip soundPrint;

    private AudioSource aud;

    /// <summary>
    /// 對話系統
    /// </summary>
    public void dialog()
    {
        paneldialog.SetActive(true);
        textName.text = name;
        StartCoroutine(Print());
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    private IEnumerator Print()
    {
        string dialog = data.dialogs[0];                  // 對著 = NPC 資料.對話第一段
        textContent.text = "";                            // 清空

        for(int i = 0; i < dialog.Length; i++)      // 跑對話第一個字到最後一個字
        {
            textContent.text += dialog[i];                // 對話內容.文字 += 對話[]
            yield return new WaitForSeconds(printSpeed);  // 
        }
    }

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "阿兜")dialog();     
    }
}
