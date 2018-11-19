namespace Scripts.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MainStarter : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        public void StartMain()
        {
            var mat = _player.GetComponent<Renderer>().material;



            SceneManager.LoadScene("Main");
            Scene scene = SceneManager.GetSceneByName("Main");

            //Debug.Log(scene.name);
            //Debug.Log(scene.rootCount);
            //scene.GetRootGameObjects()
            //     .Single(rootGameObject =>
            //     {
            //         Debug.Log(rootGameObject.name);
            //         return rootGameObject.name == "PlayerDefault";
            //     })
            //     .GetComponent<Renderer>()
            //     .material = mat;
        }
    }
}