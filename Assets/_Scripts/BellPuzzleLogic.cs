using UnityEngine;

public class BellPuzzleLogic : MonoBehaviour
{
    public int bellsCount = 5;
    public int puzzleDifficulty = 5;
    private Transform[] bells;
    public Material defaultMaterial;
    public Material hoverMaterial;
    public static bool shouldStart = false;
    private float puzzleSpeed = 0.9F;
    public static int currentSolveIndex = 0;
    private bool currentlyDisplayingPattern = true;
    private int[] sequence;
    private bool started = false;
    private int currentDisplayIndex = 0;
    private bool playerWon = false;
    public GameObject painting, code;


    // Use this for initialization
    void Start()
    {
        sequence = new int[puzzleDifficulty];
        int i = 0;
        bells = new Transform[bellsCount];
        foreach (Transform item in gameObject.transform)
        {
            bells[i] = item.GetChild(0);
            ++i;
        }
        Debug.Log("bells initialized.");
        GenerateSequence();
        Debug.Log("sequence initialized.");
        painting.SetActive(false);
        code.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldStart && !started)
        {
            StartPuzzle();
            started = true;
        }
    }

    public void StartPuzzle()
    {
        CancelInvoke("DisplayPattern");
        InvokeRepeating("DisplayPattern", 1.2F, puzzleSpeed);
        currentSolveIndex = 0;
    }

    private void GenerateSequence()
    {
        for (int i = 0; i < sequence.Length; i++)
            sequence[i] = Random.Range(0, puzzleDifficulty);

        // log sequence
        string res = string.Empty;
        for (int i = 0; i < sequence.Length; i++)
            res += sequence[i].ToString();
        Debug.Log(res);
    }


    public void PlayerSelection(int bellSelected)
    {
        if (shouldStart)
        {
            Debug.Log("selected " + bellSelected);
            if (!playerWon)
                SolutionCheck(bellSelected);
        }
    }

    public void SolutionCheck(int playerSelectionIndex)
    {
        if (playerSelectionIndex == sequence[currentSolveIndex])
        {
            ++currentSolveIndex;
            if (currentSolveIndex >= puzzleDifficulty)
            {
                Debug.Log("SOLVED!");
                playerWon = true;
                PuzzleSolved();
                shouldStart = false;
            }
        }
        else
            PuzzleFailure();

    }

    private void PuzzleSolved()
    {
        gameObject.GetComponents<AudioSource>()[1].Play();
        painting.SetActive(true);
        code.SetActive(true);
    }

    private void DisplayPattern()
    {
        currentlyDisplayingPattern = true; //Let us know were displaying the pattern
        SetColliders(false);
        if (currentlyDisplayingPattern == true)
        {
            if (currentDisplayIndex < sequence.Length)
            {
                Debug.Log(sequence[currentDisplayIndex] + " at index: " + currentDisplayIndex);
                bells[sequence[currentDisplayIndex]].parent.GetComponent<BellBehaviour>().PatternLightUp(puzzleSpeed);
                ++currentDisplayIndex;
            }
            else
            {
                Debug.Log("End of puzzle display");
                currentlyDisplayingPattern = false;
                currentDisplayIndex = 0;
                CancelInvoke();
                SetColliders(true);
            }
        }
    }

    public void PuzzleFailure()
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
        currentSolveIndex = 0;
        StartPuzzle();
    }

    public void SetColliders(bool tof)
    {
        Debug.Log("Setting Colliders to " + tof);
        foreach (Transform item in bells)
            item.parent.gameObject.GetComponent<BoxCollider>().enabled = tof;
    }
}


// EOF
