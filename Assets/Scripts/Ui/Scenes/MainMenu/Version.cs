using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    [SerializeField] private Text version;

    private void Start() => this.version.text = Application.version;
}