using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TMP_Text _countTotalGuessText;
    [SerializeField] private TMP_Text _countRightGuessText;
    [SerializeField] private TMP_Text _countWrongGuessText;

    [SerializeField] private List<Button> _puzzleBtns;
    [SerializeField] private Transform _puzzleField;
    [SerializeField] private Sprite _buttonSprite;
    [SerializeField] private Sprite[] _puzzles;
    [SerializeField] private List<Sprite> _gamePuzzles;

    [SerializeField] private int _countTotalGuess;

    private int _firstGuessButtonIndex, _secondGuessButtonIndex;
    private bool _firstGuess, _secondGuess;
    private string _firstGuessPuzzleName, _secondGuessPuzzleName;
    private int _countGuessToEnding;
    private int _countRightGuess;
    private int _countWrongGuess;

    private void Awake()
    {
        _puzzles = Resources.LoadAll<Sprite>("Sprites/Candies");
    }

    void Start()
    {
        AddButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(_gamePuzzles);
        _countGuessToEnding = _puzzleBtns.Count / 2;
        _countTotalGuessText.text = $"Total: {_countTotalGuess}";
    }
    void AddButtons()
    {
        for (int i = 0; i < _puzzleField.childCount; i++)
        {
            _puzzleBtns.Add(_puzzleField.GetChild(i).GetComponent<Button>());
            _puzzleBtns[i].image.sprite = _buttonSprite;
        }
    }
    void AddGamePuzzles()
    {
        int looper = _puzzleBtns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index==looper/2)
            {
                index = 0;
            }
            _gamePuzzles.Add(_puzzles[index]);
            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button btn in _puzzleBtns)
        {
            btn.onClick.AddListener(CallFunction);
        }
    }
    void InteractableButton()
    {
        return;
    }
    void CallFunction()
    {
        if (!_firstGuess)
        {
            _firstGuess = true;
            _firstGuessButtonIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            _firstGuessPuzzleName = _gamePuzzles[_firstGuessButtonIndex].name;
            _puzzleBtns[_firstGuessButtonIndex].image.sprite = _gamePuzzles[_firstGuessButtonIndex];
            _puzzleBtns[_firstGuessButtonIndex].onClick.RemoveListener(CallFunction);
        }
        else if (!_secondGuess)
        {
            _secondGuess = true;
            _secondGuessButtonIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            _secondGuessPuzzleName = _gamePuzzles[_secondGuessButtonIndex].name;
            _puzzleBtns[_secondGuessButtonIndex].image.sprite = _gamePuzzles[_secondGuessButtonIndex];

            StartCoroutine(CheckPuzzlesMatch());
        }
        
    }
    private IEnumerator CheckPuzzlesMatch()
    {
        if (_firstGuessPuzzleName == _secondGuessPuzzleName)
        {
            yield return new WaitForSeconds(.5f);
            _firstGuess = _secondGuess = false;
            _puzzleBtns[_firstGuessButtonIndex].interactable = _puzzleBtns[_secondGuessButtonIndex].interactable = false;
            _puzzleBtns[_firstGuessButtonIndex].image.color = _puzzleBtns[_secondGuessButtonIndex].image.color = new Color(0, 0, 0, 0);
            _countRightGuess++;
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstGuess = _secondGuess = false;
            _puzzleBtns[_firstGuessButtonIndex].image.sprite = _puzzleBtns[_secondGuessButtonIndex].image.sprite = _buttonSprite;
            _puzzleBtns[_firstGuessButtonIndex].onClick.AddListener(CallFunction);
            _countWrongGuess++;
        }
        _countTotalGuess--;
        _countTotalGuessText.text = $"Total: {_countTotalGuess}";
        CheckEnding();
    }
    private void Shuffle(List<Sprite> spritelist)
    {
        for (int i = 0; i < spritelist.Count; i++)
        {
            int randomIndex = Random.Range(i, spritelist.Count - 1);
            Sprite temp = spritelist[i];
            spritelist[i] = spritelist[randomIndex];
            spritelist[randomIndex] = temp;
        }
    }
    private void CheckEnding()
    {
        if (_countTotalGuess == 0 || _countGuessToEnding == _countRightGuess)
        {
            _countRightGuessText.text = $"Right matches: {_countRightGuess}";
            _countWrongGuessText.text = $"Wrong matches: {_countWrongGuess}";
            _endGamePanel.SetActive(true);
        }
    }
    public void AgainButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
    }
}
