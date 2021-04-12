using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

public class UITest : MonoBehaviour
{
    [SetUp]
    public void init()
    {
        SceneManager.LoadScene("Unity_DB_DEMO");
    }

    [UnityTest]
    public IEnumerator testClickStartDemoButton() {
        var title = "ニフクラ mobile backend";
        var note = "上のボタンを押すとニフクラ mobile backendに{\"message\":\"Hello,NCMB!\"}が保存されます";
        var msgSuccess = "保存に成功しました。\n objectId : ";
        var msgError = "保存に失敗しました。\n ErrorCode : ";

        var tvTitleGameObject = GameObject.Find("Unity_DB_DEMO");
        var tvTitle = tvTitleGameObject.GetComponent<Text>();

        var demoButtonGameObject = GameObject.Find("StartDemo");
        var demoButton = demoButtonGameObject.GetComponent<Button>();
        
        var tvResultGameObject = GameObject.Find("Result");
        var tvResult = tvResultGameObject.GetComponent<Text>();

        Assert.NotNull(tvTitle);
        Assert.NotNull(demoButton);
        Assert.NotNull(tvResult);

        demoButton.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var result = tvResult.text;
        Assert.True(result.Contains(msgSuccess));
        Assert.AreEqual(false, result.Contains(msgError));
    }

    [TearDown]
    public void TearDown()
    {

    }
}
