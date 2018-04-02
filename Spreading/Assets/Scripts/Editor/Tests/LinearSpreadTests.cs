using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Spreading;

public class LinearSpreadTests
{

    [Test]
    public void LinearSpreadCreation()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(lSpread.GetType(), typeof(LinearSpread));
    }

    [Test]
    public void LinearSpreadSize()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(5, lSpread.size);
    }

    [Test]
    public void LinearSpreadMinValue()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(-0.5f, lSpread.value[0]);
    }

    [Test]
    public void LinearSpreadMaxValue()
    {
        LinearSpread lSpread = new LinearSpread(5, 1f, 0f);
        Assert.AreEqual(0.5f, lSpread.value[lSpread.size - 1]);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
	}
}
