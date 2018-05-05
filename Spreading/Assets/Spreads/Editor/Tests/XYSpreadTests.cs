using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Spreading;

public class XYSpreadTests
{

    public LinearSpread CreateX(int size = 5)
    {
        LinearSpread xSpread = new LinearSpread(size, 1f, 0f);
        return xSpread;
    }

    public LinearSpread CreateY(int size = 3)
    {
        LinearSpread ySpread = new LinearSpread(size, 1f, 0f);
        return ySpread;
    }

    [Test]
    public void Size()
    {
        Spread x = CreateX();
        Spread y = CreateY();
        int expectedVectorSize = x.Size * y.Size;
        int expectedSpreadSize = expectedVectorSize * 2;
        XYSpread xySpread = new XYSpread(x, y);
        Assert.AreEqual(
            expectedSpreadSize,
            xySpread.Size,
            "Spread is not expected Size");
        Assert.AreEqual(
            expectedVectorSize,
            xySpread.Vector.Length,
            "Vector is not expected Size");
    }

    [Test]
    public void RightSpreadValues()
    {
        Spread x = CreateX();
        Spread y = CreateY();
        XYSpread xySpread = new XYSpread(x, y);
        x = CreateX(99);
        xySpread.Xin = x;
        Assert.AreEqual(
            x[0],
            xySpread[0],
            "First x is not expected value");
        Assert.AreEqual(
            y[0],
            xySpread[1],
            "First y is not expected value");
        Assert.AreEqual(
            y[y.Size - 1],
            xySpread[xySpread.Size - 1],
            "Last y is not expected value");
    }

    [Test]
    public void RightVectorValues()
    {
        Spread x = CreateX();
        Spread y = CreateY();
        XYSpread xySpread = new XYSpread(x, y);
        Vector2[] vector = xySpread.Vector;
        for (int i = 0; i < x.Size; i++)
        {
            Assert.AreEqual(
                x[i],
                vector[i].x,
                "Expected x value in first " + x.Size + " Vectors");
        }
        for (int i = 0; i < vector.Length; i += x.Size)
        {
            for (int xToCheck = 0; xToCheck < x.Size; xToCheck++)
            {
                int vectorToCheck = i + xToCheck;
                Assert.AreEqual(
                    x[xToCheck],
                    vector[vectorToCheck].x,
                    "Wrong value in " + vectorToCheck + " vector");
            }
        }
        for (int i = 0; i < vector.Length; i += y.Size)
        {
            for (int yToCheck = 0; yToCheck < y.Size; yToCheck++)
            {
                int vectorToCheck = i + yToCheck;
                Assert.AreEqual(
                    y[yToCheck],
                    vector[vectorToCheck].y,
                    "Wrong value in " + vectorToCheck + " vector");
            }
        }
        int oioi = 0;
    }

}
