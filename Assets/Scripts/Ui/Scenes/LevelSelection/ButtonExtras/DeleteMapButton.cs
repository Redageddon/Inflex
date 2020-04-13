using UnityEngine;

public class DeleteMapButton : Button
{
    [SerializeField] private GameObject levelButtonControl;
    public int DeletionIndex { get; set; }
    public GameObject DeletionButton { get; set; }

    private void DeleteMap()
    {
        Destroy(DeletionButton);
        using (var test = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            test.Levels.Remove(test.Levels.Find(DeletionIndex));
            test.SaveChanges();
        }
        levelButtonControl.SetActive(false);
    }

    protected override void Left()
    {
        DeleteMap();
    }
}
