using UnityEngine;

public class DeleteMapButton : Button
{
    [SerializeField] private GameObject levelButtonControl;
    public int deletionIndex;
    public GameObject deletionButton;

    private void DeleteMap()
    {
        Destroy(deletionButton);
        using (var test = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            test.Levels.Remove(test.Levels.Find(deletionIndex));
            test.SaveChanges();
        }
        levelButtonControl.SetActive(false);
    }

    protected override void Left() => DeleteMap();
}
