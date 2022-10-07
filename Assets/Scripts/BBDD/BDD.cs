using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BDD : MonoBehaviour
{

    public GameObject buttonPrefab;
    public Transform scrollview;
    private void Start()
    {
        List<int> ids = DBManager.GetAllIds();
        for (int i=0; i < DBManager.TotalCount(); i++){

            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = ids[i].ToString();
            button.GetComponent<Button>().onClick.AddListener(
                    () => { LoadGame(button.GetComponentInChildren<Text>().text); });
            button.transform.SetParent(scrollview);
            button.transform.localScale = Vector2.one;
        }
    }
    public void LoadGame(string name)
    {
        Debug.Log(name);
        Debug.Log(int.Parse(name));
        DBManager.ActualGameId = int.Parse(name);
        Debug.Log(name);
        SceneManager.LoadScene("Game");

    }
    public void AddGame()
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        DBManager.NewGame();
        int id = DBManager.GetLastId();
        button.GetComponentInChildren<Text>().text = id.ToString();
        button.GetComponent<Button>().onClick.AddListener(
                () => { LoadGame(button.GetComponentInChildren<Text>().text); });
        button.transform.SetParent(scrollview);
        button.transform.localScale = Vector2.one;
        
    }
}
