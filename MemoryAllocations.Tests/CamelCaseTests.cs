using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryAllocations.Tests;

[TestClass]
public class CamelCaseTests
{
    [TestMethod]
    [DataRow("Fox Mulder", "foxMulder")]
    [DataRow("You are a very fancy boy!", "youAreAVeryFancyBoy")]
    [DataRow("Hey, I need YoU to be Camel CAsE! Got it? :)", "heyINeedYouToBeCamelCaseGotIt")]
    public void Camel_Case_Should_Work_Stack_Aloc(string sut, string expected)
    {
        sut.CamelCaseStackAlloc().Should().Be(expected);
    }

    [TestMethod]
    [DataRow("Fox Mulder", "foxMulder")]
    [DataRow("You are a very fancy boy!", "youAreAVeryFancyBoy")]
    [DataRow("Hey, I need YoU to be Camel CAsE! Got it? :)", "heyINeedYouToBeCamelCaseGotIt")]
    public void Camel_Case_Should_Work_Linq(string sut, string expected)
    {
        sut.CamelCaseLinq().Should().Be(expected);
    }
}