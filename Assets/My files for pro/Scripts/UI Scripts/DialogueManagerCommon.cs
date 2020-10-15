using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;

public class DialogueManagerCommon : MonoBehaviour
{
    public Text textDisplay;
    public GameObject ObjectsOn;
    public GameObject DialogueMenu;
    public GameObject MenuActivateGO;
   
    public Animator AnimP;
    public Animator AnimE;
    public string pathOfDialogue;

    private JsonData dialogue;
    private int index;
    private string speaker;

    private bool inDialogue;
    private int diaCounter =1;
    private int speed = 5;
    private int sceneval = 1;
    private string currentSceneName;
    private string nextSceneName;
    

    public bool LoadDialogue(string path)
    {
        if (!inDialogue)
        {
            index = 0;
            var jsonTextFile = Resources.Load<TextAsset>("Json Files/" + path);
            dialogue = JsonMapper.ToObject(jsonTextFile.text);
            inDialogue = true;
            return true;
        }
        return false;
    }

   

    public bool PrintLine()
    {
        if (inDialogue)
        {
            diaCounter++;
            JsonData line = dialogue[index];
            if (line[0].ToString() == "EOD")
            {
                ObjectsOn.SetActive(false);
                inDialogue = false;
                DialogueMenu.SetActive(false);
                if (MenuActivateGO.tag == "Story")
                {
                    
                    SceneManager.LoadScene("Level01");

                }
                else
                {
                    MenuActivateGO.SetActive(true);

                }
                updateSceneValue();
                textDisplay.text = "";
                return false;
            }
            foreach (JsonData key in line.Keys)
                speaker = key.ToString();
            ActivateAnimation();

            textDisplay.text = speaker + ": " + line[0].ToString();
            index++;
        }
        return true;
    }

   
    void Start()
    {
        PlayerPrefs.SetInt("SceneValue", sceneval);
        MenuActivateGO.SetActive(false);
        LoadDialogue(pathOfDialogue);
        InvokeRepeating("DialogueFlow", 1f, 5f);
       
    }
    
    void updateSceneValue()
    {
       
        if (PlayerPrefs.GetInt("SceneValue") == 1)
        {
            ++sceneval;
            currentSceneName = "Level01";
            nextSceneName = "Level02";
        }else if (PlayerPrefs.GetInt("SceneValue") == 2)
        {
            ++sceneval;
            currentSceneName = "Level02";
            nextSceneName ="Level03";
        }
        else if (PlayerPrefs.GetInt("SceneValue") == 3)
        {
            ++sceneval;
            currentSceneName = "Level03";
            nextSceneName = "Level04";
        }
        PlayerPrefs.SetInt("SceneValue", sceneval);
        Debug.Log("sceneval" + sceneval);
        Debug.Log("current" + currentSceneName.ToString());
        Debug.Log("next" + nextSceneName.ToString());

    }
    public void ActivateAnimation()
    {
        if (speaker == "Axel")
        {
            //player
            AnimP.SetBool("Talk", true);
            AnimE.SetBool("Talking", false);
        }
        else if (speaker == "Strange person" || speaker == "FireMaster Disciple")
        {
            AnimP.SetBool("Talk", false);
            AnimE.SetBool("Talking", true);
        }
        else if (speaker == "Story Narrator")
        {
            AnimP.SetBool("Talk", false);
            AnimE.SetBool("Talking", false);
        }

    }
    


    public void DialogueFlow()
    {
        PrintLine();

    }

    public void Restart()
    {
        //sceneval--;
        //PlayerPrefs.SetInt("SceneValue", sceneval);
        SceneManager.LoadScene(currentSceneName.ToString());
    }

    public void Quit()
    {

        Application.Quit();
    }
    public void NextScene()
    {

        SceneManager.LoadScene(nextSceneName.ToString());
    }
    public void Menu()
    {

        SceneManager.LoadScene("mainmenu");
    }
}
