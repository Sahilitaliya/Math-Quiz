using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject FirstPanel, LoadingPanel, LeavePanel, SettingPanel;
    [SerializeField]
    Image SliderImages;
    [SerializeField]
    float speed;
    [SerializeField]
    bool Flag;

    [SerializeField]
    Sprite MusicOn, MusicOff, SoundOn, SoundOff;

    [SerializeField]
    Button MusicBtn, SoundBtn;

    [SerializeField]
    AudioSource MusicSource, SoundSource;

    private void Start()
    {
        if (Attech.instance.IsMusic)
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOn;
            MusicSource.mute = false;
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOff;
            MusicSource.mute = true;
        }

        if (Attech.instance.IsSound)
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOn;
            SoundSource.mute = false;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOff;
            SoundSource.mute = true;
        }
    }
    public void MusicManagement()
    {
        //ThirdClipPlay();
        if (Attech.instance.IsMusic)
        {

            MusicBtn.GetComponent<Image>().sprite = MusicOff;
            Attech.instance.IsMusic = false;
            MusicSource.mute = true;

        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOn;
            Attech.instance.IsMusic = true;
            MusicSource.mute = false;
        }
    }
    public void SoundManagement()
    {
        //ThirdClipPlay();

        if (Attech.instance.IsSound)
        {

            SoundBtn.GetComponent<Image>().sprite = SoundOff;
            Attech.instance.IsSound = false;
            SoundSource.mute = true;


        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOn;
            Attech.instance.IsSound = true;
            SoundSource.mute = false;
        }
    }
    void Update()
    {
        if (Flag)
        {
            if (SliderImages.fillAmount < 1)
            {
                SliderImages.fillAmount += speed * Time.deltaTime;
                // Flag = true;
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void SettingPanelOpen()
    {
        SettingPanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
    public void SettingPanelClose()
    {
        SettingPanel.SetActive(false);
        FirstPanel?.SetActive(true);
    }
    public void HomeSeen()
    {
        FirstPanel.SetActive(false);
        LoadingPanel.SetActive(true);
        Flag = true;
    }
    public void LeavePanelOpen()
    {
        LeavePanel.SetActive(true);
        FirstPanel.SetActive(false);
    }
    public void LeavePanelClose()
    {
        //LeavePanel.GetComponent<Animator>().Play("LeaveRevarsePanel");
        LeavePanel.SetActive(false);
        FirstPanel.SetActive(true);
    }
}