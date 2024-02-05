using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject OptionPanel, PlayPanel, GameOverPanel;
    [SerializeField] 
    int MainObj;
    [SerializeField]
    TextMeshProUGUI OPText, RightText, LeftText;
    int Value1, Value2;
    int Ans;
    [SerializeField]
    List<int> GenrateValue;
    [SerializeField]
    TextMeshProUGUI[] ForthBtn;
    [SerializeField]
    Image Timer;
    [SerializeField]
    float Speed;
    bool Tamp, Flag;

    [SerializeField]
    Animator OptionRevrseAnim, OpionAnim;

    //[SerializeField]
    //Sprite MusicOn, MusicOff, SoundOn, SoundOff;

    [SerializeField]
    Button MusicBtn, SoundBtn;

    [SerializeField]
    AudioSource MusicSource, SoundSource;
    private void Start()
    {
        if (Attech.instance.IsMusic)
        {
            //MusicBtn.GetComponent<Image>().sprite = MusicOn;
            MusicSource.mute = false;
        }
        else
        {
            //MusicBtn.GetComponent<Image>().sprite = MusicOff;
            MusicSource.mute = true;
        }
        if (Attech.instance.IsSound)
        {
            //SoundBtn.GetComponent<Image>().sprite = SoundOn;
            SoundSource.mute = false;
        }
        else
        {
            //SoundBtn.GetComponent<Image>().sprite = SoundOff;
            SoundSource.mute = true;
        }
    }
    public void PlayPanelOpen()
    {
        PlayPanel.SetActive(true);
        OptionPanel.SetActive(false);
        RevrseOption();
    }
    public void PlayPanelClose()
    {
        PlayPanel.SetActive(false);
        OptionPanel.SetActive(true);
        OptionAnimPanel();
        Tamp = false;
    }
    public void HomePanelOpen()
    {
        SceneManager.LoadScene(0);
    }
    public void Option(int a)
    {
        MainObj = a;
        Tamp = true;
        GamePlay();
    }
    void Update()
    {
        if (Tamp)
        {
            if (Timer.fillAmount > 0)
            {
                Timer.fillAmount -= Speed * Time.deltaTime;
            }
            else
            {
                GameOverPanel.SetActive(true);
                PlayPanel.SetActive(false);
                if (Tamp)
                {
                    Timer.fillAmount = 1;
                }
            }
        }
    }
    public void GamePlay()
    {
        Timer.fillAmount = 1;
        switch (MainObj)
        {
            case 1:
                OPText.text = "+";
                Value1 = Random.Range(1, 10);
                Value2 = Random.Range(1, 10);
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 + Value2;
                // Debug.Log("Add Panel" + Ans);
                Flag = true;
                GenrateValueActive();
                break;
            case 2:
                OPText.text = "-";
                Value1 = Random.Range(1, 10);
                Value2 = Random.Range(1, 10);
                if (Value1 < Value2)
                {
                    int Temp = Value1;
                    Value1 = Value2;
                    Value2 = Temp;
                }
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 - Value2;
                // Debug.Log("Mainus Panel - >"+Ans);
                Flag = true;
                GenrateValueActive();
                break;
            case 3:
                OPText.text = "X";
                Value1 = Random.Range(1, 10);
                Value2 = Random.Range(1, 10);
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 * Value2;
                // Debug.Log("Mainus Panel - >"+Ans);
                Flag = true;
                GenrateValueActive();
                break;
            case 4:
                OPText.text = "/";
                Value2 = Random.Range(1,10);
                Value1 = Value2 * Random.Range(1,10);
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 / Value2;
                Debug.Log("Division Panel - > " + Ans);
                Flag = false;
                GenrateValueActive();
                break;
        }
    }
    void GenrateValueActive()
    {
        int AnsValue;
        if (Flag)
        {
            GenrateValue.Clear();
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    AnsValue = Random.Range(Ans, Ans + 10);
                }
                while (GenrateValue.Contains(AnsValue) || Ans == AnsValue);

                GenrateValue.Add(AnsValue);
            }
        }
        else
        {
            GenrateValue.Clear();
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    AnsValue = Random.Range(Ans, Ans + 10);
                }
                while (GenrateValue.Contains(AnsValue) || Ans == AnsValue);

                GenrateValue.Add(AnsValue);
            }
        }
        AnsBtn();
    }
    void AnsBtn()
    {
        int Val;
        int Count = 0;
        Val = Random.Range(0, ForthBtn.Length);
        for (int i = 0; i < ForthBtn.Length; i++)
        {
            if (i == Val)
            {
                ForthBtn[i].text = Ans.ToString();
            }
            else
            {
                ForthBtn[i].text = GenrateValue[Count].ToString();
                Count++;
            }
        }
    }
    public void AnsCheak(TextMeshProUGUI CheckAns)
    {
        if (CheckAns.text == Ans.ToString())
        {
            GamePlay();
        }
        else
        {
            GameOverPanel.SetActive(true);
            PlayPanel.SetActive(false);
        }
    }
    public void OptionPanelActive()
    {
        OptionPanel.SetActive(true);
        Timer.fillAmount = 1;
        OptionAnimPanel();
        GameOverPanel.SetActive(false);
    }
    public void RetrayBtnActive()
    {
        PlayPanel.SetActive(true);
        Timer.fillAmount = 1;
        GameOverPanel.SetActive(false);
    }
    void RevrseOption()
    {
        OptionRevrseAnim.Play("OptionRevarseAnim");
    }
    void OptionAnimPanel()
    {
        OpionAnim.Play("OptionPanelAnim");
    }
    public void MusicManagement()
    {
        if (Attech.instance.IsMusic)
        {

            //MusicBtn.GetComponent<Image>().sprite = MusicOff;
            Attech.instance.IsMusic = false;
            MusicSource.mute = true;

        }
        else
        {
            //MusicBtn.GetComponent<Image>().sprite = MusicOn;
            Attech.instance.IsMusic = true;
            MusicSource.mute = false;
        }
    }
    public void SoundManagement()
    {
        if (Attech.instance.IsSound)
        {

            //SoundBtn.GetComponent<Image>().sprite = SoundOff;
            Attech.instance.IsSound = false;
            SoundSource.mute = true;

        }
        else
        {
            //SoundBtn.GetComponent<Image>().sprite = SoundOn;
            Attech.instance.IsSound = true;
            SoundSource.mute = false;
        }
    }
}