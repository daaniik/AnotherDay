using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [Header("Task Counts")]
    public int clothesNeeded = 5;
    public int dishesNeeded = 3;   
    public int plantsNeeded = 1;
    public int trashNeeded = 5;

    [Header("UI")]
    public TextMeshProUGUI taskText;

    int clothesDone = 0;
    int dishesDone = 0;
    int plantsDone = 0;
    int trashDone = 0;

    void Awake() => Instance = this;

    void Start() => UpdateUI();

    public void AddCloth() { clothesDone++; CheckTask(); UpdateUI(); }
    public void AddDish() { dishesDone++; CheckTask(); UpdateUI(); }
    public void AddPlant() { plantsDone++; CheckTask(); UpdateUI(); }
    public void AddTrash() { trashDone++; CheckTask(); UpdateUI(); }

    void CheckTask()
    {
        if (clothesDone >= clothesNeeded && clothesDone == clothesNeeded) AddCloth(); // prevents double-count
        // same for others if you want only one completion per task
    }

    void UpdateUI()
    {
        int completed = 0;
        if (clothesDone >= clothesNeeded) completed++;
        if (dishesDone >= dishesNeeded) completed++;
        if (plantsDone >= plantsNeeded) completed++;
        if (trashDone >= trashNeeded) completed++;

        taskText.text = $"Tasks Completed: {completed}/4\n" +
                        $"Laundry: {clothesDone}/{clothesNeeded}\n" +
                        $"Dishes: {dishesDone}/{dishesNeeded}\n" +
                        $"Plants: {plantsDone}/{plantsNeeded}\n" +
                        $"Trash: {trashDone}/{trashNeeded}";
    }
}