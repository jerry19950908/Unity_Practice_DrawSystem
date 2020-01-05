using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Randomobject : MonoBehaviour
{
   
    [Header("圖片區域")]     //陣列.圖片 
    public Sprite[] sprites;   
    
    [Header("變更圖片速度"), Range(0.01f,0.1f)]    //變更圖片速度
    public float speed = 0.05f;

    [Header("重複次數"), Range(1, 5)]  //重複變更圖片次數
    public int count = 3;

    private int index;    //儲存隨機圖片值


    [Header("音效區域")]
    public AudioClip soundchange;
    public AudioClip soundsprites;
    



    //元件區
    private Image randomsprites;
    private Button btn;
    private AudioSource aud;

    private void Start()
    {
        randomsprites = GameObject.Find("道具圖片").GetComponent<Image>();
        aud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(buttonClick);  //按鈕點擊觸發事件
    }

    public void buttonClick()
    {
        StartCoroutine(randomeffect());  //啟動協程
    }

    public IEnumerator randomeffect()
    {
        btn.interactable = false;  //變更圖片時,按鈕為不能點擊狀態

        for (int j = 0; j < count; j++)   //重複變更圖片次數
        {
            for (int i = 0; i < sprites.Length; i++)  //變更所有圖片順序
            {
                randomsprites.sprite = sprites[i];
                aud.PlayOneShot(soundchange, 0.5f);
                yield return new WaitForSeconds(speed);
                
            }
        }

        index = Random.Range(0, sprites.Length);
        randomsprites.sprite = sprites[index];
        aud.PlayOneShot(soundsprites, 0.5f);
        btn.interactable = true;

    }

    


}
