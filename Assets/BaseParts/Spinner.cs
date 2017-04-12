using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Spinner : MonoBehaviour {
    public bool inputAllowed = true;

    public Spool loadedSpool;


    public Image backgroundTexture;
    public Text nameBox;
    public Text textBox;
    public Canvas theCanvas;

    public OnScreenPerformer[] performers;
    public OnScreenButtons[] buttons;
    //For Managing Current Stitch
    public int currentDialogNumber;
    public Dialog[] currentDialogs;
    public Yarn[] currentYarns;
    public Stitch currentStitch;



    [System.Serializable]
    /// <summary>Holds on screen info</summary>
    public struct OnScreenPerformer
    {
        public Image image;
        public RectTransform rect;
    }

    [System.Serializable]
    ///<summary>Holding all the peices of our on screen button</summary>
    public struct OnScreenButtons
    {
        public GameObject gObject;
        public Text text;
        public Button button;
        public RectTransform rect;
    }
    // Use this for initialization
    void Start () {
        LoadStitch(loadedSpool.startStitch);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)&&inputAllowed)
        {
            print("Spacing out");
            nextDialog();
        }
	}
    /// <summary>Used to load a new stitch</summary>
    public void LoadStitch(Stitch nextStitch)
    {
        clearStitch();
        currentStitch = nextStitch;
        if (nextStitch.background != null)
        {
            backgroundTexture.sprite = (Sprite)nextStitch.background;
        }
        //Load into local memory
        currentDialogs = nextStitch.dialogs;
        currentYarns = nextStitch.yarns;

        for (int i = 0; i < nextStitch.performers.Length; i++)
        {
            loadActor(performers[i], nextStitch.performers[i]);
        }

        if (nextStitch.dialogs.Length > 0)
            loadDialog(nextStitch.dialogs[0]);
        inputAllowed = true;
    }
    /// <summary>Used to clear a stitch</summary>
    public void clearStitch()
    {
        currentStitch = null;
        currentDialogNumber = 0;
        foreach(OnScreenPerformer a in performers)
        {
            a.image.enabled = false;
        }
        textBox.text = "";
        nameBox.text = "";
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].button.interactable = false;//Stops space from activating the button
            buttons[i].gObject.SetActive(false);
        }
    }

    public void loadActor(OnScreenPerformer myPerformer, Performer thePerformer)
    {
        myPerformer.image.sprite = thePerformer.actorSprite.sprite;
        if(thePerformer.transform!=null)
            myPerformer.rect = thePerformer.transform;

        myPerformer.image.enabled = true;
    }

    public void loadDialog(Dialog diag)
    {
        textBox.text = diag.textShown;
        nameBox.text = diag.nameShown;
    }

    public void nextDialog()
    {
        //Load next dialog, if none exist go to choice time
        currentDialogNumber++;
        if (currentDialogNumber < currentDialogs.Length)
        {
            loadDialog(currentDialogs[currentDialogNumber]);
        }
        else
        {
            textBox.text = "";
            nameBox.text = "";
            loadChoices();
        }

    }
    /// <summary>
    /// Used to load choices
    /// We check status for end and auto to skip choices
    /// </summary>
    public void loadChoices()
    {
        inputAllowed = false;
        if(currentStitch.status == Stitch.stitchStatus.end)
        {
            SceneManager.LoadScene("Start");
            return;
        }
        else if(currentStitch.status == Stitch.stitchStatus.auto)
        {
            choiceMade(0);
            return;
        }


        //Magic Number warning, replace later
        int height = 240 / currentYarns.Length;
        int offSet = 244 / currentYarns.Length;
        for(int i = 0; i < currentYarns.Length; i++)
        {
            buttons[i].rect.anchoredPosition = new Vector2(buttons[i].rect.anchoredPosition.x,height * -i);
            buttons[i].rect.sizeDelta = new Vector2(buttons[i].rect.rect.width, height);
            buttons[i].gObject.SetActive(true);
            buttons[i].button.interactable = true;
            buttons[i].text.text = currentYarns[i].choiceString;

        }
        
    }
    /// <summary>Used to handle button presses</summary>
    public void choiceMade(int n)
    {
        print("button press "+n);
        inputAllowed = false;
        LoadStitch(currentYarns[n].choiceStitch);
    }
}
