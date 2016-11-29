using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {
    //Changes the scene from one to another. The script can be put on any game object, and add the button and scene name.
    public Button buttonName;
    public string sceneToChangeTo;
   
    void Start() {
        //Listens for when the button is clicked
        buttonName.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        //Changes from current scene to new scene. It deletes the old scenes. It does it asyncronous (Reduces laggs).
        SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Single);
    }
}