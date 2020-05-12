using UnityEngine;

public class DeleteMapButton : ButtonBase
{
    [SerializeField] private GameObject deletionButton;
    [SerializeField] private GameObject levelButtonOptions;

    public GameObject DeletionButton
    {
        get => this.deletionButton;
        set => this.deletionButton = value;
    }

    public int DeletionIndex { get; set; }

    protected override void Left() => this.DeleteMap();

    private void DeleteMap()
    {
        Destroy(this.DeletionButton);
        using (Database<LevelData> db = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            db.Levels.Remove(db.Levels.Find(this.DeletionIndex));
            db.SaveChanges();
        }

        this.levelButtonOptions.SetActive(false);
    }
}
