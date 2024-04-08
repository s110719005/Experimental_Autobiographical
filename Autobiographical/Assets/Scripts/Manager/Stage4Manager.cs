using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4Manager : StageManager
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] pianoNotes;
    // Start is called before the first frame update
    [SerializeField]
    private Image teacherImage;
    [SerializeField]
    private Sprite teacherUp;
    [SerializeField]
    private Sprite teacherDown;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private Sprite questionMark;
    [SerializeField]
    private Sprite exampleText;

    [SerializeField]
    private GameObject blackBoard;

    private bool isCorrect = false;
    private int currentAnswer = -1;
    private int correctCount = 0;

    [SerializeField]
    private Image[] selections;
    private Coroutine questionCoroutine;
    void Start()
    {
        StartExample();
        blackBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(correctCount >= 5)
        {
            NextScene();
        }
    }

    private void StartExample()
    {
        StartCoroutine(ExampleEnumerator());
    }

    private IEnumerator ExampleEnumerator()
    {
        yield return new WaitForSeconds(2f);
        PlayPianoSound(5);
        questionImage.sprite = exampleText;
        questionImage.color = new Color(0, 0, 0, 1);
        StartCoroutine(TeacherPlayPianoEnumerator());
        yield return new WaitForSeconds(3f);
        questionImage.sprite = null;
        StartQuestion();
    }

    private void StartQuestion()
    {
        if(questionCoroutine != null)
        {
            StopCoroutine(questionCoroutine);
            questionCoroutine = null;
        }
        int randomInt = Random.Range(0, 7);
        currentAnswer = randomInt;
        isCorrect = false;
        questionCoroutine = StartCoroutine(QuestionEnumerator());

    }

    public void CheckAnswer(int answer)
    {
        if(answer == currentAnswer)
        {
            isCorrect = true;
            correctCount++;
            StartQuestion();
        }
        blackBoard.SetActive(false);
    }

    public void SetSelection(int index)
    {
        if(index == -1) { return; }
        ResetAllSelection();
        selections[index].color = new Color(255f/255, 224f/255, 30f/255, 255f/255);
    }

    private void ResetAllSelection()
    {
        foreach (var selection in selections)
        {
            selection.color = Color.white;
        }
    }

    private IEnumerator TeacherPlayPianoEnumerator()
    {
        teacherImage.sprite = teacherDown;
        yield return new WaitForSeconds(1.5f);
        teacherImage.sprite = teacherUp;
    }

    private IEnumerator QuestionEnumerator()
    {
        while(!isCorrect)
        {
            PlayPianoSound(currentAnswer);
            StartCoroutine(TeacherPlayPianoEnumerator());
            questionImage.sprite = questionMark;
            yield return new WaitForSeconds(2f);
            if(!blackBoard.activeSelf) { blackBoard.SetActive(true); }
            yield return new WaitForSeconds(3f);
            questionImage.sprite = null;
        }
        yield return null;
    }

    private void PlayPianoSound(int index)
    {
        audioSource.Stop();
        audioSource.clip = pianoNotes[index];
        audioSource.Play();
    }
}
