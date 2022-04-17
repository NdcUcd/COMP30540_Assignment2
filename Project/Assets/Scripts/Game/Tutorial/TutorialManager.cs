using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject AI;
    [SerializeField] Transform keysParent;
    List<Image> keys = new List<Image>();
    [SerializeField] GameObject canvasTuto, AIPanel;

    AvatarController avatarController;

    int[] tutorialNotes = new int[] { 0, 2, 4, 7, 9, 4, 7, 9,
                                      1, 3, 5, 8, 10, 5, 8, 10,
                                      0, 1, 5, 8, 10, 5, 8, 10,
                                      1, 2, 6, 9, 11, 6, 9, 11,
                                      1, 3, 4, 8, 10, 4, 8, 10,
                                      2, 4, 5, 9, 11, 5, 9, 11,
                                      0, 2, 4, 7, 9, 4, 7, 9,
                                      1, 3, 5, 8, 10, 5, 8, 10
                                    };

    int currentTutorialNoteIndex = 0;


    void OnEnable()
    {
        AI.SetActive(true);
        GameObject.Find("Player ship").SetActive(false);

        avatarController = FindObjectOfType<AvatarController>();

        for (int i = 0; i < keysParent.childCount; i++)
        {
            Image image = keysParent.GetChild(i).transform.GetComponent<Image>();
            keys.Add(image);
            image.enabled = false;
        }

        canvasTuto.SetActive(true);

        GameObject.Find("Level").SetActive(false);
        GameObject.Find("Score").SetActive(false);

        AIPanel.SetActive(true);

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartTuto();
    }

    void StartTuto()
    {
        Time.timeScale = 1;
        AIPanel.SetActive(false);
    }


    void EnableNewKey(int keyIndex)
    {
        for (int i = 0; i < keysParent.childCount; i++)
        {
            Image image = keysParent.GetChild(i).transform.GetComponent<Image>();

            if (image.enabled) image.enabled = false;
            if (i == keyIndex) image.enabled = true;
        }
    }

    public int GetTutorialNotes()
    {
        if (currentTutorialNoteIndex > tutorialNotes.Length - 1)
        {
            FindObjectOfType<NotesManager>().enabled = false;
            AITextManager.textIndex = 2;
            AIPanel.SetActive(true);
            return -1;  //Indicates that the end of the tutorial has been reached
        };

        int note = tutorialNotes[currentTutorialNoteIndex];
        currentTutorialNoteIndex++;

        Note notePositionToMoveTo = GameManager.notes[note];
        avatarController.Move(notePositionToMoveTo);
        EnableNewKey(note);

        return note;
    }

    private void OnDisable()
    {
        GameManager.tutorialMode = false;
    }
}
