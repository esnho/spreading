using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Spreading;

public class SpreadTests
{

    Spread CreateSpread(int size)
    {
        return new Spread(size);
    }

    [Test]
    public void Creation()
    {
        Spread spread = CreateSpread(5);
        Assert.AreEqual(spread.GetType(), typeof(Spread));
    }

    [Test]
    public void Size()
    {
        int size = 5;
        Spread spread = CreateSpread(size);
        Assert.AreEqual(size, spread.Size);
    }

    [Test]
    public void IncreaseSize()
    {
        int startSize = 5;
        int newSize = 8;
        Spread spread = CreateSpread(startSize);
        spread.Size = newSize;
        Assert.AreEqual(newSize, spread.Size);
    }

    [Test]
    public void DiminishSize()
    {
        int startSize = 5;
        int newSize = 2;
        Spread spread = CreateSpread(startSize);
        spread.Size = newSize;
        Assert.AreEqual(newSize, spread.Size);
    }

    [Test]
    public void AddSameSizeSpread()
    {
        Spread lSpreadA = new Spread(5, 1f);
        Spread lSpreadB = new Spread(5, 1f);
        Spread lSpreadResult = lSpreadA + lSpreadB;
        Assert.AreEqual(2f, lSpreadResult[0]);
    }

    [Test]
    public void AddDifferentSizeSpreadWithFirstLongest()
    {
        Spread lSpreadA = new Spread(8, 1f);
        Spread lSpreadB = new Spread(5, 1f);
        Spread lSpreadResult = lSpreadA + lSpreadB;
        Assert.AreEqual(2f, lSpreadResult[0]);
        Assert.AreEqual(8, lSpreadResult.Size);
    }

    [Test]
    public void AddDifferentSizeSpreadWithSecondLongest()
    {
        Spread lSpreadA = new Spread(5, 1f);
        Spread lSpreadB = new Spread(8, 1f);
        Spread lSpreadResult = lSpreadA + lSpreadB;
        Assert.AreEqual(2f, lSpreadResult[0]);
        Assert.AreEqual(8, lSpreadResult.Size);
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
