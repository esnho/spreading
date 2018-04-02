using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Spreading;

public class LinearSpreadTests
{

    [Test]
    public void Creation()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(lSpread.GetType(), typeof(LinearSpread));
    }

    [Test]
    public void Size()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(5, lSpread.size);
    }

    [Test]
    public void IncreaseSize()
    {
        int startSize = 5;
        int newSize = 8;
        LinearSpread lSpread = new LinearSpread(startSize, 1f, 0f);
        lSpread.size = newSize;
        Assert.AreEqual(newSize, lSpread.size);
    }

    [Test]
    public void DiminishSize()
    {
        int startSize = 5;
        int newSize = 2;
        LinearSpread lSpread = new LinearSpread(startSize, 1f, 0f);
        lSpread.size = newSize;
        Assert.AreEqual(newSize, lSpread.size);
    }

    [Test]
    public void MinValue()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(-0.5f, lSpread.value[0]);
    }

    [Test]
    public void MaxValue()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(0.5f, lSpread.value[lSpread.size - 1]);
    }

    [Test]
    public void CenterValue()
    {
        float centerVal = 1.5f;
        LinearSpread lSpread = new LinearSpread(5, 15f, centerVal);
        Assert.AreEqual(centerVal, lSpread.value[2]);
    }

    [Test]
    public void ChangeCenterValue()
    {
        float centerVal = 1.5f;
        float newCenterVal = 8.155f;
        LinearSpread lSpread = new LinearSpread(5, 15f, centerVal);
        lSpread.center = newCenterVal;
        Assert.AreEqual(newCenterVal, lSpread.value[2]);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    /*[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
	}*/
}
