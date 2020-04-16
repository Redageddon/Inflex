using UnityEngine;

public class DeleteMapButton : ButtonBase
{
    [SerializeField] private GameObject levelButtonOptions;
    public int deletionIndex;
    public GameObject deletionButton;

    private void DeleteMap()
    {
        Destroy(deletionButton);
        using (Database<LevelData> db = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            db.Levels.Remove(db.Levels.Find(deletionIndex));
            db.SaveChanges();
        }
        levelButtonOptions.SetActive(false);
    }

    protected override void Left() => DeleteMap();
}
