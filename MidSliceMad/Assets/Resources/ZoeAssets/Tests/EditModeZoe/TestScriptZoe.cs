using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Properties;
using UnityEditor.VersionControl;
using UnityEngine;

public class TestScriptZoe 
{
    Quest testQuest1 = new MainQuest1();
    Quest testQuest2 = new MainQuest2();
    Quest testQuest3 = new MainQuest3();
    Quest testQuest4 = new MainQuest4();
    public void Attributes()
    {
        testQuest1.SetQuestAttributes();
        testQuest2.SetQuestAttributes();
        testQuest3.SetQuestAttributes(); 
        testQuest4.SetQuestAttributes();
    }
    [Test]
    public void TestAttributes()
    {
        Quest testQuest1 = new MainQuest1();
        Quest testQuest2 = new MainQuest2();
        Quest testQuest3 = new MainQuest3();
        Quest testQuest4 = new MainQuest4();
    
        testQuest1.SetQuestAttributes();
        Assert.NotNull(testQuest1.QuestMessage);
        testQuest2.SetQuestAttributes();
        Assert.NotNull(testQuest1.QuestMessage);
        testQuest3.SetQuestAttributes(); 
        Assert.NotNull(testQuest1.QuestMessage);
        testQuest4.SetQuestAttributes();

    }
    
    //Tests for Quest 1
    [Test]
    public void TestDestination1()
    {
        Attributes();
        Assert.AreEqual(testQuest1.Destination, "OutPizza");
    }
    [Test]
    public void TestProgress1()
    {
        Assert.AreEqual(testQuest1.QuestProgress, 1);
    }
    [Test]
    public void TestDestinationPost1()
    {
        Attributes();
        testQuest1.ChangeQuestProgress();
        Assert.AreEqual(testQuest1.Destination, "BlueHouse");
    }
    [Test]
    public void TestQuestName1()
    {
        Attributes();
        Assert.AreEqual(testQuest1.QuestName, "MainQuest1");
    }


    // Tests for Quest 2
    [Test]
    public void TestDestination2()
    {
        Attributes();
        Assert.AreEqual(testQuest2.Destination, "OutPizza");
    }
    [Test]
    public void TestProgress2()
    {
        Assert.AreEqual(testQuest2.QuestProgress, 1);
    }
    [Test]
    public void TestDestinationPost2()
    {
        Attributes();
        testQuest2.ChangeQuestProgress();
        Assert.AreEqual(testQuest2.Destination, "WooshMachine");
    }
    [Test]
    public void TestQuestName2()
    {
        Attributes();
        Assert.AreEqual(testQuest2.QuestName, "MainQuest2");
    }

    //Tests for Quest 3
        [Test]
    public void TestDestination3()
    {
        Attributes();
        Assert.AreEqual(testQuest3.Destination, "OutPizza");
    }
    [Test]
    public void TestProgress3()
    {

        Assert.AreEqual(testQuest3.QuestProgress, 1);
    }
    [Test]
    public void TestDestinationPost3()
    {
        Attributes();
        testQuest3.ChangeQuestProgress();
        Assert.AreEqual(testQuest3.Destination, "Sewwer");
    }
    [Test]
    public void TestQuestName3()
    {
        Attributes();
        Assert.AreEqual(testQuest3.QuestName, "MainQuest3");
    }

    //Tests for Quest 4
    [Test]
    public void TestDestination4()
    {
        Attributes();
        Assert.AreEqual(testQuest4.Destination, "OutPizza");
    }
    [Test]
    public void TestProgress4()
    {
        Assert.AreEqual(testQuest4.QuestProgress, 1);
    }
    [Test]
    public void TestDestinationPost4()
    {
        Attributes();
        testQuest4.ChangeQuestProgress();
        Assert.AreEqual(testQuest4.Destination, "Sewwer");
    }
    [Test]
    public void TestQuestName4()
    {
        Attributes();
        Assert.AreEqual(testQuest4.QuestName, "MainQuest4");
    }



}
